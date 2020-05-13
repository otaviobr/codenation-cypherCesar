using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        private string alfabeto = "abcdefghijklmnopqrstuvwxyz";
        private List<string> cryptedMessage = new List<string>();
        private List<string> decryptedMessage = new List<string>();
        private int numberChyper = 3;
        private int numberInMessage;

        public string Crypt(string message)
        {
            if (message == null)
                throw new ArgumentNullException();

            if (message == String.Empty)
                return message;

            message = message.ToLower();

            var charList = message.ToCharArray();

            foreach (char charactere in charList)
            {
                if (alfabeto.Contains(charactere.ToString()))
                {
                    var index = alfabeto.IndexOf(charactere);

                    cryptedMessage.Add((index + numberChyper) >= 26 ? alfabeto[index + numberChyper - 26].ToString() : alfabeto[index + numberChyper].ToString());
                }
                else if (String.IsNullOrWhiteSpace(charactere.ToString()) && charactere.ToString() != null)
                {
                    cryptedMessage.Add(charactere.ToString());
                }
                else if (int.TryParse(charactere.ToString(), out numberInMessage))
                {
                    cryptedMessage.Add(charactere.ToString());
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return String.Join("", cryptedMessage);
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null)
                throw new ArgumentNullException();

            if (cryptedMessage == String.Empty)
                return cryptedMessage;

            cryptedMessage = cryptedMessage.ToLower();

            char[] charList = cryptedMessage.ToCharArray();

            foreach (char charactere in charList)
            {
                if (alfabeto.Contains(charactere.ToString()))
                {
                    var index = alfabeto.IndexOf(charactere);

                    decryptedMessage.Add((index - numberChyper) < 0 ? alfabeto[index - numberChyper + 26].ToString() : alfabeto[index - numberChyper].ToString());
                }
                else if (String.IsNullOrWhiteSpace(charactere.ToString()) && charactere.ToString() != null)
                {
                    decryptedMessage.Add(charactere.ToString());
                }
                else if (int.TryParse(charactere.ToString(), out numberInMessage))
                {
                    decryptedMessage.Add(charactere.ToString());
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return String.Join("", decryptedMessage);
        }
    }
}

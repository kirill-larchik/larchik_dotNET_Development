using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClientServerInteractionClassLibrary.NetworkPoint;

namespace ClientServerInteractionClassLibrary.EncoidngTypes
{
    /// <summary>
    /// Class describing functionality of translation of message to Russian(English) language.
    /// </summary>
    public static class ClientEncodingType
    {
        static string[] russianLetters = new string[] { "а", "б", "в", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "к", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я", "икс" };

        static string[] englistLetters = new string[] { "a", "b", "v", "w", "g", "d", "e", "yo", "j", "z", "i", "", "k", "q", "c", "l", "m", "n", "o", "p", "r", "s", "t", "y", "f", "h", "c", "ch", "sh", "sch", "", "yi", "", "e", "u", "i", "x"};

        /// <summary>
        /// Returns transleted message.
        /// </summary>
        public static EncodingMessageHandler EncodingMessage = (message) => TransleteMessage(message);

        private static string TransleteMessage(string message)
        {
            message = message.ToLower();

            if (IsRussianMessage(message))
                return TransleteToEnglish(message);
            else
                return message;
        }

        private static bool IsRussianMessage(string message)
        {
            bool isRussianMessage = false;

            for (int i = 0; i < russianLetters.Length; i++)
            {
                if (message.Contains(russianLetters[i]))
                {
                    isRussianMessage = true;
                    break;
                }
                if (message.Contains(englistLetters[i]))
                {
                    isRussianMessage = false;
                    break;
                }
            }

            return isRussianMessage;
        }

        private static string TransleteToEnglish(string message)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < russianLetters.Length; j++)
                {
                    if (message.Substring(i, 1) == russianLetters[j])
                    {
                        builder.Append(englistLetters[j]);
                        break;
                    }
                    if (Char.IsPunctuation(message[i]) || Char.IsNumber(message[i]) || Char.IsSeparator(message[i]))
                    {
                        builder.Append(message[i].ToString());
                        break;
                    }
                }
            }

            return builder.ToString();
        }
    }
}

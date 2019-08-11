using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGenerator.CustomExceptions
{
    public class WrongKeyException : CustomException
    {
        public string PressedKey { get; set; }
        public WrongKeyException(ConsoleKey key)
            : base("Неверная клавиша")
        {
            PressedKey = key.ToString();
        }
    }
}

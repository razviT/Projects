using System;

namespace WebApplication1.Controllers
{
    public class CharReplace
    {
        public string text { get; set; }
        public char letter { get; set; }
        public string stringToAdd { get; set; }
        public void ReplaceCharInString()
        {
            if (text.Length == 0)
                text = "No text given";
            var letterToString = letter.ToString();
            text = text.Replace(letterToString, stringToAdd);          
        }
    }
}

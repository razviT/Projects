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
            var letterToString = letter.ToString();
            text = text.Replace(letterToString, stringToAdd);          
        }
    }
}

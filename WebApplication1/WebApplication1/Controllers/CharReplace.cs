using System;

namespace WebApplication1.Controllers
{
    public class CharReplace
    {
        public string text { get; set; }
        public string letter { get; set; }
        public string stringToAdd { get; set; }
        public void ReplaceCharInString()
        {
            if (text.Length == 0)
                text = "No text given";
            if (letter.Length > 1)
                text = "Please input only letters";
            else
            {
                text = text.Replace(letter, stringToAdd);
            }                   
        }
    }
}

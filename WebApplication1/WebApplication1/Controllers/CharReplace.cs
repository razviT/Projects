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
            int i = text.Length - 1;
            text = RecursiveFunction(i);
        }
        string RecursiveFunction(int i)
        {
            if (i > 0)
            {
                stringToAdd = (text[i] == letter) ? stringToAdd : text[i].ToString();
                return RecursiveFunction(i - 1) + stringToAdd;
            }
            else return text[i].ToString();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WebApiAngular4.Controllers
{
  public partial class ValuesController : Controller
  {
    public class Form
    {
      public string text { get; set; }
      public string letter { get; set; }
      public string stringToAdd { get; set; }

      public void ReplaceLetterInText()
      {
        if (text.Length == 0)
          text = "Please input a text";
        else if (letter.Length != 1)
          text = "Please input a letter";
        else if (stringToAdd.Length == 0)
          text = "Please input a string to add";
        else
          text = text.Replace(letter, stringToAdd);
      }
    }
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Aufgabe.Models
{
    public class User
    {
        
        public int id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name ist erförderlich ")]
        public string Name { get; set; }
        [DisplayName("E-Mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-Mail ist erförderlich ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Geburtsdatum ist erförderlich ")]

        
        [DataType(DataType.Date)]
        [MindestOld(18, ErrorMessage = " Mindest Age ist 18 jahre !")]
        public DateTime Geburtsdatum { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Passwort ist erförderlich ")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Mindestens 8 Zeichen mit mindestens zwei Ziffern ")]
        [RegularExpression(@".*[@$!%*#_*?&]{2,}.*", ErrorMessage = "Passwort muss mindestens 2 zifferen inhalten")]
        public string Passwort { get; set; }
        [Display(Name = "Passwortwiederholung")]
        [DataType(DataType.Password)]
        [Compare("Passwort", ErrorMessage = "Passwort muss abstimmen")]
        [RegularExpression(@".*([@$!%*#_*?&]{2,})", ErrorMessage = "Passwort muss 2 ziffern inthalten")]


        public string Passwortwiederholung { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}

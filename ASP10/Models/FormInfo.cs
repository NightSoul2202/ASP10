using System.ComponentModel.DataAnnotations;

namespace ASP10.Models
{
    public class FormInfo
    {
        [Required(ErrorMessage = "Ім'я прізвище є обов'язковим")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Невірний формат email")]  
        public string Email { get; set; }

        [Required(ErrorMessage = "Дата консультації є обов'язковою")]
        [DataType(DataType.Date, ErrorMessage = "Невірний формат дати")]
        [FutureDate(ErrorMessage = "Дата консультації має бути в майбутньому і не потрапляти на вихідні")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Будь ласка, оберіть продукт")]
        public string Product { get; set; }

    }
}

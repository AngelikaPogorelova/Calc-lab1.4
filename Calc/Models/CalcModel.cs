using System.ComponentModel.DataAnnotations;
namespace Calc.Models
{
    public class CalcModel
    {
        [Required(ErrorMessage = "Введите первое число")]
        public long? Operand1 { get; set; }

        [Range(1, 1000, ErrorMessage = "Введите число от 1 до 1000")]
        public long? Operand2 { get; set; }

        public string? Operation { get; set; }

        public decimal Result { get; set; }
    }
}

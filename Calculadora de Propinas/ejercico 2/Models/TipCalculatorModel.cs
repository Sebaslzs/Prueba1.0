using System.ComponentModel.DataAnnotations;

namespace TipCalculator.Models
{
    public class TipCalculatorModel
    {
        [Required(ErrorMessage = "El monto de la factura es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Por favor, ingrese un monto positivo.")]
        public double BillAmount { get; set; }

        [Required(ErrorMessage = "El porcentaje de propina es obligatorio.")]
        [Range(0, 100, ErrorMessage = "Por favor, ingrese un porcentaje entre 0 y 100.")]
        public double TipPercentage { get; set; }

        public double TipAmount => BillAmount * (TipPercentage / 100);

        public double TotalAmount => BillAmount + TipAmount;
    }
}

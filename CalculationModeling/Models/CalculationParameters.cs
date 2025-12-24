using CalculationModeling.Models;
using System.ComponentModel.DataAnnotations;

namespace CalculationModeling.Models
{
    public class CalculationParameters
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CalculationName { get; set; }

        [Range(0.5, 100)]
        
        public double LayerHeightValue { get; set; }

        [Range(-50, 2000)]
        public double InitialMaterialTempValue { get; set; }

        [Range(-50, 2000)]
        public double InitialGasTempValue { get; set; }

        [Range(0.01, 10)]
        public double GasVelocityValue { get; set; }

        [Range(0.1, 10)]
        public double GasHeatCapacityValue { get; set; }

        [Range(0.1, 10)]
        public double MaterialConsumptionValue { get; set; }

        [Range(0.1, 10)]
        public double MaterialHeatCapacityValue { get; set; }

        [Range(100, 10000)]
        public double HeatTransferCoefficientValue { get; set; }

        [Range(0.5, 5)]
        public double ApparatusDiameterValue { get; set; }

        
    }
}

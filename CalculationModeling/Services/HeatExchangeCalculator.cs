using CalculationModeling.Models;
using CalculationModeling.Models;
using System.Diagnostics;

namespace CalculationModeling.Services
{
    public class HeatExchangeCalculator : IHeatExchangeCalculator
    {
        public List<CalculationResult> CalculateDetailed(CalculationParameters parameters)
        {
            var results = new List<CalculationResult>();

            double crossSectionArea = Math.PI * Math.Pow(parameters.ApparatusDiameterValue / 2, 2);
            double numeratorM = parameters.MaterialConsumptionValue * parameters.MaterialHeatCapacityValue;
            double denominatorM = parameters.GasVelocityValue * crossSectionArea * parameters.GasHeatCapacityValue;
            double m = numeratorM / denominatorM;

            double Y0 = (parameters.HeatTransferCoefficientValue * parameters.LayerHeightValue) /
                        (parameters.GasVelocityValue * parameters.GasHeatCapacityValue * 1000);

            double denominator = 1 - m * Math.Exp(((m - 1) * Y0) / m);

            for (double y = 0; y <= parameters.LayerHeightValue; y += 0.5)
            {
                double Y = (parameters.HeatTransferCoefficientValue * y) /
                           (parameters.GasVelocityValue * parameters.GasHeatCapacityValue * 1000);

                double expValue = Math.Exp(((m - 1) * Y) / m);

                double theta1 = (1 - expValue) / denominator;
                double theta2 = (1 - m * expValue) / denominator;

                double materialTemp =
                    parameters.InitialMaterialTempValue +
                    (parameters.InitialGasTempValue - parameters.InitialMaterialTempValue) * theta1;

                double gasTemp =
                    parameters.InitialMaterialTempValue +
                    (parameters.InitialGasTempValue - parameters.InitialMaterialTempValue) * theta2;

                results.Add(new CalculationResult
                {
                    // ❗ Id НЕ УКАЗЫВАЕМ
                    CoordinateY = Math.Round(y, 1),
                    RelativeHeight = Math.Round(Y, 2),
                    Theta1 = Math.Round(theta1, 4),
                    Theta2 = Math.Round(theta2, 4),
                    MaterialTemp = Math.Round(materialTemp, 2),
                    GasTemp = Math.Round(gasTemp, 2),
                    TempDifference = Math.Round(materialTemp - gasTemp, 2),
                    Parameters = parameters
                });
            }

            return results;
        }
    }
}

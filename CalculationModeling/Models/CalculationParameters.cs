using CalculationModeling.Models;
using System.ComponentModel.DataAnnotations;

public class CalculationParameters
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название расчёта")]
    [StringLength(100, ErrorMessage = "Название слишком длинное")]
    public string CalculationName { get; set; }

    [Range(0.5, 20, ErrorMessage = "Высота слоя должна быть от 0,5 до 20 м")]
    public double LayerHeightValue { get; set; }

    [Range(-50, 1500, ErrorMessage = "Начальная температура материала вне допустимого диапазона")]
    public double InitialMaterialTempValue { get; set; }

    [Range(-50, 1500, ErrorMessage = "Начальная температура газа вне допустимого диапазона")]
    public double InitialGasTempValue { get; set; }

    [Range(0.1, 2, ErrorMessage = "Скорость газа должна быть от 0,1 до 2 м/с")]
    public double GasVelocityValue { get; set; }

    [Range(0.5, 5, ErrorMessage = "Теплоёмкость газа должна быть от 0,5 до 5 кДж/(м³·К)")]
    public double GasHeatCapacityValue { get; set; }

    [Range(0.1, 5, ErrorMessage = "Расход материала должен быть от 0,1 до 5 кг/с")]
    public double MaterialConsumptionValue { get; set; }

    [Range(0.5, 5, ErrorMessage = "Теплоёмкость материала должна быть от 0,5 до 5 кДж/(кг·К)")]
    public double MaterialHeatCapacityValue { get; set; }

    [Range(500, 5000, ErrorMessage = "Коэффициент теплоотдачи должен быть от 500 до 5000 Вт/(м³·К)")]
    public double HeatTransferCoefficientValue { get; set; }

    [Range(0.5, 5, ErrorMessage = "Диаметр аппарата должен быть от 0,5 до 5 м")]
    public double ApparatusDiameterValue { get; set; }
}


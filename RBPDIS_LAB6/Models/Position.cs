using System.ComponentModel.DataAnnotations;

namespace RBPDIS_LAB6.Models
{
    public class Position
    {
        public int PositionId { get; set; }

        [Display(Name = "Должность")]
        public string? PositionName { get; set; }

        [Display(Name = "Зарплата ($)")]
        public float? SalaryUsd { get; set; }

        public List<Employee> Employees { get; set; } = new();

    }
}

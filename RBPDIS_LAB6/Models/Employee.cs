using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RBPDIS_LAB6.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Имя сотрудника")]
        public string? EmployeeName { get; set; }

        [Display(Name = "Возраст")]
        public int? Age { get; set; }

        [Display(Name = "Опыт работы")]
        public float? WorkExperience { get; set; }

        public int PositionID { get; set; }
        public Position? Position { get; set; }

        public List<Train> Trains { get; set; } = new();
        public List<TrainStaff> TrainStaffs { get; set; } = new();
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace RBPDIS_LAB6.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        [Display(Name = "День недели")]
        public int DayOfWeek { get; set; }

        [Display(Name = "Поезд")]
        public int TrainId { get; set; }

        [Display(Name = "Поезд")]
        public Train? Train { get; set; }

        [Display(Name = "Остановка")]
        public int StopId { get; set; }

        [Display(Name = "Остановка")]
        public Stop? Stop { get; set; }

        [Display(Name = "Время прибытия")]
        public TimeSpan? ArrivalTime { get; set; }
        [Display(Name = "Время отправки")]
        public TimeSpan? DepartureTime { get; set; }

    }
}

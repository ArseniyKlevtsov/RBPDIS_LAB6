﻿using Microsoft.EntityFrameworkCore;

namespace RBPDIS_LAB6.Models
{
    public class RailwayTrafficContext : DbContext
    {
        public RailwayTrafficContext(DbContextOptions<RailwayTrafficContext> options)
            : base(options)
        {

        }
        //таблицы-справочники
        public DbSet<TrainType> TrainTypes { get; set; }
        
        //обычные таблицы
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // связующие таблицы для отношений many-to-many
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TrainStaff> TrainStaffs { get; set; }

       
    }
}
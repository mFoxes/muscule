using Microsoft.EntityFrameworkCore;
using Muscle.Entities.DbSet.DbSetForEquipmentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.Data
{
    public class EquipmentDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentHall>()
                .HasKey(x => new { x.EquipmentId, x.HallId });
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentHall> EquipmentHalls { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }

        public EquipmentDbContext(DbContextOptions<EquipmentDbContext> options)
            : base(options)
        {

        }
    }
}

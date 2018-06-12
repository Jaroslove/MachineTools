using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MachineTools.Models
{
    public class DataBase : DbContext
    {
        public DataBase() : base("MachineTools")
        {
        }

        public DbSet<MachineTool> MachineTools { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
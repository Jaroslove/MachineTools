using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MachineTools.Models
{
    public class MachineTool
    {
        public Guid Id { get; set; }
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartExplaine { get; set; }

    }
}
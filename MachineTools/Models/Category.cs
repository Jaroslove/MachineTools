using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachineTools.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<MachineTool> MachineTools { get; set; }

        public Category()
        {
            MachineTools = new List<MachineTool>();
        }
    }
}
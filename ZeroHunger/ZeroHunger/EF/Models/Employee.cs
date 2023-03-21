using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Must not exceed 100 characters")]
        public string Name { get; set; }
        public int Contact { get; set; }

        public virtual ICollection<EmpProdReq> EmpProdReqs { get; set; }
        public Employee()
        {
            EmpProdReqs = new List<EmpProdReq>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class EmpProdReq
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }

        [ForeignKey("Employee")]
        public int Emp_Id { get; set; }
        [ForeignKey("ProdReq")]
        public int ProdReq_Id { get; set;}

        public virtual Employee Employee { get; set; }
        public virtual ProdReq ProdReq { get; set; }
    }
}
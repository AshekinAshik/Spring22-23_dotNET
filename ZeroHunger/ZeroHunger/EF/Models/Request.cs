using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public DateTime ReqDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<ProdReq> ProdReqs { get; set; }
        public Request() { 
            ProdReqs= new List<ProdReq>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class ProdReq
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int Prod_Id { get; set; }
        [ForeignKey("Request")]
        public int Req_Id { get; set;}

        public virtual Product Product { get; set; }
        public virtual Request Request { get; set; }

        public virtual ICollection<EmpProdReq> EmpProdReqs { get; set; }
        public ProdReq()
        {
            EmpProdReqs = new List<EmpProdReq>();
        }
    }
}
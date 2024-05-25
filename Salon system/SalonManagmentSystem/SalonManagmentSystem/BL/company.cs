using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public class company
    {
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
        public int isdeleted { get; set; }
        public string name { get; set; }
        public string product {  get; set; }
        public company(string name,DateTime createdOn, DateTime updatedOn, int isdeleted)
        {
            this.name = name;
            this.createdOn = createdOn;
            this.updatedOn = updatedOn;
            this.isdeleted = isdeleted;
        }
        public company(string name ,string product,DateTime updatedOn) {
            this.name = name;
            this.product= product;
            this.updatedOn = updatedOn;
        }

       
    }
}

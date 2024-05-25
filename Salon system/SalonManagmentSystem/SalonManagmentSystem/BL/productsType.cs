using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public class ProductsType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
        public int isdeleted { get; set; }

        public ProductsType(string name, string description,DateTime createdOn,DateTime updatedOn,int isdeleted)
        {
            this.Name = name;
            this.Description = description;
            this.createdOn = createdOn;
            this.updatedOn = updatedOn;
            this.isdeleted = isdeleted;
        }
        public ProductsType(string name,DateTime updatedOn,string description) {
            this.Name = name;
            this.Description = description;
            this.updatedOn = updatedOn;
        }
    }
}

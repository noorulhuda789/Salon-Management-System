using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public class supplier
    {
 
            public string Name { get; set; }
            public string Property2 { get; set; }
            public string Property3 { get; set; }

            public supplier(string name, string property2, string property3)
            {
                Name = name;
                Property2 = property2;
                Property3 = property3;
            }
      
        public string name {  get; set; }
        public string address {  get; set; }
        public string contact {  get; set; }
        public int isdeletd {  get; set; }
        public int addedBy { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
        public string product {  get; set; }
        public supplier(string name, string address, string contact, int isdeletd,DateTime createdON, DateTime updatedON,int addedBy)
        {
            this.name = name;
            this.address = address;
            this.contact = contact;
            this.isdeletd = isdeletd;
            this.createdOn = createdON;
            this.updatedOn = updatedON;
            this.addedBy = addedBy; 
        }
        public supplier(string name,string product,DateTime updatedOn)
        {
            this.name=name;
            this.product=product;
            this.updatedOn=updatedOn;
        }
    }
}

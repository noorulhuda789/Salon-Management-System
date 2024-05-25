using SalonManagmentSystem.DL;
using System;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using System.Drawing;

namespace SalonManagmentSystem.BL
{
    public class product
    {
        public product(int orderId, int quantity, string name, int price, DateTime time, DateTime createdAt, DateTime updatedAt, int owner, int isDeleted, int status)
        {
            this.orderid = orderId;
            this.quantity = quantity;
            this.name = name;
            this.price = price;
            this.expiryDate = time;
            this.createdOn = createdAt;
            this.updatedOn = updatedAt;
            this.addedBy = owner;
            this.isdeleted = isDeleted;
            this.returnStatus = status;
        }
        public product(string name, int quantity, string reason, int orderid, string supplierName, string companyName, int addedBy, DateTime createdOn)
        {
            this.name = name;
            this.quantity = quantity;
            this.reason = reason;
            this.orderid = orderid;
            this.supplierName = supplierName;
            this.companyName = companyName;
            this.addedBy = addedBy;
            this.createdOn = createdOn;
        }

        public product(string name, int quantity, string companyName, string productType, DateTime createdOn, DateTime updatedOn, int addedBy, int isDeleted)
        {
            this.name = name;
            this.quantity = quantity;
            this.companyName = companyName;
            this.productType = productType;
            this.createdOn = createdOn;
            this.updatedOn = updatedOn;
            this.addedBy = addedBy;
            this.isdeleted = isDeleted;
        }

        public product(string name, int quantity, string productType, string companyName, DateTime createdOn, int addedBy)
        {
            this.name = name;
            this.quantity = quantity;
            this.companyName = companyName;
            this.productType = productType;
            this.createdOn = createdOn;
            this.addedBy = addedBy;
        }

        public product(string name, int restocklevel, string supplierName, string companyName, string productType, DateTime createdOn, DateTime updatedOn, int isdeleted, int price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.supplierName = supplierName;
            this.companyName = companyName;
            this.productType = productType;
            this.restocklevel = restocklevel;
            this.createdOn = createdOn;
            this.updatedOn = updatedOn;
            this.isdeleted = isdeleted;
        }

        public product(string productName, int quantity, string reason, int orderId, string supplier, string company,int owner, DateTime receivedOn, int returnId)
        {
           this.name = productName;
            this.quantity = quantity;
            this.reason = reason;
            this.orderid = orderId;
            this.supplierName = supplier;
            this.companyName = company;
           this.addedBy = owner;
            this.createdOn = receivedOn;
            this.returnStatus = returnId;
        }


        // Properties
        public string reason { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string supplierName { get; set; }
        public string companyName { get; set; }
        public string productType { get; set; }
        public int restocklevel { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
        public int isdeleted { get; set; }
        public int addedBy { get; set; }
        public int orderid { get; set; }
        public DateTime expiryDate { get; set; }
        public int returnStatus { get; set; }
        public int productId {  get; set; }
    }
}

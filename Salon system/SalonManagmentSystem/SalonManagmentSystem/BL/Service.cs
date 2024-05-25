using SalonManagmentSystem.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace SalonManagmentSystem.BL
{
    public class Service
    {
        public Service(string name,  decimal serviceCharges, decimal timeDuration, int serviceTypeId,  DateTime cTime, int del, DateTime uTime, string desc = null)
        {
            this.name = name;
            this.serviceCharges = serviceCharges;
            this.timeDuration = timeDuration;
            this.serviceTypeId = serviceTypeId;
            this.description = desc;
            this.createdOn = cTime;
            this.updateOn = uTime;
            this.isDeleted = del; 
        }
        public Service(int id, string name,  decimal serviceCharges, decimal timeDuration, int serviceTypeId, DateTime cTime, int del, DateTime uTime, string desc = null)
        {
            this.id = id;
            this.name = name;
            this.serviceCharges = serviceCharges;
            this.timeDuration = timeDuration;
            this.serviceTypeId = serviceTypeId;
            this.description = desc;
            this.createdOn = cTime;
            this.updateOn = uTime;
            this.isDeleted = del;
        }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public  decimal serviceCharges { get; set; }
        public decimal timeDuration { get; set; }
        public int serviceTypeId { get; set; }
        public DateTime updateOn { get; set; }
        public DateTime createdOn { get; set; }
        public int isDeleted { get; set; }
    }
}
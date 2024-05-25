using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public class ServiceType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ServiceType(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}

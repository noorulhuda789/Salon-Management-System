using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagmentSystem.BL
{
    public class Notification
    {
        public Notification(string message, DateTime dc, int sb) {
            this.message = message;
            this.dateCreated = dc;
            this.sentBy = sb;
        }
        public int id { get; set; }
        public string message { get; set; }
        public DateTime dateCreated { get; set; }
        public int sentBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOfficeManagement.Entity
{
    public class Attendees
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public bool Attend { get; set; }
        public DateTime DueTime { get; set; }
    }
}

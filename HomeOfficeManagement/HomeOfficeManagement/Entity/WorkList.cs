using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOfficeManagement.Entity
{
    public class WorkList
    {
       
       public int Id { get; set;}
       public string TaskName { get; set; }
       public DateTime Date { get; set; }
       public string WorkDetails { get; set; }

    }
}

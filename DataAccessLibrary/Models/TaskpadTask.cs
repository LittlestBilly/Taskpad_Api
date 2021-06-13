using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class TaskpadTask
    {
        public int task_id { get; set; }
        public string task_name { get; set; }
        public string task_notes { get; set; }
    }
}

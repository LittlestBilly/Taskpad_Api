using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class TaskpadStep
    {
        public Guid task_id { get; set; }
        public Guid step_id { get; set; }
        public string step_name { get; set; }
        public string step_state { get; set; }
        public string step_priority { get; set; }
    }
}

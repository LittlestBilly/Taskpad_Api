using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class TaskWithSteps
    {
        public TaskpadTask Task { get; set; }
        public List<TaskpadStep> StepList { get; set; }
    }
}
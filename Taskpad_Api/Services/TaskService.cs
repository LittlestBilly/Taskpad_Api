using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary.Data;
using DataAccessLibrary.Models;

namespace Taskpad_Api.Services
{
    public class TaskService
    {

        private readonly ITaskpadData _db;
        public TaskService(ITaskpadData db)
        {
            _db = db;
        }

        public List<Task> GetTaskList()
        {


            return null;
        }
    }
}
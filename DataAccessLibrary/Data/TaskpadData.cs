using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data
{
    public class TaskpadData : ITaskpadData
    {
        private readonly ISqlDataAccess _db;

        public TaskpadData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<TaskpadTask>> GetTasks()
        {
            string sql = @"SELECT [task_id]
                          ,[task_name]
                          ,[task_notes]
                        FROM[taskpad].[dbo].[tasks]";

            return _db.LoadData<TaskpadTask, dynamic>(sql, new { });
        }

        public Task<List<TaskpadTask>> GetTask(int task_id)
        {
            string sql = @"SELECT [task_id]
                          ,[task_name]
                          ,[task_notes]
                        FROM[taskpad].[dbo].[tasks]
                        WHERE task_id = @task_id";

            return _db.LoadData<TaskpadTask, dynamic>(sql, new { task_id });
        }

        public Task<List<TaskpadStep>> GetSteps(int task_id)
        {
            string sql = @"SELECT [task_id]
                          ,[step_name]
                          ,[step_state]
                          ,[step_priority]
                      FROM[taskpad].[dbo].[steps]
                      WHERE task_id = @task_id; ";

            return _db.LoadData<TaskpadStep, dynamic>(sql, new { task_id });
        }
        
    }
}

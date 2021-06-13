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
        public Boolean TaskExist(string task_name)
        {
            var x = GetTasks().Result;
            if (x != null)
            {
                foreach (var t in x)
                {
                    if(t.task_name.ToLower().Equals(task_name.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;

        }
        public Boolean TaskExist(int task_id)
        {
            var x = GetTasks().Result;
            if (x != null)
            {
                foreach (var t in x)
                {
                    if(t.task_id.Equals(task_id))
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public async Task<List<TaskpadTask>> GetTasks()
        {
            string sql = @"SELECT [task_id]
                          ,[task_name]
                          ,[task_notes]
                        FROM[taskpad].[dbo].[tasks]";

            return await _db.LoadData<TaskpadTask, dynamic>(sql, new { });
        }

        public async Task<List<TaskpadTask>> GetTask(int task_id)
        {
            string sql = @"SELECT [task_id]
                          ,[task_name]
                          ,[task_notes]
                        FROM[taskpad].[dbo].[tasks]
                        WHERE task_id = @task_id";


            return await _db.LoadData<TaskpadTask, dynamic>(sql, new { task_id });
        }

        public async Task CreateTask(string task_name, string task_notes)
        {

            string sql = @"INSERT INTO tasks(task_name, task_notes)
                        VALUES(@task_name, @task_notes);";

            await _db.SaveData(sql, new { task_name, task_notes });

        }



        public async Task<List<TaskpadStep>> GetSteps(int task_id)
        {
            string sql = @"SELECT [task_id]
                          ,[step_name]
                          ,[step_state]
                          ,[step_priority]
                      FROM[taskpad].[dbo].[steps]
                      WHERE task_id = @task_id; ";

            return await _db.LoadData<TaskpadStep, dynamic>(sql, new { task_id });
        }



    }
}

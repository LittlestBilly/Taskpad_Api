using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data
{
    public interface ITaskpadData
    {
        Task CreateTask(string task_name, string task_notes);
        Task<List<TaskpadStep>> GetSteps(Guid task_id);
        Task<List<TaskpadTask>> GetTask(Guid task_id);
        Task<List<TaskpadTask>> GetTasks();
        bool TaskExist(string task_name);
        bool TaskExist(int task_id);
    }
}
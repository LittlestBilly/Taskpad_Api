using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data
{
    public interface ITaskpadData
    {
        Task<List<TaskpadStep>> GetSteps(int task_id);
        Task<List<TaskpadTask>> GetTasks();
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary.Data;
using DataAccessLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taskpad_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskpadData _db;
        public TaskController(ITaskpadData db)
        {
            _db = db;
        }


        // GET: api/<TaskController>
        [HttpGet]
        public List<TaskpadTask> Get()
        {
            return _db.GetTasks().Result;
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public TaskpadTask Get(Guid id)
        {
            return _db.GetTask(id).Result.FirstOrDefault();
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post(TaskpadTask task)
        {
            _db.CreateTask(task.task_name, task.task_notes);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

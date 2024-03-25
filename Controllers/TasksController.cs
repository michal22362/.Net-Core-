using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using lesson2.Models;
using lesson2.Interfaces;

namespace tasks.Controllers;

[ApiController]
[Route("[controller]")]

public class TaskController : ControllerBase
{
    public  ItaskService taskServices;
 
    public TaskController( ItaskService taskServices)
    {
        this.taskServices=taskServices;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Tasks>> Get()
    {
        return taskServices.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult <Tasks>Get(int id)
    {
        var task = taskServices.Get(id);
        if (task == null)
            return NotFound();
        return Ok(task); 
    }

        
    [HttpPost]
    public ActionResult Post(Tasks newTask)
    {
        taskServices.Post(newTask);      
         return CreatedAtAction(nameof(Post), new {id=newTask.Id}, newTask);  
      
    }

    [HttpPut("{id}")]
    public ActionResult Put(Tasks newTask)
    {
        taskServices.Put(newTask);
        return Ok();
    } 

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
       taskServices.Delete(id);
        return Ok();
    } 


}
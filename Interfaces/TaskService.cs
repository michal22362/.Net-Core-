using lesson1.Models;

namespace lesson1.Interfaces;

public interface ITaskService
{
    public List<Tasks> GetAll();

    public Tasks Get(int id);

    public int Post(Tasks newTask);

    public void Put(int id, Tasks newTask);

    public void Delete(int id);
}
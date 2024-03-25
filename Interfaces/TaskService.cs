using lesson2.Models;

namespace lesson2.Interfaces;

  public interface ItaskService
{
      List<Tasks> GetAll();

      Tasks Get(int id);
      void Post(Tasks newTask);      
      void Put(Tasks newTask);
      void Delete(int id);
      int Count {get;}
}
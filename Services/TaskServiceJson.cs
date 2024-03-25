using lesson2.Models;
using lesson2.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;


namespace lesson2.Services
{
    public class TaskService : ItaskService
    {
        List<Tasks> tasks { get; }
        private string filePath;
        public TaskService(IWebHostEnvironment webHost)
        {
            this.filePath = Path.Combine(webHost.ContentRootPath, "Data", "tasks.json");
            using (var jsonFile = File.OpenText(filePath))
            {
                tasks = JsonSerializer.Deserialize<List<Tasks>>(jsonFile.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        private void saveToFile()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(tasks));
        }
        public List<Tasks> GetAll() => tasks;

        public Tasks Get(int id) => tasks.FirstOrDefault(t => t.Id == id);

        public void Post(Tasks task)
        {
            task.Id = tasks.Count() + 1;
            tasks.Add(task);
            saveToFile();
        }

        public void Delete(int id)
        {
            var task = Get(id);
            if (task is null)
                return;

            tasks.Remove(task);
            saveToFile();
        }

        public void Put(Tasks task)
        {
            var index = tasks.FindIndex(t => t.Id == task.Id);
            if (index == -1)
                return;

            tasks[index] = task;
            saveToFile();
        }

        public int Count => tasks.Count();
    }
}
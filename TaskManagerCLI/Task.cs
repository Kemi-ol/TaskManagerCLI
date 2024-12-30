// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCLI
{
    public class Task
    {
        public int Id { get; set; }
        public string MyGoalDescription {  get; set; } = string.Empty;
        public DateTime EntryDate { get; set; } 
        public string? DueDate { get; set; } 
        public bool IsCompleted { get; set; } = false;
    }
}
 
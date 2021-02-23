using System;
using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Task
    {
        public long Id { get; set; }
        public string TaskNumber { get; set; }
        public DateTime DateTime { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
    }
}
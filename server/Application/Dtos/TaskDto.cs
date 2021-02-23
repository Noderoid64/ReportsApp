using System;

namespace Application.Dtos
{
    public class TaskDto
    {
        public DateTime dateTime { get; set; }
        public int status { get; set; }
        public string comment { get; set; }
    }
}
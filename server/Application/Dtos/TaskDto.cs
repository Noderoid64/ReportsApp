using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class TaskDto
    {
        public long id { get; set; }
        public string taskNumber { get; set; }
        public DateTime date { get; set; }
        [Required]
        public string status { get; set; }
        public string comment { get; set; }
    }
}
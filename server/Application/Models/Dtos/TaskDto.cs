using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dtos
{
    public class TaskDto
    {
        public long id { get; set; }
        
        [Required]
        public string taskNumber { get; set; }
        
        [Required]
        public string status { get; set; }
        
        [Required]
        public long userId { get; set; }
        
        public DateTime date { get; set; }
        public string comment { get; set; }
        
    }
}
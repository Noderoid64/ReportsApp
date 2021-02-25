using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dtos
{
    public class TaskDto
    {
        public long Id { get; set; }
        
        [Required]
        public string TaskNumber { get; set; }
        
        [Required]
        public string Status { get; set; }
        
        [Required]
        public long UserId { get; set; }
        
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        
    }
}
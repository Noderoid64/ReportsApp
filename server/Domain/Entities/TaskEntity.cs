﻿using System;
using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class TaskEntity
    {
        public long Id { get; set; }
        public string TaskNumber { get; set; }
        public DateTime DateTime { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        
        public UserEntity User { get; set; }
        public long UserId { get; set; }
    }
}
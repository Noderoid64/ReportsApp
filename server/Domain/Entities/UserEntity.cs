﻿using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
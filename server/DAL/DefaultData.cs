using System.Collections.Generic;
using Domain.Entities;

namespace DAL
{
    public static class DefaultData
    {
        public static ICollection<UserEntity> UserEntities =
            new List<UserEntity>()
            {
                new UserEntity()
                {
                    Id = 1,
                    Email = "admin@gmail.com",
                    Password = "admin",
                },
                new UserEntity()
                {
                    Id = 2,
                    Email = "test@gmail.com",
                    Password = "test",
                }
            };
    }
}
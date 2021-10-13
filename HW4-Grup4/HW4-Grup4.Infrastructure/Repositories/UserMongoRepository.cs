﻿using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Infrastructure.Repositories
{
    public class UserMongoRepository : MongoRepository<User>, IUserMongoRepository
    {
        public UserMongoRepository(IMongoDbContext context) : base(context)
        {

        }
    }
}

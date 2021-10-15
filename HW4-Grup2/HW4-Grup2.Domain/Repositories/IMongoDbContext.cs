using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup2.Domain.Repositories
{
    public interface IMongoDbContext
    {
        void Init();
        IMongoDatabase db { get; }
    }
}

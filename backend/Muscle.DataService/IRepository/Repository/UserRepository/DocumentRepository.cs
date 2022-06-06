using Muscle.DataService.Data;
using Muscle.DataService.IRepository.IRepositoryUserDbContext;
using Muscle.Entities.DbSet.DbSetForUserDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.Repository.UserRepository
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(UserDbContext context)
            : base(context)
        {

        }
    }
}

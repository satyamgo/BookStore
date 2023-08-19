using BookStore.Core.Entities.Models;
using BookStore.Repositories.Interface;
using BookStore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Implementation
{
    public class StatusService : Service<Status>, IStatusService
    {
        public StatusService(IRepository<Status> repo) : base(repo)
        {
        }
    }
}

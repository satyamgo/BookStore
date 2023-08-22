using BookStore.Core.Entities;
using BookStore.Core.Entities.Models;
using BookStore.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Implementation
{
    public class ItemRepository : Repository<Bookitem>, IItemRepository
    {
        public ItemRepository(nonstopioContext db):base(db)
        {

        }
        public IEnumerable<Bookitem> getbystatus()
        {
           return _db.Bookitems.Where(x=>x.StatusId==2).ToList();
        }
       
    }
}

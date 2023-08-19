using BookStore.Core.Entities.Models;
using BookStore.Repositories.Implementation;
using BookStore.Repositories.Interface;
using BookStore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Implementation
{
    public class ItemService : Service<Bookitem>, IItemService
    {
        IItemRepository _itemRepo
        {
            get
            {
                return _repo as ItemRepository;
            }
        }
       
        public ItemService(IItemRepository itemRepository):base(itemRepository)
        {
          
        }

        public IEnumerable<Bookitem> getbystatus()
        {
            return _itemRepo.getbystatus();
        }
    }
}

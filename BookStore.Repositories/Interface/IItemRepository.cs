using BookStore.Core.Entities.Models;
using BookStore.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Interface
{
    public interface IItemRepository:IRepository<Bookitem>
    {
        IEnumerable<Bookitem> getbystatus();

    }
}

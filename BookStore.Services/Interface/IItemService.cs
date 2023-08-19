using BookStore.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Interface
{
    public interface IItemService:IService<Bookitem>
    {
        IEnumerable<Bookitem> getbystatus();
    }
}

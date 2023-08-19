using BookStore.Repositories.Interface;
using BookStore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Implementation
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected IRepository<TEntity> _repo;
        public Service(IRepository<TEntity> repo)
        {
            _repo = repo;
        }
        public void Add(TEntity entity)
        {
            _repo.Add(entity);
            _repo.SaveChanges();
        }

        public void Delete(object id)
        {
            _repo.Delete(id);
        }

        public TEntity Find(object id)
        {
            return _repo.Find(id);
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public void Remove(TEntity entity)
        {
            _repo.Remove(entity);
            _repo.SaveChanges();
        }

        public int SaveChanges()
        {
            return _repo.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _repo.Update(entity);
            _repo.SaveChanges();
        }
    }
}

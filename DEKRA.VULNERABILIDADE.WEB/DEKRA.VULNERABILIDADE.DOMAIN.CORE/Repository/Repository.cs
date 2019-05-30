
using DEKRA.VULNERABILIDADE.DOMAIN.CORE.IREPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEKRA.VULNERABILIDADE.DOMAIN.CORE.Repository
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {

        private readonly DEKRA.VULNERABILIDADE.WEB.DATAACCESSLAYER.EntityFrameWork.dbContext _ctx;

        public Repository(DEKRA.VULNERABILIDADE.WEB.DATAACCESSLAYER.EntityFrameWork.dbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key)
        {
            return _ctx.Set<TEntity>().Find(key);
        }

        public void Update(TEntity obj)
        {
            _ctx.Set<TEntity>().Attach(obj);
            _ctx.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();

        }

        public void SaveAll()
        {
            _ctx.SaveChanges();
        }

        public void Add(TEntity obj)
        {
            _ctx.Set<TEntity>().Add(obj);
            _ctx.SaveChanges();
        }

        public void Exclude(Func<TEntity, bool> predicate)
        {
            _ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => _ctx.Set<TEntity>().Remove(del));
        }


        public void Dispose()
        {
            _ctx.Dispose();
        }

    }
}

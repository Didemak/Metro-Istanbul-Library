//using DataAccessLayer.Abstract;
//using DataAccessLayer.Concrete;
//using DataAccessLayer.Concrete.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccessLayer.UnitOfWork
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly Context _context;
//        public UnitOfWork()
//        {
//            _context = new Context();
//        }
//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        //public IRepository<T> GetRepository<T>() where T : class
//        //{
//        //    //return new GenericRepository<T>(_context);
//        //}

//        public int SaveChanges()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IService<T> where T : class
    {
        void Add(T t);
        T Get(object id);
        void Update(T t);
        void Delete(T t);
        IList<T> GetAll();
        T GetById(params object[] id);
        void Commit();


    }
}
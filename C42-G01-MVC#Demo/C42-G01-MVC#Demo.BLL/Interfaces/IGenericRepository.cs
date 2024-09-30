using C42_G01_MVC_Demo.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_MVC_Demo.BLL.Interfaces
{
    public interface IGenericRepository <T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}

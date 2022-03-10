using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IPeopleService
    {
        List<People> GetList(string p);
        List<People> GetLisByID(int id);
        void PeopleAdd(People people);
        void PeopleDelete(People people);
        void PeopleUpdate(People people);
        People GetByID(int id);

    }
}

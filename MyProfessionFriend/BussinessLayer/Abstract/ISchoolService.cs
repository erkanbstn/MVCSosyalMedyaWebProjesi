using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ISchoolService
    {
        List<School> GetList();
        void SchoolAdd(School school);
        School GetByID(int id);
        void SchoolDelete(School school);
        void SchoolUpdate(School school);
    }
}

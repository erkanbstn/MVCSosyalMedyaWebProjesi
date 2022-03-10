using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class SchoolManager : ISchoolService
    {
        ISchoolDal _schoolDal;

        public SchoolManager(ISchoolDal schoolDal)
        {
            _schoolDal = schoolDal;
        }

        public School GetByID(int id)
        {
            return _schoolDal.Get(x => x.SchoolID == id);

        }

        public List<School> GetList()
        {
            return _schoolDal.List();
        }

        public void SchoolAdd(School school)
        {
            _schoolDal.Insert(school);
        }

        public void SchoolDelete(School school)
        {
            _schoolDal.Delete(school);
        }

        public void SchoolUpdate(School school)
        {
            _schoolDal.Update(school);
        }
    }
}

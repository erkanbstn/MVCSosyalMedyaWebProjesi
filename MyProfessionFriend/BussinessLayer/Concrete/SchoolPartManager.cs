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
    public class SchoolPartManager : ISchoolPartService
    {
        ISchoolPartDal _schoolpartDal;

        public SchoolPartManager(ISchoolPartDal schoolpartDal)
        {
            _schoolpartDal = schoolpartDal;
        }

        public SchoolPart GetByID(int id)
        {
            return _schoolpartDal.Get(x => x.ScpartID == id);

        }

        public List<SchoolPart> GetList()
        {
            return _schoolpartDal.List();
        }

        public List<SchoolPart> GetListBySchoolID(int id)
        {
            return _schoolpartDal.List(x => x.SchoolID == id);
        }

        public void SchoolPartAdd(SchoolPart schoolpart)
        {
            _schoolpartDal.Insert(schoolpart);
        }

        public void SchoolPartDelete(SchoolPart schoolpart)
        {
            
            _schoolpartDal.Delete(schoolpart);
        }

        public void SchoolPartUpdate(SchoolPart schoolpart)
        {
            _schoolpartDal.Update(schoolpart);
        }
    }
}

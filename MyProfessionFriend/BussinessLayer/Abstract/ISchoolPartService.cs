using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ISchoolPartService
    {
        List<SchoolPart> GetList();
        List<SchoolPart> GetListBySchoolID(int id);
        void SchoolPartAdd(SchoolPart schoolpart);
        SchoolPart GetByID(int id);
        void SchoolPartDelete(SchoolPart schoolpart);
        void SchoolPartUpdate(SchoolPart schoolpart);
    }
}

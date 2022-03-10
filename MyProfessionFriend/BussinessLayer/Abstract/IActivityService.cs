using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IActivityService
    {
        List<Activity> GetList();
        List<Activity> GetListByPeople(int id);
        List<Activity> GetListByPeopleID(int id);
        void ActivityAdd(Activity activity);
        Activity GetByID(int id);
        void ActivityDelete(Activity acitivity);
        void ActivityUpdate(Activity activity);
    }
}

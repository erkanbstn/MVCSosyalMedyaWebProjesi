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

    public class ActivityManager : IActivityService
    {
        IActivityDal _activityDal;

        public ActivityManager(IActivityDal activityDal)
        {
            _activityDal = activityDal;
        }

        public void ActivityAdd(Activity activity)
        {
            _activityDal.Insert(activity);
        }

        
        public void ActivityDelete(Activity acitivity)
        {
            _activityDal.Delete(acitivity);
        }

        public void ActivityUpdate(Activity activity)
        {
            _activityDal.Update(activity);
        }

        public Activity GetByID(int id)
        {
            return _activityDal.Get(x => x.ActivityID == id);
        }

        public List<Activity> GetList()
        {
            return _activityDal.List();
        }

        public List<Activity> GetListByPeople(int id)
        {
            return _activityDal.List(x => x.PeopleID == id);
        }

        public List<Activity> GetListByPeopleID(int id)
        {
            return _activityDal.List(x => x.PeopleID == id);
        }

        //public void ActivityAddBL(Activity p)
        //{
        //    if (p.ActivityName == "" || p.ActivityName.Length <= 3)
        //    {
        //        //hata
        //    }
        //    else
        //    {
        //        _activityDal.Insert(p);
        //    }
        //}
    }
}

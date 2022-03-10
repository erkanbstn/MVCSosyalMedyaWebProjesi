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
    public class GroupManager : IGroupService
    {
        IGroupDal _groupDal;
        public GroupManager(IGroupDal groupDal)
        {
            _groupDal = groupDal;
        }

        public void GroupAdd(Group group)
        {
            _groupDal.Insert(group);
        }

        public void GroupDelete(Group group)
        {
            _groupDal.Delete(group);
        }

        public void GroupUpdate(Group group)
        {
            _groupDal.Update(group);
        }

        public Group GetByID(int id)
        {
            return _groupDal.Get(x => x.GroupID == id);
        }

        public List<Group> GetList()
        {
            return _groupDal.List();
        }
    }
}

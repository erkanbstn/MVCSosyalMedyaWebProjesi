using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IGroupService
    {
        List<Group> GetList();
        void GroupAdd(Group group);
        Group GetByID(int id);
        void GroupDelete(Group group);
        void GroupUpdate(Group group);
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IRequestFriendService
    {
        List<FriendRequest> GetList();
        List<FriendRequest> GetListByPeople(int id);
        void FriendReqAdd(FriendRequest friendreq);
        void FriendReqDelete(FriendRequest friendreq);
        FriendRequest GetById(int id);
    }
}

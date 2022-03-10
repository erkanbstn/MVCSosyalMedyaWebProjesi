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
   public class FriendRequestManager : IRequestFriendService
    {
        IRequestFriendDal _requestfriendDal;

        public FriendRequestManager(IRequestFriendDal requestfriendDal)
        {
            _requestfriendDal = requestfriendDal;
        }

        public void FriendReqAdd(FriendRequest friendreq)
        {
            throw new NotImplementedException();
        }

        public void FriendReqDelete(FriendRequest friendreq)
        {
            throw new NotImplementedException();
        }

        public FriendRequest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<FriendRequest> GetList()
        {
            throw new NotImplementedException();
        }

        public List<FriendRequest> GetListByPeople(int id)
        {
            throw new NotImplementedException();
        }
    }
}

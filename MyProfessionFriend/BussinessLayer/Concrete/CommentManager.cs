using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment Comment)
        {
            _commentDal.Insert(Comment);
        }

        public void CommentDelete(Comment Comment)
        {
            _commentDal.Delete(Comment);
        }

        public void CommentUpdate(Comment Comment)
        {
            _commentDal.Update(Comment);
        }

        public List<Comment> GetListByMediaID(int id)
        {
            return _commentDal.List(x => x.MediaID == id);
        }

        public Comment GetById(int id)
        {
            return _commentDal.Get(x => x.CommentID == id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public List<Comment> GetListByPeople(int id)
        {
            return _commentDal.List(x => x.PeopleID == id);
        }
    }
}

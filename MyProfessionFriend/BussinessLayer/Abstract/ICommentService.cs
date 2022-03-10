using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList();
        List<Comment> GetListByMediaID(int id);
        List<Comment> GetListByPeople(int id);
        void CommentAdd(Comment comment);
        void CommentDelete(Comment comment);
        void CommentUpdate(Comment comment);
        Comment GetById(int id);
    }
}

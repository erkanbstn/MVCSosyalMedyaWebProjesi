using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ITagService
    {
        List<Tag> GetList();
        List<Tag> GetListByMediaID(int id);
        void TagAdd(Tag tag);
        Tag GetByID(int id);
        void TagDelete(Tag tag);
        void TagUpdate(Tag tag);
    }
}

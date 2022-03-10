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
    public class TagManager : ITagService
    {
        ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public Tag GetByID(int id)
        {
            return _tagDal.Get(x => x.TagId == id);
        }

        public List<Tag> GetListByMediaID(int id)
        {
            return _tagDal.List(x => x.MediaID == id);
        }

        public List<Tag> GetList()
        {
            return _tagDal.List();
        }

        public void TagAdd(Tag tag)
        {
            _tagDal.Insert(tag);
        }

        public void TagDelete(Tag tag)
        {
            _tagDal.Delete(tag);
        }

        public void TagUpdate(Tag tag)
        {
            _tagDal.Update(tag);
        }
    }
}

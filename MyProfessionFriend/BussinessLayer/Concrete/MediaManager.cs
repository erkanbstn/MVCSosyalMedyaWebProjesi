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
    
    public class MediaManager : IMediaService
    {
        IMediaDal _mediaDal;

        public MediaManager(IMediaDal mediaDal)
        {
            _mediaDal = mediaDal;
        }

        public Media GetByID(int id)
        {
            return _mediaDal.Get(x => x.MediaID == id);
        }

        public List<Media> GetList()
        {
            return _mediaDal.List();
        }

        public List<Media> GetListByPeople(int id)
        {
            return _mediaDal.List(x => x.PeopleID == id);
        }

        public List<Media> GetListByPeopleID(int id)
        {
            return _mediaDal.List(x => x.PeopleID == id);
        }

        public void MediaAdd(Media media)
        {
            _mediaDal.Insert(media);
        }

        public void MediaDelete(Media media)
        {
            _mediaDal.Delete(media);
        }

        public void MediaUpdate(Media media)
        {
            _mediaDal.Update(media);
        }
    }
}

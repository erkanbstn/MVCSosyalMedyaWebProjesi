using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IMediaService
    {
        List<Media> GetList();
        List<Media> GetListByPeople(int id);
        List<Media> GetListByPeopleID(int id);
        void MediaAdd(Media media);
        Media GetByID(int id);
        void MediaDelete(Media media);
        void MediaUpdate(Media media);
    }
}

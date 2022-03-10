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
    public class PeopleManager:IPeopleService
    {
        IPeopleDal _peopleDal;

        public PeopleManager(IPeopleDal peopleDal)
        {
            _peopleDal = peopleDal;
        }

        //GenericRepository<People> repo = new GenericRepository<People>();
        //public List<People> GetAllBL()
        //{
        //    return repo.List();
        //}

        public People GetByID(int id)
        {
            return _peopleDal.Get(x => x.PeopleID == id);
        }

        public List<People> GetLisByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<People> GetList(string p)
        {
            return _peopleDal.List(x=>x.PeopleName.Contains(p));
        }

        public List<People> GetList()
        {
            return _peopleDal.List();
        }

        public void PeopleAdd(People people)
        {
            _peopleDal.Insert(people);
        }

        //public void PeopleAddBL(People p)
        //{
        //    if(p.PeopleName==" " || p.PeopleName.Length<=3 || p.PeopleName.Length>= 51)
        //    {
        //        //hata
        //    }
        //    else
        //    {
        //        repo.Insert(p);
        //    }
        //}

        public void PeopleDelete(People people)
        {
            _peopleDal.Delete(people);
        }

        public void PeopleUpdate(People people)
        {
            _peopleDal.Update(people);
        }
    }
}

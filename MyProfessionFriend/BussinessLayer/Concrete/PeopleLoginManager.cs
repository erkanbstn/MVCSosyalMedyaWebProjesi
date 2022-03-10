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
    public class PeopleLoginManager :IPeopleLoginService
    {
        IPeopleDal _peopleDal;

        public PeopleLoginManager(IPeopleDal peopleDal)
        {
            _peopleDal = peopleDal;
        }

        public People GetPeople(string username, string password)
        {
            return _peopleDal.Get(x => x.PeopleMail == username && x.PeoplePass == password);
        }
    }
}

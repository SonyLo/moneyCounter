using MoneyCounterSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyCounterSite.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetUser(string id)
        {
            User user = new User();
            Family fam = new Family();
            
            
            
            ViewBag.FamilyName = fam.getNameFamily(id);
            if (!String.IsNullOrEmpty(ViewBag.FamilyName))
            {
                List<User> familyMembers = user.GetFamilyMembers(id);
                ViewBag.FamilyMember = familyMembers;
            }
            else
            {
                ViewBag.UserName = user.getUserById(id);
            }
            ViewBag.UserID = id;
            


            return View("Index");
        }
        ///user/getuser?id=1
        ///

        [HttpPost]
        public string CreateFamily(Family family)
        {
            Family  fam = new Family();
            User user = new User();
            

            string UserNameForAdd = user.getUserById(family.idUserAdd);

            if(family.idUserAdd == family.idUserInit)
            {
                return "Это ваш идентификатор";
            }

            if (String.IsNullOrEmpty(UserNameForAdd))
            {
                return "Пользователя с идентификатором "+ family.idUserAdd + " не существует" ;
            }

            int idFamily = fam.getIdFamily(family.idUserInit);

            if(idFamily == -1)
            {
                idFamily = fam.CreateFamily(family);
                if (idFamily != -1)
                {
                    fam.AddUserInFamily(idFamily, family.idUserAdd);
                    fam.AddUserInFamily(idFamily, family.idUserInit);

                }
            }



            return "good";

            //return View("Index");
        }

    }
}
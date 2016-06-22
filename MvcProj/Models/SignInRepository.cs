using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProj.Models
{
    public class SignInRepository: ISignInRepository
    {
        public bool verifier(User u)
        {
            using (myDatabaseEntities2 db = new myDatabaseEntities2())
            {
                //var q = (from x in db.Users
                //        where x.rollNumber == u.rollNumber && x.password == u.password
                //            select x).ToList();

                //if(q.Count == 1)
                //{
                    System.Web.HttpContext.Current.Session["uid"]=u.rollNumber;
                    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
        }

        public bool saveSignUp(User u)
        {
            using (myDatabaseEntities2 db = new myDatabaseEntities2())
            {
                var q = (from x in db.Users
                        where x.rollNumber == u.rollNumber
                        select x).First();
                if(q == null)
                { 
                    db.Users.Add(u);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM
{
    public class MainClass
    {
        
        //get validation user
        public static bool Isvaliuser(string username, string password)
        {
            var db = new RMEntities();
            foreach (var item in db.users)
            {
                if (item.username == username && item.upass == password)
                {
                    USER = item.uName;
                    return true;
                    
                }
            }
            return false;

        }

        //get user login Name
        public static string user;
        public static string USER
        {
            get { return user; }
            set { user = value; }

        }


    }
}

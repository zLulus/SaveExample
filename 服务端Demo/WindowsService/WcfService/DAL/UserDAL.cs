using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WcfService.DAL
{
    public class UserDAL
    {
        public List<User> users=new List<User>(); 
        public UserDAL()
        {
            
        }


        public List<User> GetUsers()
        {
            using (TravelMobileTestEntities entity = new TravelMobileTestEntities())
            {
                return (from c in entity.Users
                    select c).ToList();

            }
        }

        internal void AddUser(string id, string phoneNum, string name, string passWord)
        {
            User u=new User();
            u.id = int.Parse(id);
            u.name = name;
            u.phoneNum = phoneNum;
            u.password = passWord;
            
            using (TravelMobileTestEntities entity = new TravelMobileTestEntities())
            {
                try
                {
                    entity.Users.Add(u);
                    entity.SaveChanges();
                }
                catch (Exception ex)
                {

                }

            }
        }
    }
}

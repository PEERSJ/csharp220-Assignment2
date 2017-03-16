using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

//  Jeff Peerson
//  csharp220_Assignment2  

namespace csharp220_Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User
            {
                Name = "Dave",
                Password = "hello"
            });

            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //create a new list called userPswd and select the passowrd from itmes in the source list 
            //where the item.password = 'hello' 
            var userPswd = from item in users
            //IEnumerable<string> userPswd = from item in users
                 where item.Password == "hello"
                 select item.Password;

            //for each item in userPswd, put value into string variable called pswd and write it out
            foreach (string pswd in userPswd)
            { 
                Console.WriteLine(pswd);
            }

            //userInfo.ToList().ForEach(p => Console.WriteLine(p));



   
            /////////////////////////////////////////////////////////////////////////////////
            //Delete passwords that are lower-case Version of user name, 
            //then display remaining user names to show it has been deleted.


            var passwordToRemove = from item in users
                               //IEnumerable<string> userPswd = from item in users
                           where item.Password == item.Name.ToLower()
                           select item.Password;

            //for each item in userPswd, put value into string variable called pswd and write it out
            foreach (string pswd in passwordToRemove)
            {
                Console.WriteLine(pswd);
                users.RemoveAll(x => x.Password == pswd);
                break;
            }

            var userName = from item in users
                           select item.Name;

            //display what names are left in the list following the removeall above
            foreach (string x in userName)
            {
                Console.WriteLine(x);
            }




            ///////////////////////////////////////////////////////////////////////////////////
            //remove first user record whose password = "hello"
            users.Remove(users.First(x => x.Password == "hello"));

            //display what names are left in the list following the RemoveAll above
            foreach (string x in userName)
            {
                Console.WriteLine(x);
            }

        }
    }
}

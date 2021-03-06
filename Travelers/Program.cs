using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Travelers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //TODO update the "UserServiceFindUser" function to return developers that work at the specified company only
            var developersAtAwesomeSauceInc = UserServiceFindUser(null, "developer", "awesome sauce inc.");
            PrintOutResults("Developers at Awesome Sauce Inc.", developersAtAwesomeSauceInc);

            //TODO update the "UserServiceFindUser" function to return all people that work at the specified company
            var peopleAtPandance = UserServiceFindUser(null, null, "pandance");
            PrintOutResults("People at Pandance", peopleAtPandance);

            //TODO update the "UserServiceFindUser" function to return all developers that work at the specified company and have the last name of Smith
            var developersWithLastNameOfSmithWhoWorkAtAwesomeSauceInc = UserServiceFindUser("Smith", "developer", "awesome sauce inc.");
            PrintOutResults("Developers With Last Name of Smith Who Work at Awesome Sauce Inc.", developersWithLastNameOfSmithWhoWorkAtAwesomeSauceInc);
        }

        private static List<User> UserServiceFindUser(string name, string job, string company)
        {
            //TODO update logic for this function to user the params to return back the correct users
            var userList = UserServiceGetAllUsers();
            var lastName = "Smith";
            List<User> overallResult = new List<User>();

            foreach (User person in userList)
            {
                if (name == null && job != null & company != null) //scenario 1
                {
                    List<User> result1 =
                        (from u in userList
                         where (u.job == job && u.company == company)
                         select u).ToList();

                    overallResult = result1;
                }

                else

                if (name == null && job == null && company != null) //scenario 2
                {
                    List<User> result2 =
                        (from u in userList
                         where (u.company == company)
                         select u).ToList();

                    overallResult = result2;
                }

                else //scenario 3
                {
                    List<User> result3 =
                        (from u in userList
                         where (u.name.Contains(lastName) && u.job == job && u.company == company)
                         select u).ToList();

                    overallResult = result3;
                }
            }
            
            return overallResult;
        }

        private static List<User> UserServiceGetAllUsers()
        {
            return new List<User> {
                new User {id=1,name="Bob Smith",job="developer",company="awesome sauce inc."},
                new User {id=2,name="Barb Tillo",job="developer",company="awesome sauce inc."},
                new User {id=3,name="May Axix",job="product owner",company="pandance"},
                new User {id=4,name="Jane Heartily",job="developer",company="awesome sauce inc."},
                new User {id=5,name="Jim Kronn",job="developer",company="pandance"},
                new User {id=6,name="Kelly Cruther",job="developer",company="pandance"},
                new User {id=7,name="Mark Smith",job="product owner",company="awesome sauce inc."},
            };
        }

        private static void PrintOutResults(string message, List<User> results)
        {
            Console.WriteLine();
            Console.WriteLine("Results: " + message);
            foreach (var thing in results)
            {
                Console.WriteLine(string.Format("ID: {0}, Name: {1}, Job: {2}, Company: {3}", thing.id, thing.name, thing.job, thing.company));
            }
        }

        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string job { get; set; }
            public string company { get; set; }
        }
    }
}

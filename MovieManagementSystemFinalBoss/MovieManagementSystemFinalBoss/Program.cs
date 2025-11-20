using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystemFinalBoss
{
    class Movies
    {
        //fieldss
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public bool IsRented { get; set; }

        //constructor
        public Movies(string title, string genre, int year, bool isRented = false)
        {
            Title = title;
            Genre = genre;
            Year = year;
            IsRented = isRented;
        }
        public virtual void MovieDetails()
        {
            Console.Write("movie title: ");
            string title = Console.ReadLine();
            Title = title;
            Console.Write("movie genre: ");
            string genre = Console.ReadLine();
            Genre = genre;
            Console.Write("release year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Year = year;
        }
        public Movies()
        {
            MovieDetails();
        }

        //output
        public override string ToString()
        {
            return $"movie title: {Title}\nmovie genre: {Genre}\nmovie Year: {Year}";
        }
    }

    //series class UNDER CONSTRUCTION!
    /*class Series : Movies
    {
        public string LeadAct { get; set; }

        public override void MovieDetails()
        {
            Console.Write("series title: ");
            string seriesTitle = Console.ReadLine();
            Title = seriesTitle;
            Console.Write("lead act: ");
            string mainCharacter = Console.ReadLine();
            LeadAct = mainCharacter;
        }
        public Series()
        {
            MovieDetails();
        }
    }*/

    //Member class
    class Member
    {
        public string Name { get; set; }
        public enum Login { asUser = 1, asGuest = 2}    //enum: members can login as user or guest
        public Login Privilege { get; set; }    //property with enum type

        //constructor
        public Member()
        {
            Console.Write("enter name: ");
            string name = Console.ReadLine();
            Name = name;
        }

        public List<Movies> movieList = new List<Movies>();

        //what can members do?
        public Movies AddMovie()
        {
            Movies movie = new Movies();
            movieList.Add(movie);

            return movie;
        }
        public void ShowMovies()
        {
            foreach (var item in movieList)
            {
                Console.WriteLine(item.Title);
            }
        }
        public void RentMovies()
        {
            if (Privilege == Login.asUser)  //only users can rent a movie
            {
                bool matchingTitle = false;
                Console.Write("what movie do you want to rent: ");
                string movieTitle = Console.ReadLine();
                foreach (var item in movieList)
                {
                    if (item.Title == movieTitle && item.IsRented == false)
                    {
                        Console.WriteLine($"{movieTitle} is available to rent!");
                        item.IsRented = true;
                        matchingTitle = true;
                    }
                    else if (item.Title == movieTitle && item.IsRented == true)
                    {
                        Console.WriteLine($"{movieTitle} has already been rented by you!");
                        matchingTitle = true;
                    }
                }
                if (!matchingTitle)
                {
                    Console.WriteLine($"{movieTitle} NOT FOUND!");
                }
            }
            else
            {
                Console.WriteLine("sorry, guest cannot rent a movie!");
            }
        }
        public void LoginMessage()
        {
            if (Privilege == Login.asUser)
            {
                Console.WriteLine($"welcome, {Name}");
            }
            else
            {
                Console.WriteLine($"{Name} logged in as guest!");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Member user;

            Console.Write("1. user\n2. guest\nselect login type: ");
            int login = Convert.ToInt32( Console.ReadLine() );

            user = NewMember(login);

            Console.Write("1. add movie \n2 show movies\n3 rent a movie" +
                          "\n0. log out\nselect action: ");
            int press = Convert.ToInt32(Console.ReadLine());

            while (press != 0)
            {
                if (press == 1) { user.AddMovie(); }
                else if (press == 2) { user.ShowMovies(); }
                else if (press == 3) { user.RentMovies(); }

                Console.Write("select operation: ");
                press = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"{user.Name} logging out...");

            Console.ReadLine();
        }

        //creates members
        static Member NewMember(int loginPrivilege)
        {
            Member member = new Member();

            if (loginPrivilege == (int)Member.Login.asUser)
            {
                member.Privilege = Member.Login.asUser;
            }
            else if (loginPrivilege == (int)Member.Login.asGuest)
            {
                member.Privilege = Member.Login.asGuest;
            }
            else
            {
                Console.WriteLine("select correct login privilege");
            }

            member.LoginMessage();
            return member;
        }
    }
}

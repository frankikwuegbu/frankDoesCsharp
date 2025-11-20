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

    class Series: Movies
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
    }

    abstract class Member
    {
        public string Name { get; set; }

        public Member(string name) { Name = name; }

        public List<Movies> movieList = new List<Movies>();
        public abstract Movies AddMovie();
        
        public abstract void ShowMovies();
        public abstract void LoginMessage();
    }

    class Guest : Member
    {
        public Guest(string name) : base(name) { }

        public override Movies AddMovie()
        {
            Movies movie = new Movies();
            movieList.Add(movie);
            Console.WriteLine(movie);

            return movie;
        }

        public override void ShowMovies()
        {
            foreach (var item in movieList)
            {
                Console.WriteLine(item.Title);
            }
        }

        public override void LoginMessage()
        {
            Console.WriteLine($"{Name} logged in as guest!");
        }
    }

    class User : Member
    {
        public User(string name) : base(name) { }
        public override Movies AddMovie()
        {
            Movies movie = new Movies();
            movieList.Add(movie);
            Console.WriteLine("movie added!\n");

            return movie;
        }

        public override void ShowMovies()
        {
            foreach (var item in movieList)
            {
                Console.WriteLine(item.Title);
            }
        }

        public void RentMovie()
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
        public override void LoginMessage()
        {
            Console.WriteLine($"welcome, {Name}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic user;

            Console.Write("1. user\n2. guest\nselect login type: ");
            int login = Convert.ToInt32( Console.ReadLine() );

            if (login == 1) { user = NewUser(); } else { user = NewGuest(); }

            Console.Write("1. add movie \n2 show movies\n3 rent a movie" +
                          "\nselect action: ");
            int press = Convert.ToInt32(Console.ReadLine());

            while (press != 0)
            {
                if (press == 1) { user.AddMovie(); }
                else if (press == 2) { user.ShowMovies(); }
                else if (press == 3) { user.RentMovie(); }

                Console.Write("select operation: ");
                press = Convert.ToInt32(Console.ReadLine());
            }

            Console.ReadLine();
        }

        static User NewUser()
        {
            Console.Write("username: ");
            string userName = Console.ReadLine();

            var user = new User(userName);
            user.LoginMessage();
            //Console.WriteLine(user);
            return user;
        }

        static Guest NewGuest()
        {
            Console.Write("guest name: ");
            string guestName = Console.ReadLine();

            var guest = new Guest(guestName);
            guest.LoginMessage();
            //Console.WriteLine(user);
            return guest;
        }
    }
}

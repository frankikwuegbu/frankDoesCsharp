using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace tryingthings
{
    //inheritance and polymorphism
    class People
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public People(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void SayMyName()
        {
            Console.WriteLine($"my name is {Name}");
        }

        public void HowOldAreYou()
        {
            Console.WriteLine($"i am {Age} years old");
        }

         //the contents of a virtual class can be overwritten in a child class
        //this is called polymorphism
        public virtual void Communicate()
        {
            Console.WriteLine("i can speak!");
        }
    }

    class Registration : People
    {
        public int PhoneNumber { get; set; }
        public string Language { get; set; }
        public Registration (string name, int age, int phoneNumber, string language) : base(name, age)
        {
            PhoneNumber = phoneNumber;
            Language = language;
        }

        public void CallMe()
        {
            Console.WriteLine($"here is my number: {PhoneNumber}");
        }

        //overriding method from parent class
        public override void Communicate()
        {
            Console.WriteLine($"i speak {Language}");
        }
    }

     //abstract classes cannot have object instances
    //its "contents" can only be accessed from an inheriting class
    abstract class Animals
    {
        public string Name { get; set; }

        //the body of an abstract method is defined in the inheriting class
        public abstract void Sound();

        //abstract classes can have regular methods
        public void Sleep()
        {
            Console.WriteLine("zzzzzzz");
        }
    }

    class Dog: Animals
    {
        //overriding abstract method
        public override void Sound()
        {
            Console.WriteLine("bark!");
        }
    }

    //Interface
    interface ICar
    {
        string Type { get; set; }
        void Model();
    }

    interface ICarinterior
    {
        void CarSeats();
    }

    //a class can "inherit" an Interface
    //the inheriting class MUST have all properties and methods from the Interface
    //one class can "inherit" multiple interfaces
    class Toyota : ICar, ICarinterior
    {
        public string Type { get; set; }
        public void Model()
        {
            Console.WriteLine($"Model: {Type}");
        }

        public void CarSeats()
        {
            Console.WriteLine("four seater vehicle");
        }

        //inheriting class can also have its own unique methods (and/or properties)
        public void NitroSpeed()
        {
            Console.WriteLine("zoooom!");
        }
    }

    //enum
    enum Login { AsUser, AsGuest }

    //enum in a class
    class Pc
    {
        public enum Brands
        {
            dell, hp, macbook
        }

        public Brands Type { get; set; }

        public void Something() { }

        public void Anotherthing(int random)
        {
            if (random == (int)Brands.dell)
            {
                Console.WriteLine("only dell laptops can do this");
            }
            else
            {
                Console.WriteLine("you are not permitted to do this");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Registration randomPeople = new Registration(phoneNumber:234, name: "trevor", age:60, language: "French");
            randomPeople.SayMyName();
            randomPeople.HowOldAreYou();
            randomPeople.CallMe();
            randomPeople.Communicate();

            People randomPeople2 = new People("patrick", 30);
            randomPeople2.SayMyName();

            Dog bullDog = new Dog();
            bullDog.Name = "bingo";
            bullDog.Sound();
            bullDog.Sleep();

            ICar car = new Toyota();
            car.Type = "Camry";
            //car.NitroBoost();   //car cannot access NitroSpeed() because of its type

            Toyota car2 = new Toyota();
            car2.NitroSpeed();      //NitroSpeed() is specific to objects of class-type Toyota
            car2.CarSeats();
            Console.WriteLine(car.Type);

            //enum => line 123
            int number = 1;
            if (number == (int)Login.AsUser)
            {
                Console.WriteLine("logged in as user");
            }
            else
            {
                Console.WriteLine("logged in as guest");
            }

            Pc newPc = new Pc();
            newPc.Type = Pc.Brands.dell;
            Console.WriteLine(newPc.Type);  //output: dell

            Console.Write("number: ");
            int result = Convert.ToInt32(Console.ReadLine());

            newPc.Anotherthing(result);

            Console.ReadLine();
        }
    }
}
using System;

namespace learningDependencies
{
    public class Soldier
    {
        public Gun Gun { get; set; }
        public Knife Knife { get; set; }


        public void GoToWar()
        {
            Gun.Use();
            Knife.Use();
            Console.WriteLine("the war has been won!");
        }
    }

    public class Gun
    {
        public void Use()
        {
            Console.WriteLine("gunning people...");
        }
    }

    public class Knife
    {
        public void Use()
        {
            Console.WriteLine("knifing people...");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //for setter dependency injection, the dependencies are created outside like so...
            Gun gun = new Gun();
            Knife knife = new Knife();
            Soldier soldier = new Soldier
            {
                //injecting the dependencies
                Gun = gun,
                Knife = knife
            };

            soldier.GoToWar();

            Console.ReadLine();
        }
    }
}

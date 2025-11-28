using System;

namespace learningDependencies
{
    public class Soldier
    {
        private readonly Gun _gun;
        private readonly Knife _knife;

        //constructor dependency injection
        public Soldier (Gun gun, Knife knife)
        {
            _gun = gun;
            _knife = knife;
        }

        public void GoToWar()
        {
            _gun.Use();
            _knife.Use();
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
            Gun gun = new Gun();
            Knife knife = new Knife();
            Soldier soldier = new Soldier(gun, knife);

            soldier.GoToWar();

            Console.ReadLine();
        }
    }
}

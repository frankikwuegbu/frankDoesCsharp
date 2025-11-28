using System;

namespace learningDependencies
{
    public interface IArsenal
    {
        void UseGun(Gun gun);
        void UseKnife(Knife knife);
    }
    public class Soldier: IArsenal
    {
        private Gun _gun;
        private Knife _knife;

        public void GoToWar()
        {
            _gun.Use();
            _knife.Use();
            Console.WriteLine("the war has been won!");
        }

        public void UseGun(Gun gun)
        {
            _gun = gun;
        }

        public void UseKnife(Knife knife)
        {
            _knife = knife;
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
            Soldier soldier = new Soldier();

            soldier.UseGun(gun);
            soldier.UseKnife(knife);

            soldier.GoToWar();

            Console.ReadLine();
        }
    }
}

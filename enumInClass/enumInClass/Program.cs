using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enumInClass
{
    class Member
    {
        public string Name { get; set; }

        public enum Login { asUser = 1, asGuest = 2 }

        public Login Privilege { get; set; }

        public Member(string name, Login privilege = Member.Login.asGuest)
        {
            Name = name;
            Privilege = privilege;
        }

        public void Rent()
        {
            if (Privilege == Login.asUser)
            {
                Console.WriteLine("user can rent");
            }
            else
            {
                Console.WriteLine("guest_user cannot rent movie!");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("LOGIN\n1. as user\n2. as guest\nselect operation: ");
            int login = Convert.ToInt32(Console.ReadLine());

            Member user1 = NewMember(login);
            Console.WriteLine($"{user1.Name} logged in {user1.Privilege}");
            user1.Rent();

            Console.ReadLine();
        }

        static Member NewMember(int privilegeLevel)
        {
            Member member = new Member("chad");
            if (privilegeLevel == (int)Member.Login.asUser)
            {
                member.Privilege = Member.Login.asUser;
            }
            else if (privilegeLevel == (int)Member.Login.asGuest)
            {
                member.Privilege = Member.Login.asGuest;
            }

            return member;
        }
    }
}

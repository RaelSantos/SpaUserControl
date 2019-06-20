using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using SpaUserControl.Infraestruture.Repositories;
using System;
using System.Globalization;

namespace ConsoleApplicationExemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo c = new CultureInfo("pt-BR");
            var user = new User("Rael santos martins", "raelsantosmartins@gmail.com");
            user.SetPassword("raelsantos", "raelsantos");
            user.Validate();

            /*
            using (IUserRepository userRap = new UserRepository())
            {
                userRap.Create(user);
            }

            using (IUserRepository userRap = new UserRepository())
            {
               var e = userRap.Get("raelsantosmartins@gmail.com");
                Console.WriteLine(e.Email);
            }*/

            
            Console.ReadKey();
        }
    }
}

using Microsoft.Practices.Unity;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Startup;
using System;
using System.Globalization;
using System.Threading;

namespace SpaUserControl.Spammer
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo c = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = c;
            Thread.CurrentThread.CurrentUICulture = c;

            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IUserService>();

            try
            {
                service.Register("Rael", "raelsantosmartins@gmail.com", "neguinho_370", "neguinho_370");
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                service.Dispose();
            }
        }
    }
}

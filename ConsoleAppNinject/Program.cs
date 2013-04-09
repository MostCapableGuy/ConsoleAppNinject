using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppNinject.Core.Interfaces.Service;
using ConsoleAppNinject.Core.Interfaces.Validation;
using ConsoleAppNinject.Core.Model;
using ConsoleAppNinject.Core.ViewModel;
using ConsoleAppNinject.Ninject;
using Ninject;

namespace ConsoleAppNinject
{
    class Program
    {
        private static IKernel kernel;
        static void Main(string[] args)
        {
            var personProxy = new PersonProxy();

            //Add some people
            Console.WriteLine("Adding People...");
            personProxy.AddPerson(new Person { Name = "Uffe Bjorklund", Gender = Gender.Male, Location = "Sweden" });
            personProxy.AddPerson(new Person { Name = "Zlatan", Gender = Gender.Male, Location = "Sweden" });
            personProxy.AddPerson(new Person { Name = "Arne Hegerfors", Gender = Gender.Male, Location = "Sweden" });

            Console.WriteLine("Done... Press enter to find people with letter 'a' in name");
            Console.ReadLine();
            //Find some of them
            foreach (var person in personProxy.Find(p => p.Name.ToLower().Contains("a")))
            {
                Console.WriteLine("Name: {0}, Gender: {1}, Location: {2}", person.Name, person.Gender, person.Location);
            }

            Console.WriteLine("Done... Press enter to get all people");
            Console.ReadLine();
            //Get all
            foreach (var person in personProxy.GetAll())
            {
                Console.WriteLine("Name: {0}, Gender: {1}, Location: {2}", person.Name, person.Gender, person.Location);
            }

            Console.WriteLine("Done... Press enter to delete them all :)");
            Console.ReadLine();
            //Delete all
            foreach (var person in personProxy.GetAll())
            {
                personProxy.Delete(person);
            }
            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        
    }

    public class PersonProxy
    {
        private static IKernel kernel;

        static PersonProxy()
        {
            kernel = new StandardKernel(new ServiceModule());
        }

        public void AddPerson(Person p)
        {
            using (var block = kernel.BeginBlock())
            {
                var personService = block.Get<IPersonService>();
                personService.SaveOrUpdate(p);
            }
        }

        public IEnumerable<Person> GetAll()
        {
            using (var block = kernel.BeginBlock())
            {
                var personService = block.Get<IPersonService>();
                return personService.GetAll().ToList();
            }
        }

        public IEnumerable<Person> Find(Expression<Func<Person, bool>> expression)
        {
            using (var block = kernel.BeginBlock())
            {
                var personService = block.Get<IPersonService>();
                return personService.Find(expression).ToList();
            }
        }

        public void Delete(Person entity)
        {
            using (var block = kernel.BeginBlock())
            {
                var personService = block.Get<IPersonService>();
                personService.Delete(entity);
            }
        }
    }
}

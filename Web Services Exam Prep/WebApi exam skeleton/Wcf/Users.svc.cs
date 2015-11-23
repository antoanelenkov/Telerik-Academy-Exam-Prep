namespace Wcf
{
    using Data;
    using Data.Repositories;
    using Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Users : IUsers
    {
        public Users()
        {
            var db = new AppDbContext();
            this.UsersRepo = new GenericRepository<User>(db);
        }

        protected IRepository<User> UsersRepo { get; private set; }

        public IEnumerable<User> GetAll(string page)
        {
            // TODO: validate
            var pageAsNumber = int.Parse(page);

            return this.UsersRepo
                .All()
                .OrderBy(u => u.Email)
                .Skip(pageAsNumber * 10)
                .Take(10)
                .Select(u => new User
                {
                    Id = u.Id,
                    Email = u.Email
                })
                .ToList();
        }
    }
}

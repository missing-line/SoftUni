namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;

    using System.Linq;

    public class UserService : IUserService
    {
        private PetStoreDbContext data;

        public UserService(PetStoreDbContext data)
            => this.data = data;


        public bool IsExist(int userId)
            => this.data.Users.Any(x => x.Id == userId);

        public void Register(string name, string email)
        {
            this.data.Users.Add(new User() { Name = name, Email = email });
            this.data.SaveChanges();
        }    
    }
}

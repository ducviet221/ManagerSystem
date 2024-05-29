using api_gateway.Entity;
using api_gateway.Model.User;

namespace api_gateway.Repo
{
    public interface IUserRepo
    {
        IEnumerable<myUser> GetAll();
        Object  Get(MyUser entity);
        void Add(myUser entity);
        void Update(myUser dbEntity, MyUser entity);
        void Delete(myUser entity);
    }

    
}

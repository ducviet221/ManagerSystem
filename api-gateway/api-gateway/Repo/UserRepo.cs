using api_gateway.dbContext;
using api_gateway.Entity;
using api_gateway.Model.User;

namespace api_gateway.Repo
{
    public class UserRepo : IUserRepo
    {
        readonly myDbContext _employeeContext;
        public UserRepo(myDbContext context)
        {
            _employeeContext = context;
        }
        public IEnumerable<myUser> GetAll()
        {
            return _employeeContext.MyUsers.ToList();
        }
        public Object Get(MyUser entity)
        {
            if (entity.userName != null && entity.password != null)
            {
                return _employeeContext.MyUsers
                    .Where(e => e.userName == entity.userName && e.password == entity.password).FirstOrDefault();
                    
            }
            else
            {
                // Trả về danh sách rỗng hoặc xử lý trường hợp userName null
                return null;
            }
        }
        public void Add(myUser entity)
        {
            _employeeContext.MyUsers.Add(entity);
            _employeeContext.SaveChanges();
        }
        public void Update(myUser employee, MyUser model)
        {
            employee.userName = model.userName;
           
            _employeeContext.SaveChanges();
        }
        public void Delete(myUser employee)
        {
            _employeeContext.MyUsers.Remove(employee);
            _employeeContext.SaveChanges();
        }

    }
}

using api_gateway.Entity;
using api_gateway.Model.BaseResponse;
using api_gateway.Model.User;
using api_gateway.Repo;
using Microsoft.AspNetCore.Mvc;

namespace api_gateway.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class LoginController : Controller
    {

        private readonly IUserRepo _dataRepository;

        public LoginController(IUserRepo dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpPost("createUser")]

        public async Task<BaseRespone> handleCreateUser([FromBody ] MyUser myUser)
        {
            _dataRepository.Add(new api_gateway.Entity.myUser
            {
                userName = myUser.userName,
                id =  Guid.NewGuid(), 
                password = myUser.password

            })
;            return  new BaseRespone
            {
                result = myUser,
                status = true

            }; 
        }

        [HttpPost("login")]

        public async Task<BaseRespone> handleLogin ([FromBody] MyUser myUser)
        {
           

            if (myUser.password != null && myUser.userName != null)
            {
                var data =  _dataRepository.Get(myUser);
                
              if(data != null)
                {
                    return new BaseRespone
                    {
                        result = data,
                        status = true

                    };
                }
                return new BaseRespone
                {
                    result = new Object(),
                    status = false,

                };
            }
            return new BaseRespone{
                result = new Object(),
                status = false,

            };

        }

    }
}

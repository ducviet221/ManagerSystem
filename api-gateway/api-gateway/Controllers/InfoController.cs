using api_gateway.Entity;
using api_gateway.Model.BaseResponse;
using api_gateway.Model.Info;
using api_gateway.Repo;
using Microsoft.AspNetCore.Mvc;

namespace api_gateway.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class InfoController : Controller
    {
        private readonly IInfoRepo _dataRepository;

        public InfoController(IInfoRepo dataRepository)
        {
            _dataRepository = dataRepository;
        }

       

        [HttpPost("createInfo")]

        public async Task<BaseRespone> handleCreateInfo([FromBody] InfoModel infoData)
        {
             _dataRepository.Add(new api_gateway.Entity.myInfo
            {
                cif = infoData.cif,
                id = Guid.NewGuid(),
                deliveryroom = infoData.deliveryroom,
                recive = infoData.recive,
                affarisofficer = infoData.affarisofficer,
                date = infoData.date,
                name = infoData.name,
                note = infoData.note,
                status = infoData.status

            });
            return new BaseRespone
                {
                     result = infoData,
                     status = true
                };
        }
        [HttpGet("getListInfo")]

        public async Task<BaseRespone> handleGetListInfo()
        {         
                var data = _dataRepository.GetAll();
                return new BaseRespone
                {
                    result = data,
                    status = true
                };
        }

        [HttpGet("getInfoDetail/{id}")]

        public async Task<BaseRespone> handleÌnfoDetailById(string id)
        {


            if (id != null)
            {
                var data =  _dataRepository.Get(id);
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



        [HttpDelete("deleteInfo/{id}")]

        public async Task<BaseRespone> handleDeleteInfoById(string id)
        {


            if (id != null)
            {
                var data = _dataRepository.Delete(id);
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

        [HttpGet("completeInfo/{id}")]

        public async Task<BaseRespone> handleCompleteInfoById(string id)
        {


            if (id != null)
            {
                var data =  _dataRepository.CompleteInfo(id);
                if(data == true)
                {
                    return new BaseRespone
                    {
                        result = id,
                        status = true

                    };
                }
                return new BaseRespone
                {
                    result = id,
                    status = false

                };
            }
            return new BaseRespone
            {
                result = new Object(),
                status = false,

            };

        }

        [HttpPost("updateInfo")]

        public async Task<BaseRespone> handleUpdateInfoById([FromBody] InfoModel infoData)
        {


            if (infoData != null)
            {
                var data = _dataRepository.Update(infoData);
                if (data != null)
                {
                    return new BaseRespone
                    {
                        result = infoData,
                        status = true

                    };
                }
                return new BaseRespone
                {
                    result = infoData,
                    status = false

                };
            }
            return new BaseRespone
            {
                result = new Object(),
                status = false,

            };

        }
    }
}

using api_gateway.Entity;
using api_gateway.Model.Info;

namespace api_gateway.Repo
{
    public interface IInfoRepo
    {
        IEnumerable<myInfo> GetAll();
        Object Get(string id);
        bool CompleteInfo(string id);
        void Add(myInfo entity);
        Object Update(InfoModel entity);
        bool Delete(String id);
    }
}
using api_gateway.dbContext;
using api_gateway.Entity;
using api_gateway.Model.Info;

namespace api_gateway.Repo
{
    public class InfoRepo : IInfoRepo
    {
        readonly myDbContext _employeeContext;
        public InfoRepo(myDbContext context)
        {
            _employeeContext = context;
        }
        public IEnumerable<myInfo> GetAll()
        {
            return _employeeContext.InfoList.ToList();
        }
        public Object Get(string id)
        {
            if (id != null)
            {
                return _employeeContext.InfoList
                    .Where(e => e.id.ToString() == id).FirstOrDefault();

            }
            else
            {
                // Trả về danh sách rỗng hoặc xử lý trường hợp userName null
                return null;
            }
        }
        public void Add(myInfo entity)
        {
            _employeeContext.InfoList.Add(entity);
            _employeeContext.SaveChanges();
        }
        public Object Update(InfoModel model)
        {
            if (model.id != null)
            {
                var currentInfo = _employeeContext.InfoList
                    .Where(e => e.id == model.id).FirstOrDefault();
                currentInfo.date = model.date;
                currentInfo.status = model.status;
                currentInfo.cif = model.cif;
                currentInfo.name = model.name;
                currentInfo.recive = model.recive;
                currentInfo.affarisofficer = model.affarisofficer;
                currentInfo.deliveryroom = model.deliveryroom;
                currentInfo.id = model.id;
                currentInfo.note = model.note;
                _employeeContext.Update(currentInfo);
                _employeeContext.SaveChanges();
                return model;

            }
            else
            {
                return false;
            }
            _employeeContext.SaveChanges();
        }
        public bool Delete(string id)
        {
            var currentInfo = _employeeContext.InfoList
                    .Where(e => e.id.ToString() == id).FirstOrDefault();
            try
            {
                _employeeContext.InfoList.Remove(currentInfo);
                _employeeContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CompleteInfo(string id)
        {
            if (id != null)
            {
                var currentInfo =  _employeeContext.InfoList
                    .Where(e => e.id.ToString() == id).FirstOrDefault();
                currentInfo.status = 1000002;
                _employeeContext.Update(currentInfo);
                _employeeContext.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
           
        }
    }
}

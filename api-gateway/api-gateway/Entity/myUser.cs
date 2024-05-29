using System.ComponentModel.DataAnnotations;

namespace api_gateway.Entity
{
    public class myUser
    {
        [Key]
        public Guid id { get; set; }
        public string userName { get; set; }

        public string password { get; set; }    
            
    }
}

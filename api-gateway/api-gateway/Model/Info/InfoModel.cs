using System.ComponentModel.DataAnnotations;

namespace api_gateway.Model.Info
{
    public class InfoModel
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string cif { get; set; }

        public string deliveryroom { get; set; }

        public string affarisofficer { get; set; }

        public string recive { get; set; }

        public int status { get; set; }

        public string note { get; set; }

        public string date { get; set; }


    }
}

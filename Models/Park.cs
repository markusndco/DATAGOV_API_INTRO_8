using System.Collections.Generic;

namespace DATAGOV_API_INTRO_8.Models
{
    public class Park
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string parkCode { get; set; }
        public string description { get; set; }
        public string latLong { get; set; }
    }

    public class Parks
    {
        public List<Park> data { get; set; }
    }
}


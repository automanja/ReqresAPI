using ResreqAPILibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResreqAPILibrary.Manager
{
    public class GetUsersResponse : ICommonModel
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<User> Data { get; set; }

        public Advertise Ad { get; set; }
    }
}

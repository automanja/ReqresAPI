using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResreqAPILibrary.Model
{
    public class RegisterUserResponse:ICommonModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
    }
}

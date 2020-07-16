using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResreqAPILibrary.Model
{
    public class CreateUserRequest: ICommonModel
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }
}

using ResreqAPILibrary.Manager;

namespace ResreqAPILibrary.Model
{
    public class GetUserResponse : ICommonModel
    {
        public User Data { get; set; }
        public Advertise Ad { get; set; }
    }
}

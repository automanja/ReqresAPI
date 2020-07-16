using ResreqAPILibrary.Model;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;

namespace ResreqAPILibrary.Manager
{
    public class UserManager
    {
        public IRestResponse GetContent(string endpoint, string method)
        {
            var api = new ApiHelper();
            var request = api.CreateRequest(method);
            var client = api.SetUri(endpoint);
            return api.GetResponse(client, request);
        }

        public IRestResponse GetContent(string endpoint, string method, dynamic payload)
        {
            var api = new ApiHelper();
            var request = api.CreateRequest(payload, method);
            var client = api.SetUri(endpoint);
            return api.GetResponse(client, request);
        }

        public async Task<IRestResponse> GetContent(string endpoint, string method, int delay)
        {
            var api = new ApiHelper();
            var request = api.CreateRequest(method);
            await Task.Delay(delay);
            var client = api.SetUri(endpoint + delay.ToString());
            return api.GetResponse(client, request);
        }

        public GetUsersResponse GetAllUsers(IRestResponse response)
        {
            var api = new ApiHelper();
            var content = api.GetContent<GetUsersResponse>(response);
            return content;
        }

        public GetUserResponse GetSingleUser(IRestResponse response)
        {
            var api = new ApiHelper();
            var content = api.GetContent<GetUserResponse>(response);
            return content;
        }

        public CreateUserResponse CreateUser(string endpoint, dynamic payload)
        {
            var api = new ApiHelper();
            var serializedRequest = api.Serialize(payload);
            var request = api.CreateRequest(serializedRequest, Methods.POST);
            var client = api.SetUri(endpoint);
            var response = api.GetResponse(client, request);
            return api.GetContent<CreateUserResponse>(response);
        }

        public bool VerifyUsersData(GetUsersResponse result, GetUsersResponse sample)
        {
            if (result.Data.Count != sample.Data.Count) return false;
            for (int i = 0; i < result.Data.Count; i++)
            {
                if (result.Data[i].Id != sample.Data[i].Id) return false;
                if (result.Data[i].Email != sample.Data[i].Email) return false;
                if (result.Data[i].First_name != sample.Data[i].First_name) return false;
                if (result.Data[i].Last_name != sample.Data[i].Last_name) return false;
                if (result.Data[i].Avatar != sample.Data[i].Avatar) return false;
                if (!result.Data[i].Avatar.Contains("jpg")) return false;
            }

            return true;
        }

        public bool VerifyIfUserExists(int id)
        {
            var content = GetContent("api/users", Methods.GET);
            var listOfAllUsers = GetAllUsers(content).Data;
            return listOfAllUsers.Any(x => x.Id == id);

        }

        //public RegisterUserResponse RegisterUser(string endpoint, dynamic payload)
        //{
        //    var api = new ApiHelper();
        //    var serializedRequest = api.Serialize(payload);
        //    var request = api.CreateRequest(serializedRequest, Methods.POST);
        //    var client = api.SetUri(endpoint);
        //    var response = api.GetResponse(client, request);

        //    if (response.) return null;

        //    return api.GetContent<RegisterUserResponse>(response);
        //}


    }
}

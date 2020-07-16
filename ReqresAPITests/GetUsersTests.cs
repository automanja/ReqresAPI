using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqresAPITests.TestSetup;
using ResreqAPILibrary;
using ResreqAPILibrary.Manager;

namespace ReqresAPITests
{
    [TestClass]
    public class GetUsersTests:BaseTest
    {
        [TestMethod]
        public void GetAllUsers()
        {
            var content = manager.GetContent("api/users?page=2", Methods.GET);
            Assert.AreEqual(content.StatusCode, HttpStatusCode.OK, "Service didn't return status code OK 200");
            GetUsersResponse result = manager.GetAllUsers(content);
            GetUsersResponse sampleData = dataManager.DeserializeUserData<GetUsersResponse>("Content\\GetUsersData.json");
            Assert.AreEqual(result.Data.Count, result.Per_page);
            Assert.AreEqual(result.Total, sampleData.Total, "Number of total users isn't correct. Expected is: " + sampleData.Total + " but actual is: " + result.Total);
            Assert.IsTrue(manager.VerifyUsersData(result, sampleData), "Received response and sample response do not match");
        }

        [TestMethod]
        public void GetUsersForNonExistingPage()
        {
            var content = manager.GetContent("api/users", Methods.GET);
            Assert.AreEqual(content.StatusCode, HttpStatusCode.OK, "Service didn't return status code OK 200");
            GetUsersResponse result = manager.GetAllUsers(content);
            content = manager.GetContent("api/users?page="+ (result.Total_pages+1), Methods.GET);
            GetUsersResponse response = manager.GetAllUsers(content);
            Assert.AreEqual(response.Page, (result.Total_pages + 1), "");
            Assert.AreEqual(response.Data.Count, 0);
            
        }

        [TestMethod]
        public void GetUsersWithDelay()
        {
            var content = manager.GetContent("api/users?delay=", Methods.GET,  5000).Result;
            Assert.AreEqual(content.StatusCode, HttpStatusCode.OK, "Service didn't return status code OK 200");
            GetUsersResponse result = manager.GetAllUsers(content);
            GetUsersResponse sampleData = dataManager.DeserializeUserData<GetUsersResponse>("Content\\GetUsersData.json");
            Assert.AreEqual(result.Data.Count, result.Per_page);
            Assert.AreEqual(result.Total, sampleData.Total, "Number of total users isn't correct. Expected is: " + sampleData.Total + " but actual is: " + result.Total);
        }
    }
}

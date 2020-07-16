using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqresAPITests.TestSetup;
using ResreqAPILibrary.Manager;
using System.Linq;
using System.Net;
using ResreqAPILibrary.Model;
using ResreqAPILibrary;

namespace ReqresAPITests
{
    [TestClass]
    public class DeleteUserTests : BaseTest
    {
        [TestMethod]
        public void DeleteUser()
        {
            var content = manager.GetContent("api/users/3", Methods.DELETE);
            Assert.AreEqual(content.StatusCode, HttpStatusCode.NoContent);
        }

        [TestMethod]
        public void DeleteCreatedUserUser()
        {
            CreateUserRequest request = dataManager.DeserializeUserData<CreateUserRequest>("Content\\CreateUserData.json");
            CreateUserResponse result = manager.CreateUser("api/users",request);
            Assert.AreNotEqual(result.Id, 0);
            var content = manager.GetContent("api/users/" + result.Id, Methods.DELETE);
            Assert.AreEqual(content.StatusCode, HttpStatusCode.NoContent);
            content = manager.GetContent("api/users/" + result.Id, Methods.GET);
            Assert.AreEqual(content.StatusCode, HttpStatusCode.NotFound, "User is succesfully deleted");
        }

        [TestMethod]
        public void GetUsersWithDelay()
        {
            var content = manager.GetContent("api/users?delay", Methods.GET);
            Assert.AreEqual(content.StatusCode, HttpStatusCode.OK, "Service didn't return status code OK 200");
            GetUsersResponse result = manager.GetAllUsers(content);
        }
    }
}

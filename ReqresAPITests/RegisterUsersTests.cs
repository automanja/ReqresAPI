﻿using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqresAPITests.TestSetup;
using ResreqAPILibrary;
using ResreqAPILibrary.Model;

namespace ReqresAPITests
{
    [TestClass]
    public class RegisterUsersTests : BaseTest
    {
        [TestMethod]
        public void RegisterUserWithInvalidData()
        {
            RegisterUserRequest request = dataManager.DeserializeUserData<RegisterUserRequest>("Content\\RegisterUserInvalidData.json");
            var content = manager.GetContent("api/register", Methods.POST, request);
            Assert.AreNotEqual(content.StatusCode, HttpStatusCode.OK, "Bad request sent but status code OK received");
            Assert.AreEqual(content.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}

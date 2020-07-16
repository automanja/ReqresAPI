using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResreqAPILibrary.Manager;

namespace ReqresAPITests.TestSetup
{
    [TestClass]
    public class BaseTest
    {
        public UserManager manager;
        public DataManager dataManager;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            manager = new UserManager();
            dataManager = new DataManager();
        }
    }
}

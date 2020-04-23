using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {       
        private Blab harness = new Blab();
        public void SetUp() 
        {
        }
        [TestMethod]
        public void TestSetGetMessage()
        {
            // Arrange
            string expected = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."; 
            harness.Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestId()
        {
            // Arrange
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
            bool actualBool = harness.Id is Guid;
            Assert.AreEqual(true, actualBool);
        }
        
        [TestMethod]
        public void TestDTTM()
        {
            // Arrange
            Blab Expected = new Blab();
            // Act
            Blab Actual = new Blab();
            // Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }

        [TestMethod]
        public void TestValidation()
        {
            bool actual = harness.IsValid();
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestSetGetUser()
        {
            User testUser = new User("blab@test.com");
            harness.User= (testUser);
            User actual = harness.User;
            Assert.AreEqual(testUser.ToString(), actual.ToString());
        }
    }
}
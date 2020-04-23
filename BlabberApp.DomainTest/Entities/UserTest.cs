using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestSetGetEmail_Success()
        {
            // Arrange
            User harness = new User(); 
            string expected = "foobar222@example.com";
            harness.ChangeEmail("foobar222@example.com");
            // Act
            string actual = harness.Email; // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail00()
        {
            // Arrange
            User harness = new User(); 
            
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("Foobar"));
            // Assert
            Assert.AreEqual("Foobar is invalid", ex.Message.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail01()
        {
            // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("example.com"));
            // Assert
            Assert.AreEqual("example.com is invalid", ex.Message.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail02()
        {
            // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar.example"));
            // Assert
            Assert.AreEqual("foobar.example is invalid", ex.Message.ToString());
        }
        [TestMethod]
        public void TestId()
        {
            // Arrange
            User harness = new User();
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.Id is Guid);
        }

        [TestMethod]
        public void TestRegisterDTTM()
        {
            // Arrange
            User Expected = new User();
            // Act
            User Actual = new User();
            // Assert
            Assert.AreEqual(Expected.RegisterDTTM.ToString(), Actual.RegisterDTTM.ToString());
        }
        [TestMethod]
        public void TestLastLogin()
        {
            // Arrange
            User Expected = new User();
            // Act
            User Actual = new User();
            // Assert
            Assert.AreEqual(Expected.LastLoginDTTM.ToString(), Actual.LastLoginDTTM.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException),
    "A userId of null was inappropriately allowed.")]
        public void TestValidationNull()
        {
            User harness = new User();
            bool actual = harness.IsValid();
        }

        [TestMethod]
        [ExpectedException(typeof(System.FormatException),
    "A userId of null was inappropriately allowed.")]
        public void TestValidationFormat()
        {
            User harness = new User("");
            bool actual = harness.IsValid();
        }
    }
}
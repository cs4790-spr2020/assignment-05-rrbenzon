using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using System;
using System.Collections;


namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_InMemory_UnitTests 
    {
        private UserAdapter _harness = new UserAdapter(new InMemory());


        private User _user;
        User testUser;
        private readonly string _email = "userAdaptMem@test.com";
        bool removeAll = false;
        ArrayList allUsers;


        [TestInitialize]
        public void Setup()
        {
            allUsers = (ArrayList)_harness.GetAll();
            _user = new User(_email);
        }
        [TestCleanup]
        public void TearDown()
        {
            User user = new User(_email);
            _harness.Remove(user);
            _harness.Remove(testUser);
            if(removeAll == true)
            {
                removeAll = false;
                for(int i = 0; i < allUsers.Count; i++)
                {
                    _harness.Add((User)allUsers[i]);
                }
            }
        }
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetUser()
        {
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            User actual = _harness.GetById(_user.Id);
            //Assert
            Assert.AreEqual(_user.Id, actual.Id);
        }

        [TestMethod]
        public void TestAndGetAll()
        {
            //Arrange
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);
            //Act
            ArrayList users = (ArrayList)_harness.GetAll();
            User actual = (User)users[0];
            //Assert
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
        }

        [TestMethod]
        public void TestGetUserId()
        {
            testUser  = new User(_email);
            testUser.RegisterDTTM = DateTime.Now;
            testUser.LastLoginDTTM = DateTime.Now;
            _harness.Add(testUser);
            User users = _harness.GetById(testUser.Id);
            Assert.AreEqual(testUser.Id.ToString(), users.Id.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(BlabberApp.DataStore.Exceptions.UserAdapterNotFoundException),
    "A userId of null was inappropriately allowed.")]
        public void TestRemoveUser()
        {
            User removeUser = new User(_email);
            removeUser.RegisterDTTM = DateTime.Now;
            removeUser.LastLoginDTTM = DateTime.Now;
            _harness.Add(removeUser);
            _harness.Remove(removeUser);
            User trial = _harness.GetByEmail(_email);
        }

        [TestMethod]
        public void TestGetByEmail()
        {
            testUser  = new User(_email);
            testUser.RegisterDTTM = DateTime.Now;
            testUser.LastLoginDTTM = DateTime.Now;
            _harness.Add(testUser);
            User users = _harness.GetByEmail(_email);
            Assert.AreEqual(testUser.Id.ToString(), users.Id.ToString());
        }

        [TestMethod]
        public void TestRemoveAll()
        {
            removeAll = true;
            _harness.RemoveAll();
            ArrayList actual = (ArrayList)_harness.GetAll();
            Assert.AreEqual(0,actual.Count);
        }
    }
}
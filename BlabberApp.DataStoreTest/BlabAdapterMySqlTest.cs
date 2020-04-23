using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {   
        private BlabAdapter _harness = new BlabAdapter(new MySqlBlab());

        Blab blab;
        Blab blab1;
        Blab blab2;
        Blab blab3;
        Blab blab4;
        string email;
        User mockUser;
        ArrayList allBlabs;
        bool removeAll = false;

        [TestInitialize]
        public void Setup()
        {
            //Arrange
            allBlabs = (ArrayList)_harness.GetAll();
            email = "blabAdapt@test.com";
            mockUser = new User(email);
            blab = new Blab("Now is the time for, blabs...", mockUser);
            blab1 = new Blab("Here is some dummy text", mockUser);
            blab2 = new Blab("Message number two", mockUser);
            blab3 = new Blab("delete1", mockUser);
            blab4 = new Blab("Get by Guid", mockUser);
        }

        [TestCleanup]
        public void TearDown()
        {
            _harness.Remove(blab);
            _harness.Remove(blab1);
            _harness.Remove(blab2);
            _harness.Remove(blab3);
            _harness.Remove(blab4);
            if(removeAll == true)
            {
                removeAll = false;
                for(int i = 0; i < allBlabs.Count; i++)
                {
                    _harness.Add((Blab)allBlabs[i]);
                }
            }
        }

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetBlab()
        {
            //Act
            _harness.Add(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            //Assert
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void TestAddAndGet2Blabs()
        {
            _harness.Add(blab1);
            _harness.Add(blab2);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public void TestDeleteBlab()
        {
            _harness.Add(blab3);
            _harness.Remove(blab3);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void TestRemoveAll()
        {
            removeAll = true;
            _harness.RemoveAll();
            ArrayList actual = (ArrayList)_harness.GetAll();
            Assert.AreEqual(0,actual.Count);
        }

        [TestMethod]
        public void TestGetById()
        {
            _harness.Add(blab4);
            Blab actual = _harness.GetById(blab4.Id);
            Assert.AreEqual(blab4.ToString(), actual.ToString());
        }
    }
}
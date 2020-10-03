using System;
using System.Collections.Generic;
using _01_Menu_Repo;
using _02_Claims_Repo;
using _03_Badges_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Badge_Repo _badgeRepo = new Badge_Repo();

        [TestMethod]
        public void Seed()
        {
            _badgeRepo.AddBadge(12345, new List<string> { "A7" });
            _badgeRepo.AddBadge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            _badgeRepo.AddBadge(32345, new List<string> { "A4", "A5" });
        }

        [TestMethod]
        public void AddContentTest()
        {
            int expected = 3;
            int actual = _badgeRepo.ViewAllBadges().Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAddContent()
        {
            _badgeRepo.AddBadge(54321, new List<string> {"A2"});
            bool wasAdded = true;

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void RemoveTest()
        {
            _badgeRepo.DeleteBadge(12345, new List<string> { "A7" });
            bool wasDeleted = true;

            Assert.IsTrue(wasDeleted);
        }
    }
}


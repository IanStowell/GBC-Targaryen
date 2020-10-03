using System;
using _02_Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Test
{
    [TestClass]
    public class UnitTest1
    {
        private Repo _repo = new Repo();

        [TestMethod]
        public void Seed()
        {
            Claim claim1 = new Claim(2584, "Car", "Car accident on 465", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim claim2 = new Claim(8978, "Home", "House fire in kitchen", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim claim3 = new Claim(2426, "Theft", "Stolen Pancakes", 400.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));

            _repo.AddClaim(claim1);
            _repo.AddClaim(claim2);
            _repo.AddClaim(claim3);
        }

        [TestMethod]
        public void AddClaimTest()
        {
            int expected = 3;
            int actual = _repo.ViewList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddManualTest()
        {
            Claim claim4 = new Claim(1738, "Car", "Car accident from blessing the rains.", 150.00, new DateTime(2020, 4, 29), new DateTime(2020, 4, 30));
            bool wasAdded = _repo.AddClaim(claim4);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void RemoveClaimTest()
        {
            _repo.RemoveClaimFromList(6666);
            int expected = 2;
            int actual = _repo.ViewList().Count;
            Assert.AreEqual(expected, actual);

        }
    }
}

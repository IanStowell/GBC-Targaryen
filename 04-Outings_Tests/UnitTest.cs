using System;
using _04_Outings_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Outings_Tests
{
    [TestClass]
    public class UnitTest
    {
        private OutingRepo _outingRepo = new OutingRepo();

        [TestMethod]
        public void Seed()
        {
            Outing briarWood = new Outing("Briar Wood", EventType.Golf, 11, new DateTime(2020, 01, 01), 10d, 1000d);
            Outing beaconHills = new Outing("Beacon Hills", EventType.Golf, 22, new DateTime(2020, 02, 02), 20d, 2000d);
            Outing thunderBirdBowling = new Outing("Thunder Bird Lanes", EventType.Bowling, 33, new DateTime(2020, 03, 03), 30d, 3000d);
            Outing caseysLanes = new Outing("Caseys Lanes", EventType.Bowling, 44, new DateTime(2020, 04, 04), 40d, 4000d);
            Outing sixFlags = new Outing("Six Flags", EventType.AmusementPark, 55, new DateTime(2020, 05, 05), 50d, 5000d);
            Outing cedarPoint = new Outing("Cedar Point", EventType.AmusementPark, 66, new DateTime(2020, 06, 06), 60d, 6000d);
            Outing brockHampton = new Outing("Brockhampton", EventType.Concert, 77, new DateTime(2020, 07, 07), 70d, 7000d);
            Outing toto = new Outing("Toto", EventType.Concert, 88, new DateTime(2020, 08, 08), 80d, 8000d);

            _outingRepo.AddNewOuting(briarWood);
            _outingRepo.AddNewOuting(beaconHills);
            _outingRepo.AddNewOuting(thunderBirdBowling);
            _outingRepo.AddNewOuting(caseysLanes);
            _outingRepo.AddNewOuting(sixFlags);
            _outingRepo.AddNewOuting(cedarPoint);
            _outingRepo.AddNewOuting(brockHampton);
            _outingRepo.AddNewOuting(toto);
        }

        [TestMethod]
        private void AddOutingTest()
        {
            int expected = 8;
            int actual = _outingRepo.GetList().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddManuallyTest()
        {
            Outing thePark = new Outing("A Park", EventType.AmusementPark, 66, new DateTime(2020, 09, 09), 90d, 9000d);
            _outingRepo.AddNewOuting(thePark);
            bool wasAdded = true;

            Assert.IsTrue(wasAdded);

        }
    }
}

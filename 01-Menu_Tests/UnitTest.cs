using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_Menu_Repo;

namespace _01_Menu_Tests
{
    [TestClass]
    public class UnitTest
    {
        private Repo _repo = new Repo();

        [TestMethod]
        public void Seed()
        {
            Menu carmelMacchiato = new Menu(1, "Caramel Macchiato", "An espresso and milk drink with caramel flavoring.", "Espresso shots, caramel, foamed AND steamed milk.", 2.50, ItemType.Drink);
            Menu crossaintWhich = new Menu(2, "Croissant Which", "A croissant breakfast sandwhich.", "Croissant buns, sausage, egg, and cheese.", 3.50, ItemType.Meal);
            Menu coffeeCake = new Menu(3, "Coffee Cake", "A tasty cinnamon pastry.", "Cinnamon, sugar, flour, yeast, and egg.", 1.75, ItemType.Side);

            _repo.AddMenuItem(carmelMacchiato);
            _repo.AddMenuItem(crossaintWhich);
            _repo.AddMenuItem(coffeeCake);
        }

        [TestMethod]
        public void AddToMenuTest()
        {
            int expected = 3;
            int actual = _repo.GetItemList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddManuallyTest()
        {
            Menu cornBeefHash = new Menu(4, "Corn Beef Hash", "Corn, beef, and hash!", "Corn, beef, and hash!", 2.59, ItemType.Meal);
            _repo.AddMenuItem(cornBeefHash);

            bool wasAdded = true;

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void RemoveItemTest()
        {
            Menu item = new Menu();
            string coffeeCake = null;
            bool v = _repo.RemoveItemFromList(coffeeCake);
            int expected = 2;
            int actual = _repo.GetItemList().Count;
            Assert.AreEqual(expected, actual);
        }
    }
}


using SwinAdventure;
using NUnit.Framework;
public class InventoryTest
{
        private Inventory _testInventory;
        private Item _testItem1;
        private Item _testItem2;

        [SetUp]
        public void Setup()
        {
            _testInventory = new Inventory();

            _testItem1 = new Item(new string[] { "silver", "hat" }, "A Bronze Sword", "A very sharp bronze sword");
            _testItem2 = new Item(new string[] { "light", "torch" }, "A Torch", "A Torch to light the path");

            _testInventory.Put(_testItem1);
            _testInventory.Put(_testItem2);
        }

        [Test]
        public void HasItemTest()
        {
            Assert.Pass();
        }

        [Test]
        public void DosentHaveItemTest()
        {
            Assert.Pass();
        }

        [Test]
        public void FetchItemTest()
        {
            Assert.Pass();
        }

        [Test]
        public void TakeItemTest()
        {
            Assert.Pass();
        }

        [Test]
        public void ListItemTest()
        {
            Assert.Pass();
        }
}
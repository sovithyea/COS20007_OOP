namespace InventoryTest
{
    using NUnit.Framework;
    using SwinAdventure;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFindItem_IsTrue()
        {
            Inventory inv = new Inventory();
            Item item = new Item(new string[] { "sword" }, "sword", "a sword");
            inv.Put(item);
            Assert.IsTrue(inv.HasItem("sword"));
        }

        [Test]
        public void TestFindItem_IsFalse()
        {
            Inventory inv = new Inventory();
            Item item = new Item(new string[] { "sword" }, "sword", "a sword");
            inv.Put(item);
            Assert.IsFalse(inv.HasItem("axe"));
        }

        [Test]
        public void FetchItemTest_AreEqual()
        {
            Inventory inv = new Inventory();
            Item item = new Item(new string[] { "sword" }, "sword", "a sword");
            inv.Put(item);
            Assert.AreEqual(item, inv.Fetch("sword"));
        }

        [Test]
        public void FetchItemTest_IfNull()
        {
            Inventory inv = new Inventory();
            Item item = new Item(new string[] { "sword" }, "sword", "a sword");
            inv.Put(item);
            Assert.IsNull(inv.Fetch("axe"));
        }

        [Test]
        public void TakeItemTest_AreEqual_IsFalse()
        {
            Inventory inv = new Inventory();
            Item item = new Item(new string[] { "sword" }, "sword", "a sword");
            inv.Put(item);
            Assert.AreEqual(item, inv.Take("sword"));
            Assert.IsFalse(inv.HasItem("sword"));
        }

        [Test]
        public void ItemListTest_AreEqual()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "Sword", "A sharp blade");
            Item shield = new Item(new string[] { "shield" }, "Shield", "Protects you");
            inventory.Put(sword);
            inventory.Put(shield);
            string itemList = inventory.ItemList;
            string expected =
                "\ta Sword (sword)\n" +
                "\ta Shield (shield)";
            Assert.AreEqual(expected, itemList);
        }

        [Test]
        public void RemoveItemTest_IsFalse()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "Sword", "A sharp blade");
            Item shield = new Item(new string[] { "shield" }, "Shield", "Protects you");
            inventory.Put(sword);
            inventory.Put(shield);
            inventory.RemoveItem(sword);
            Assert.IsFalse(inventory.HasItem("sword"));
        }
    }
}


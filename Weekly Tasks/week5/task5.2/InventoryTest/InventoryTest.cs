using NUnit.Framework;
using SwinAdventure;
using System.Collections.Generic; 

namespace InventoryTest
{
    [TestFixture]
    public class Tests
    {   
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
            Inventory inv = new Inventory();
            Item item1 = new Item(new string[] { "sword" }, "sword", "a sword");
            Item item2 = new Item(new string[] { "axe" }, "axe", "an axe");
            inv.Put(item1);
            inv.Put(item2);
            string expectedList = "\t" + item1.ShortDescription + "\n\t" + item2.ShortDescription;
            Assert.AreEqual(expectedList, inv.ItemList);
        }
        [Test]
        public void RemoveItemsTest_IfIDMatchesWithStudentID_IsTrue_IsFalse()
        {
            Inventory inv = new Inventory();
            Item item1 = new Item(new string[] { "sword" }, "sword", "a sword");
            Item item2 = new Item(new string[] { "105270743" }, "player", "a player");
            Item item3 = new Item(new string[] { "axe" }, "axe", "an axe");
            inv.Put(item1);
            inv.Put(item2);
            inv.Put(item3);
            List<Item> ToRemove = new List<Item> { item2 }; 
            inv.RemoveItems(ToRemove);
            Assert.That(inv.HasItem("sword"), Is.False);
            Assert.That(inv.HasItem("axe"), Is.False);
            Assert.That(inv.HasItem("105270743"), Is.True);
        }
    }
}
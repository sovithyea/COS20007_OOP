using NUnit.Framework;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class BagTest
    {
        [Test]
        public void TestBagLocatesItem()
        {
            Bag bag = new Bag(new string[] { "bag" }, "leather bag", "A sturdy leather bag");
            Item gem = new Item(new string[] { "gem" }, "magic gem", "A glowing gem");
            bag.Inventory.Put(gem);

            GameObject foundItem = bag.Locate("gem");

            Assert.That(foundItem, Is.EqualTo(gem));
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Bag bag = new Bag(new string[] { "bag" }, "leather bag", "A sturdy leather bag");

            GameObject found = bag.Locate("bag");

            Assert.That(found, Is.EqualTo(bag));
        }

        [Test]
        public void TestBagDoesNotLocateUnknown()
        {
            Bag bag = new Bag(new string[] { "bag" }, "leather bag", "A sturdy leather bag");

            GameObject found = bag.Locate("unknown");

            Assert.That(found, Is.Null);
        }

        [Test]
        public void TestBagFullDescription()
        {
            Bag bag = new Bag(new string[] { "bag" }, "leather bag", "A sturdy leather bag");
            Item gem = new Item(new string[] { "gem" }, "magic gem", "A glowing gem");
            bag.Inventory.Put(gem);

            string description = bag.FullDescription;

            Assert.That(description, Is.EqualTo("In the leather bag you can see:\nmagic gem (gem)"));
        }

        [Test]
        public void TestNestedBagLocateOnlyTopLevel()
        {
            Bag b1 = new Bag(new string[] { "b1" }, "Outer Bag", "Outer container");
            Bag b2 = new Bag(new string[] { "b2" }, "Inner Bag", "Inner container");
            Item apple = new Item(new string[] { "apple" }, "Green Apple", "A crisp green apple");
            b1.Inventory.Put(apple);
            b1.Inventory.Put(b2);

            GameObject foundB2 = b1.Locate("b2");
            GameObject foundApple = b1.Locate("apple");

            Assert.That(foundB2, Is.EqualTo(b2));
            Assert.That(foundApple, Is.EqualTo(apple));
        }

        [Test]
        public void TestBagInBagWithPrivilegedItem()
        {
            Bag b1 = new Bag(new string[] { "b1" }, "Outer Bag", "Outer container");
            Bag b2 = new Bag(new string[] { "b2" }, "Inner Bag", "Inner container");
            Item secret = new Item(new string[] { "priv" }, "Secret File", "A confidential item");
            b2.Inventory.Put(secret);
            b1.Inventory.Put(b2);

            GameObject foundPriv = b1.Locate("priv");

            Assert.That(foundPriv, Is.Null);
        }
    }
}

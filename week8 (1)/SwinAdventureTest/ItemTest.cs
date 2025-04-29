using NUnit.Framework;
using SwinAdventure;

namespace ItemTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ItemIdentifiableTest_IsTrue_IsFalse()
        {
            Item item = new Item(new string[] { "stone", "gem" }, "Stone", "This item is hard.");
            bool hasStone = item.AreYou("stone");
            bool hasGem = item.AreYou("gem");
            bool hasRock = item.AreYou("rock");
            Assert.That(hasStone, Is.True);
            Assert.That(hasGem, Is.True);
        }
        [Test]
        public void ShortDescriptionTest_AreEqual()
        {
            Item item = new Item(new string[] { "stone", "gem" }, "Hard Stone", "This item is hard.");
            string shortDescription = item.ShortDescription;
            Assert.That(shortDescription, Is.EqualTo("a Hard Stone"));
        }
        [Test]
        public void LongDescriptionTest_AreEqual()
        {
            Item item = new Item(new string[] { "stone", "gem" }, "Hard Stone", "This item is hard.");
            string longDescription = item.FullDescription;
            Assert.That(longDescription, Is.EqualTo("This item is hard."));
        }
        [Test]
        public void TestPrivilegeEscalation()
        {
            Item item = new Item(new string[] { "stone", "gem" }, "Hard Stone", "This item is hard.");
            item.PrivilegeEscalation("0743");
            Assert.That(item.Name, Is.EqualTo("0007"));
        }
        
    }
}
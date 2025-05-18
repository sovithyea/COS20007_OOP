using Nunit.Framework;
using SwinAdventure;

namespace ItemsTest
{
    [TestFixture]
    public class ItemsTest
    {
        [SetUp]
        public void Setup()
        {
        }
using NUnit.Framework;
using SwinAdventure;

namespace ItemsTest
{
    [TestFixture]
    public class ItemsTest
    {
        private Item _item;

        [SetUp]
        public void Setup()
        {
            _item = new Item(new string[] { "sword", "weapon" }, "Bronze Sword", "A shiny bronze sword.");
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_item.AreYou("sword"));
            Assert.IsTrue(_item.AreYou("weapon"));
            Assert.IsFalse(_item.AreYou("shield"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("a Bronze Sword (sword)", _item.ShortDescription);
        }

        [Test]
        public void TestLongDescription()
        {
            Assert.AreEqual("A shiny bronze sword.", _item.LongDescription);
        }

        [Test]
        public void TestAddIdentifier()
        {
            _item.AddIdentifier("blade");
            Assert.IsTrue(_item.AreYou("blade"));
        }

        [Test]
        public void TestRemoveIdentifier()
        {
            _item.RemoveIdentifier("sword");
            Assert.IsFalse(_item.AreYou("sword"));
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            _item.PrivilegeEscalation("0743");
            Assert.AreEqual("0007", _item.FirstId);
        }
    }
}
    }
}
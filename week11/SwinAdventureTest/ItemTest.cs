
using SwinAdventure;
using NUnit.Framework;

public class ItemTest
{
    private Item _testItem;

    [SetUp]
    public void Setup()
    {
        _testItem = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");

    }

    [Test]
    public void IdentifiableItem_IsTrue()
    {
        Assert.That(_testItem.AreYou("silver"), Is.True);
        Assert.That(_testItem.AreYou("hat"), Is.True);
    }

    [Test]
    public void ItemShortDescription_IsEqualTo()
    {
        Assert.That(_testItem.ShortDescription, Is.EqualTo("A Silver Hat"));
    }

    [Test]
    public void ItemFullDescription()
    {
        Assert.That(_testItem.FullDescription, Is.EqualTo("A very shiny silver hat"));
    }

}

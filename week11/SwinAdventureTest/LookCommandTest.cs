using SwinAdventure;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework;

namespace LookCommandTest;

public class LookCommandTests
{
    private Player _player;
    private Bag _bag;
    private Item _gem;
    private LookCommand _lookCommand;

    [SetUp]
    public void Setup()
    {
        _player = new Player("Hero", "A brave adventurer");
        _bag = new Bag(new[] { "bag" }, "Leather Bag", "A medium size bag for holding items");
        _gem = new Item(new[] { "gem" }, "Gem", "A bright red...");
        _lookCommand = new LookCommand(new[] { "look" });
    }

    [Test]
    public void LookAtMe()
    {
        string result = _lookCommand.Execute(_player, new[] { "look", "at", "inventory" });
        Assert.That(result, Is.EqualTo("You are Hero A brave adventurer\nYou are carrying:\n"));
    }

    [Test]
    public void LookAtGem()
    {
        _player.Inventory.Put(_gem);
        string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem" });
        Assert.That(result, Is.EqualTo("A bright red..."));
    }

    [Test]
    public void LookAtUnknownItem()
    {
        string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem" });
        Assert.That(result, Is.EqualTo("I cannot find the gem in Hero"));
    }

    [Test]
    public void LookAtGemInMe()
    {
        _player.Inventory.Put(_gem);
        string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "inventory" });
        Assert.That(result, Is.EqualTo("A bright red..."));
    }

    [Test]
    public void LookAtGemInBag()
    {
        _bag.Inventory.Put(_gem);
        _player.Inventory.Put(_bag);
        string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "bag" });
        Assert.That(result, Is.EqualTo("A bright red..."));
    }

    [Test]
    public void LookAtGemInMissingBag()
    {
        string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "bag" });
        Assert.That(result, Is.EqualTo("I cannot find the bag"));
    }

    [Test]
    public void LookAtNoGemInBag()
    {
        _player.Inventory.Put(_bag);
        string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "bag" });
        Assert.That(result, Is.EqualTo("I cannot find the gem in Leather Bag"));
    }

    [Test]
    public void InvalidLook()
    {
        string result1 = _lookCommand.Execute(_player, new[] { "look", "around" });
        string result2 = _lookCommand.Execute(_player, new[] { "hello", "your", "student", "ID"});
        string result3 = _lookCommand.Execute(_player, new[] { "look", "at", "your", "name" });
        Assert.That(result1, Is.EqualTo("I don't know how to look like that"));
        Assert.That(result2, Is.EqualTo("Error in look input"));
        Assert.That(result3, Is.EqualTo("Wha do you want to look in?"));
    }

    [Test]
    public void LookAtFourthKeyword()
    {
        string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem", "on", "bag" });
        Assert.That(result, Is.EqualTo("What do you want to look in?"));
    }
}

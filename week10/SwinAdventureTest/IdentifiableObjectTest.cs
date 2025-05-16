
using SwinAdventure;
using NUnit.Framework;
public class TestIdentifiableObject
{
    private IdentifiableObject _testObj;

    [SetUp]
    public void Setup()
    {
        _testObj = new IdentifiableObject(new string[] { "apple", "lemon" });

    }

    [Test()]
    public void TestAreYou()
    {
        Assert.That(_testObj.AreYou("pineapple"), Is.False);
        Assert.That(_testObj.AreYou("apple"), Is.True);
    }

}

using NUnit.Framework;
using SwinAdventure; // Ensure this matches the namespace of IdentifiableObject

namespace SwinAdventureTest
{
    [TestFixture] 
    public class IdentifiableObjectTests
    {
        private IdentifiableObject _testObj;

        [SetUp]
        public void Setup()
        {
            _testObj = new IdentifiableObject(new string[] { "vithyea", "fusen", "james" });
        }

        [Test]
        public void AreYouTest_IsTrue()
        {
            // Arrange
            string obj = "vithyea";

            // Act
            bool result = _testObj.AreYou(obj);

            // Assert 
            Assert.That(result, Is.True);
        }
        
        [Test]
        public void AreYouTest_IsFalse()
        {
            // Arrange
            string obj = "max";
 
            // Act
            bool result = _testObj.AreYou(obj);

            // Assert
            Assert.That(result, Is.False); 
        }

        [Test]
        public void CaseSensitivityTest_IsTrue()
        {
            string obj = "ViThYeA";
            bool result = _testObj.AreYou(obj);
            Assert.That(result, Is.True);
        }

        [Test]
        public void FirstIdTest_ReturnFirstIdentifier()
        {
            string firstId = _testObj.FirstId;
            Assert.That(firstId, Is.EqualTo("vithyea"));
        }

        [Test]
        public void FirstIdTest_ReturnEmptyIdentifier()
        {
            var _empObj = new IdentifiableObject(new string[] {});
            string firstId = _empObj.FirstId;
            Assert.That(firstId, Is.EqualTo(""));
        }

        [Test]
        public void AddIdTest()
        {
            string newIdentifier = "Diego";
            _testObj.AddIdentifier(newIdentifier);
            Assert.That(_testObj.AreYou(newIdentifier), Is.True);
        }

        [Test]
        public void RemoveIdTest()
        {
            string IdToRemove = "vithyea";;
            _testObj.RemoveIdentifier(IdToRemove);
            Assert.That(_testObj.AreYou(IdToRemove), Is.False);
        }

        [Test]
        public void PrivilegeEscalationTest_CorrectPin()
        {
            string correctPin = "0743";
            _testObj.PrivilegeEscalation(correctPin);
            Assert.That(_testObj.FirstId, Is.EqualTo("0007"));
        }
        
        [Test]
        public void PrivilegeEscalationTest_WrongPin()
        {
            string wrongPin = "9999";
            _testObj.PrivilegeEscalation(wrongPin);
            Assert.That(_testObj.FirstId, Is.EqualTo("vithyea"));
        }
    }
}

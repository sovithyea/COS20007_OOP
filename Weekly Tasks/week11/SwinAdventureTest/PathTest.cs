using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class MoveSystemTests
    {
        [Test]
        public void PathMovesPlayerToDestination()
        {
            Location beach = new Location(new[] { "beach" }, "Beach", "Sunny beach");
            Location cave = new Location(new[] { "cave" }, "Cave", "Dark cave");
            Player player = new Player("Kenji", "The brave");
            player.Location = beach;
            SwinAdventure.Path toCave = new SwinAdventure.Path(new[] { "east" }, cave, "Cave Path", "To the cave");

            toCave.Mover(player);

            Assert.That(player.Location, Is.EqualTo(cave));
        }

        [Test]
        public void LocationReturnsPathByDirection()
        {
            Location town = new Location(new[] { "town" }, "Town", "Busy town");
            Location forest = new Location(new[] { "forest" }, "Forest", "Green forest");
            SwinAdventure.Path toForest = new SwinAdventure.Path(new[] { "north" }, forest, "Forest Path", "Trail to forest");
            town.AddPath(toForest);

            GameObject result = town.Locate("north");

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<SwinAdventure.Path>());
            Assert.That(result.Name, Is.EqualTo("Forest Path"));
        }

        [Test]
        public void PlayerMovesWithValidDirection()
        {
            Location beach = new Location(new[] { "beach" }, "Beach", "Sunny");
            Location cave = new Location(new[] { "cave" }, "Cave", "Dark");
            Player player = new Player("K", "P");
            player.Location = beach;
            SwinAdventure.Path path = new SwinAdventure.Path(new[] { "east" }, cave, "Cave Path", "Tunnel to cave");
            beach.AddPath(path);
            MoveCommand moveCmd = new MoveCommand();
            string[] input = { "move", "east" };

            string result = moveCmd.Execute(player, input);

            Assert.That(player.Location, Is.EqualTo(cave));
            Assert.That(result.ToLower(), Does.Contain("cave"));
        }

        [Test]
        public void PlayerDoesNotMoveWithInvalidDirection()
        {
            Location mountain = new Location(new[] { "mountain" }, "Mountain", "Snowy");
            Player player = new Player("K", "P");
            player.Location = mountain;
            MoveCommand moveCmd = new MoveCommand();
            string[] input = { "move", "south" };

            string result = moveCmd.Execute(player, input);

            Assert.That(player.Location, Is.EqualTo(mountain));
            Assert.That(result.ToLower(), Does.Contain("no path"));
        }
    }
}

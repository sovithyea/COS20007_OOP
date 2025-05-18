using System;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave"}) { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1)
            {
                return p.Location.ListPath();
            }

            if (text.Length != 2)
            {
                return "Move where?";
            }

            string direction = text[1];
            Path path = p.Location.GetPath(direction);

            if (path == null)
            {
                return "There is no path to " + direction;
            }

            path.Mover(p);
            return path.FullDescription;
        }
    }
}

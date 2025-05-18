using System;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _location;

        public Path(string[] ids, Location location, string name, string desc) : base(ids, name, desc)
        {
            _location = location;
        }

        public void Mover(Player p)
        {
            p.Location = _location;
        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription} You have arrived at " + _location.Name;
            }
        }


    }
}


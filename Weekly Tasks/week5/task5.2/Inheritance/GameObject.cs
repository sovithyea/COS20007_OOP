namespace SwinAdventure
{   public abstract class GameObject
    {
        protected string _name;
        protected string _description;
        
        public GameObject(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string Name => _name;

        public virtual string ShortDescription => $"a {_name}";

        public virtual string FullDescription => _description;
    }
}
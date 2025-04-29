namespace SwinAdventure
{   public abstract class GameObject : IdentifiableObject
    {
        protected string _name;
        protected string _description;
        
        public GameObject(string[] ids, string name, string description) : base(ids)
        {
            _name = name;
            _description = description;
        }
        public string Name => _name;

        public virtual string ShortDescription => $"a {_name}";

        public virtual string FullDescription => _description;
    }
}
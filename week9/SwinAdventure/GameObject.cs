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
        public virtual string ShortDescription => $"{_name}";
        public virtual string FullDescription => _description;
        public virtual void SaveTo(StreamWriter writer){
            //read the GameObject's name from the file
            writer.WriteLine(_name);
            //save the GameObject's description into the file as well
            writer.WriteLine(_description);
        }
        public virtual void LoadFrom(StreamReader reader){
            //read the GameObject's name from the file
            _name = reader.ReadLine();
            //read the GameObject's description from the file as well
            _description = reader.ReadLine();
        }

    }
}
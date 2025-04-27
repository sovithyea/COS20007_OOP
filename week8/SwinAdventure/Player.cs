namespace SwinAdventure
{
    private Inventory _inventory;
    public Player(string name, string desc) : base(new string[] { "me", "inventory"}, name, desc)
    {
        _inventory = new Inventory();
    }
    public Inventory Inventory
    {
        get {
            return _inventory;
        }
    }
    public GameObject Locate(string id)
    {
        if (AreYou(id))
        {
            return this;
        }
        else
        {
            return Inventory.Fetch(id);
        }
    }
    public override string FullDescription
    {
        get
        {
            return $"You are {Name} {base.FullDesciption}\n" + "You are carrying:\n" + _inventory.ItemList;
        }
    }
}
namespace SwinAdventure
{
    public class Item
    {
        private string[] _identifiers;
        public string Name { get; private set; }
        public string FullDescription { get; private set; }

        public Item(string[] identifiers, string name, string fullDescription)
        {
            _identifiers = identifiers;
            Name = name;
            FullDescription = fullDescription;
        }

        public string ShortDescription
        {
            get { return $"a {Name}"; }
        }

        public bool AreYou(string id)
        {
            foreach (string identifier in _identifiers)
            {
                if (identifier.ToLower() == id.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void PrivilegeEscalation(string pin)
        {
            string pinLast4 = "0743";
            string tutorialID = "0007";

            if (pin == pinLast4 && Name != "")
            {
                SetName(tutorialID);
            }
        }
    }
}
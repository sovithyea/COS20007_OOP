using System;

namespace SwinAdventure
{
    public class Item : IdentifiableObject
    {
        private string _description;
        private string _name;

        public Item(string[] idents, string name, string desc) : base(idents)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get { return "a " + _name + " (" + FirstId + ")"; }
        }

        public string LongDescription
        {
            get { return _description; }
        }

        public new void PrivilegeEscalation(string pin)
        {
            string pinLast4 = "0743";
            string tutorialID = "0007";

            if (pin == pinLast4 && FirstId != "")
            {
                AddIdentifier(tutorialID);
            }
        }
    }
}

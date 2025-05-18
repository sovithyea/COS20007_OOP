using System;
namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand(string[] ids) : base(ids)
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1 && text[0].ToLower() == "look")
            {
                return p.Location.FullDescription;
            }

            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }

            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }

            if (text[1].ToLower() != "at")
            {
                return "What do you want to look at?";
            }

            if (text.Length == 5 && text[3].ToLower() != "in")
            {
                return "What do you want to look in?";
            }

            string itemId = text[2];
            IHaveInventory container;

            if (text.Length == 3)
            {
                container = p;
            }
            else
            {
                container = FetchContainer(p, text[4]);
                if (container == null)
                {
                    return $"I cannot find the {text[4]}";
                }
            }

            return LookAtIn(itemId, container);
        }
        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (p.AreYou(containerId))
                return p;

            if (p.Location != null && p.Location.AreYou(containerId))
                return p.Location;

            GameObject obj = p.Locate(containerId);
            return obj as IHaveInventory;
        }
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject itm = container.Locate(thingId);
            if (itm == null)
            {
                return $"I cannot find the {thingId} in {container.Name}";
            }
            return itm.FullDescription;
        }
    }
}

using System.Collections.Generic;

namespace SwinAdventure
{public class IdentifiableObject
{
    private List<string> _identifiers = new List<string>();

    public IdentifiableObject(string[] ids, string name, string desc) : base(name, desc)
    {
        foreach (string id in ids)
        {
            AddIdentifier(id);
        }
    }

    public bool AreYou(string id)
    {
        return _identifiers.Contains(id.ToLower());
    }

    public void AddIdentifier(string id)
    {
        _identifiers.Add(id.ToLower());
    }

    public string FirstId => _identifiers.Count > 0 ? _identifiers[0] : "";

    public override string ShortDescription => $"a {_name} ({FirstId})";
    }
}
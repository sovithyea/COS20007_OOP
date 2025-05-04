using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                    return _identifiers[0];
                return "";
            }
        }

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (String ident in idents)
            {
                AddIdentifier(ident);
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public bool AreYou(string id)
        {
             return _identifiers.Contains(id.ToLower()) ;
        }
    }
}

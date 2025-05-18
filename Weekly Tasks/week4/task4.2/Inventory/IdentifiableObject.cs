using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (string ident in idents)
            {
                _identifiers.Add(ident.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers.First();
                }
                else
                {
                    return "";
                }
            }
        }

        public void AddIdentifier(string id)
        {
            id = id.ToLower();
            if (!_identifiers.Contains(id))
            {
                _identifiers.Add(id);
            }
        }

        public void RemoveIdentifier(string id)
        {
            _identifiers.Remove(id.ToLower());
        }

        public void PrivilegeEscalation(string pin)
        {
            string studentIDLast4 = "0743"; 
            string tutorialID = "007"; 

            if (pin == studentIDLast4 && _identifiers.Count > 0)
            {
                _identifiers[0] = tutorialID;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Evo.Factions
{
    [System.Serializable]
    public class Faction
    {
        //maybe add more stuff later like golas that can condflict with other factions, like restoring america, or stealing stuff
        string name;
        string description;



        private ObservableCollection<FactionReputation> reputation = new ObservableCollection<FactionReputation>();

        public Faction(string name, string description, ObservableCollection<FactionReputation> reputation)
        {
            this.Name = name;
            this.Description = description;
            this.Reputation = reputation;
        }

        public Faction(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Reputation = reputation;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public ObservableCollection<FactionReputation> Reputation { get => reputation; set => reputation = value; }

        public void AddFactionRep(FactionReputation factionReputation) 
        {
            reputation.Add(factionReputation);
        
        }


        public void AddFactionRep(Faction faction, decimal reputationNumber)
        {
            FactionReputation factionRep = new FactionReputation(faction, reputationNumber);
            reputation.Add(factionRep);

        }

    }
}

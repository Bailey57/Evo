using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.Factions
{
    public class FactionReputation
    {

        private Faction faction;
        private decimal reputation;

        public FactionReputation(Faction faction, decimal reputation)
        {
            this.Faction = faction;
            this.Reputation = reputation;
        }

        public Faction Faction { get => faction; set => faction = value; }
        public decimal Reputation { get => reputation; set => reputation = value; }
    }




}

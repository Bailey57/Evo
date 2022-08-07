using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Evo.Factions
{
    [System.Serializable]
    public static class FactionFactory
    { 

        
        private static ObservableCollection<Faction> factionList = new ObservableCollection<Faction>();

        public static ObservableCollection<Faction> FactionList { get => factionList; set => factionList = value; }



        //string name, string description, ObservableCollection<FactionReputation> reputation
        //100 best, -100 worst, 
        /**
         * 1: Evo
         * 2: USMilitary
         * 3: NC Militia
         * 4: Player
         * 
         * 
         */
        public static ObservableCollection<Faction> MakeGameFactions() 
        {
            Faction Evo = new Faction("Evos", "The Evo faction");
            Faction USMilitary = new Faction("US Military", "The United States military");
            Faction NCMilitia = new Faction("NC Militia", "The militia of NC");

            Faction PlayerFaction = new Faction("", "");


            Evo.AddFactionRep(USMilitary, -100);
            Evo.AddFactionRep(NCMilitia, -100);
            Evo.AddFactionRep(PlayerFaction, -100);

            USMilitary.AddFactionRep(Evo, -100);
            USMilitary.AddFactionRep(NCMilitia, 100);
            USMilitary.AddFactionRep(PlayerFaction, 0);

            NCMilitia.AddFactionRep(Evo, -100);
            NCMilitia.AddFactionRep(USMilitary, 100);
            NCMilitia.AddFactionRep(PlayerFaction, 0);

            PlayerFaction.AddFactionRep(Evo, 0);
            PlayerFaction.AddFactionRep(USMilitary, 0);
            PlayerFaction.AddFactionRep(NCMilitia, 0);


            FactionList.Add(Evo);
            FactionList.Add(USMilitary);
            FactionList.Add(NCMilitia);
            FactionList.Add(PlayerFaction);

            return FactionList; 
        }




        public static bool IsEnemyFaction(Faction mainFaction, Faction secondaryFaction) 
        {
            if (mainFaction == null || secondaryFaction == null) 
            {
                return false;
            }
            for (int i = 0; i < mainFaction.Reputation.Count; i++) 
            {
                if (mainFaction.Reputation[i].Faction == secondaryFaction) 
                {
                    if (mainFaction.Reputation[i].Reputation <= -25)
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }


    }
}

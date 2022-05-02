using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Evo
{
    [System.Serializable]
    public class PointOfInterest
    {
        private string name;
        private string description;
        private GameObjectPos gameObjectPos;
        //add List that keeps track of map square areas

        
        public PointOfInterest(string name, string description, GameObjectPos gameObjectPos) 
        {
            setName(name);
            setDescription(description);
            setGameObjectPos(gameObjectPos);
        }


        public GameObjectPos getGameObjectPos() 
        {
            return this.gameObjectPos;
        }

        public void setGameObjectPos(GameObjectPos gameObjectPos)
        {
            this.gameObjectPos = gameObjectPos;
        }


        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }


        public string getDescription()
        {
            return this.description;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }





        public override string ToString()
        {
            return getName();
        }

    }
}

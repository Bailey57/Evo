using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.Calculator.Destinations
{
    [System.Serializable]
    public class Destination
    {
        string name;
        string description;
        GameObjectPos gameObjectPos;




        public Destination(string name, string description, GameObjectPos gameObjectPos) 
        {
            SetName(name);
            SetDescription(description);
            SetGameObjectPos(gameObjectPos);
        }



        public string GetName()
        {
            return this.name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetDescription()
        {
            return this.description;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }

        public GameObjectPos GetGameObjectPos() 
        {
            return this.gameObjectPos;
        }
        public void SetGameObjectPos(GameObjectPos gameObjectPos) 
        {
            this.gameObjectPos = gameObjectPos;
        }


        public override string ToString() 
        {
            string output = "";
            output = this.GetName() + ": \n" + this.GetDescription() + "\nX: " + this.GetGameObjectPos().GetOverallXPosition() + "\nY: " 
                + this.GetGameObjectPos().GetOverallYPosition();
            
            
            return output;
        }
    }
}

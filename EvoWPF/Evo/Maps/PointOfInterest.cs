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
        private string info;
        private GameObjectPos gameObjectPos;
        //add List that keeps track of map square areas

        
        public PointOfInterest(string name, string description, GameObjectPos gameObjectPos) 
        {
            SetName(name);
            SetDescription(description);
            SetGameObjectPos(gameObjectPos);
        }


        public GameObjectPos GetGameObjectPos() 
        {
            return this.gameObjectPos;
        }

        public void SetGameObjectPos(GameObjectPos gameObjectPos)
        {
            this.gameObjectPos = gameObjectPos;
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


        public string GetInfo()
        {
            string info = GetName() + ": " + GetDescription() + "\n" + this.GetGameObjectPos().toString();
            SetInfo(info);
            return info;
        }

        public void SetInfo(string info)
        {
            this.info = info;
        }


        public override string ToString()
        {
            return GetName();
        }

    }
}

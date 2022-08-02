using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Evo.Calculator.Destinations
{
    [System.Serializable]
    public class Path
    {
        private bool repeatPath;

        private ObservableCollection<Destination> destinationList = new ObservableCollection<Destination>();



        public Path(bool repeatPath)
        {
            SetRepeatPath(repeatPath);
        }


        public bool GetRepeatPath()
        {
            return this.repeatPath;
        }
        public void SetRepeatPath(bool repeatPath)
        {
            this.repeatPath = repeatPath;
        }



        public ObservableCollection<Destination> GetDestinationList()
        {
            return destinationList;
        }
        public void SetDestinationList(ObservableCollection<Destination> destinationList)
        {
            this.destinationList = destinationList;
        }


        public void AddDestination(Destination destination)
        {
            this.destinationList.Add(destination);
        }

        public void RemoveDestination(Destination destination)
        {
            this.destinationList.Remove(destination);
        }



        public Destination GetCurrentDestination()
        {
            if (destinationList.Count > 0) 
            {
                return this.destinationList[0];
            }
            return null;
            
        }

        public void SetNewCurrentDestination(Destination destination) 
        {

            if (destinationList != null && destinationList.Count() >= 0) 
            {
                for (int i = destinationList.Count(); i >= destinationList.Count(); i--)
                {
                    AddDestination(destinationList[i]);
                    RemoveDestination(destinationList[i]);
                    

                }
                destinationList[0] = destination;
            }

            
        }



        public void GoToNextDestination()
        {
            if (!this.GetRepeatPath())
            {

                //nextDestination = currentDestination;
                RemoveDestination(destinationList[0]);

            }
            else 
            {
                Destination destination = this.destinationList[0];
                RemoveDestination(destinationList[0]);
                AddDestination(destination);
            }
            
        }



        public Destination MakeNewDestinationFromGameObjectPos(string name, string description, GameObjectPos gameObjectPos) 
        {
            Destination destination = new Destination(name, description, gameObjectPos);
            this.AddDestination(destination);
            return destination;
        }




        public string GetCurrentDestinationToString() 
        {
            if (destinationList.Count > 0 && destinationList[0] != null)
            {
                return destinationList[0].ToString();
            }
            else 
            {
                return "No current destination";
            }
        }

        public bool CurrentDestinationReached(GameObjectPos currentPos) 
        {
            double meters = 1;
            if (currentPos.GetDistanceFromGameObjectPos(this.GetCurrentDestination().GetGameObjectPos()) < meters) 
            {
                return true;
            }
            
            return false;
        }





    } 
}

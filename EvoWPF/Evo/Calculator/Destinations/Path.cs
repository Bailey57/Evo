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

        private Destination currentDestination;


        private Destination nextDestination;



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
        public Destination GetDestination()
        {
            return this.currentDestination;
        }
        public void SetDestination(Destination currentDestination) 
        {
            this.currentDestination = currentDestination;
        }


        public void NextDestination()
        {
            if (!this.GetRepeatPath()) 
            {
                nextDestination = currentDestination;
                RemoveDestination(currentDestination);
            }    
            
        }










    } 
}

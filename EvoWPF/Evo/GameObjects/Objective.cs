using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.GameObjects
{
    [System.Serializable]
    internal class Objective
    {

        private GameObject target;
        private string action;
        private double priority;

        //private int MyProperty { get; set; }


        public Objective(GameObject target, string action, double priority)
        {
            this.target = target;
            this.action = action;
            this.priority = priority;
        }




    }
}
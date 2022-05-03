using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo
{

	
	public abstract class EntityAction {

		//highest number action is prioritized 0-100
		private double priority;

		//action being performed on
		private GameObject target;


		//performer - the entity performing the action 



		public double GetPriority() 
		{
			return this.priority;
		}
		public void SetPriority(double priority)
		{
			this.priority = priority;
		}

		public GameObject GetTarget()
		{
			return this.target;
		}
		public void SetTarget(GameObject target)
		{
			this.target = target;
		}


		/**
		 * @return time left
		 */
		public abstract double PerformAction(Entity target);






	}

}

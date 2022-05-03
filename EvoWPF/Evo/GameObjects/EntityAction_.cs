using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo
{
	//package wasteland.entity;
	
	public class EntityAction_ {

		//highest number action is prioritized 0-100
		private double priority;

		//action being performed on
		//private GameObject target;


		//performer - the entity performing the action 




		public void AttackGameObject(Entity performer, GameObject target)
		{

		}

		public void ApproachGameObject(Entity performer, GameObject target)
		{


		}

		//public void bandageSelfWound() {		
		//}

		public void bandageWound(Animal wounded, BodyPart bodyPart, Wound wound) {
		
		for (int i = 0; i < wounded.bodyParts.GetLength(0); i++) {
			if (wounded.bodyParts[i] == bodyPart) {
				wounded.bodyParts[i].removeWound(wound);
			}
			
		}		
	}



		public void PatrollArea(Entity performer, double patrollRadius)
		{
			
		}

		public void GuardArea(Entity performer, double patrollRadius)
		{

		}

		public void GuardGameObject(Entity performer, GameObject target) 
		{
		
		}

		public void FollowGameObject(Entity performer, GameObject target) 
		{
		
		}

		public void GameObject(Entity performer, GameObject target)
		{

		}





		//public bool putOnWearable() {
		//return false;
		//}







	}

}

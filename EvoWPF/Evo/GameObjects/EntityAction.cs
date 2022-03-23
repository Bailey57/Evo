using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo
{
	//package wasteland.entity;
	
	public class EntityAction {
	
	

	
	
	//public void bandageSelfWound() {		
	//}
	
	public void bandageWound(Animal wounded, BodyPart bodyPart, Wound wound) {
		
		for (int i = 0; i < wounded.bodyParts.GetLength(0); i++) {
			if (wounded.bodyParts[i] == bodyPart) {
				wounded.bodyParts[i].removeWound(wound);
			}
			
		}		
	}



		public void PatrollArea(Entity entity, double patrollRadius)
		{
			
		}

		public void GuardArea(Entity entity, double patrollRadius)
		{

		}

		public void GuardGameObject() 
		{
		
		}

		public void FollowGameObject() 
		{
		
		}

		public void ApproachGameObject()
		{

		}





		//public bool putOnWearable() {
		//return false;
		//}







	}

}

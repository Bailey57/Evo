using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo
{
	//package wasteland.entity;
	
	public class EntityAction {

		//highest number action is prioritized 0-100
		private double priority;

		//action being performed on
		private GameObject target;


		//performer - the entity performing the action 




		public void AttackGameObject(Entity performer, GameObject target)
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

		public bool LoadGun(Entity performer, Gun gun, Magazine magazine) 
		{
			if (TakeOutMagazine(performer, gun, magazine)) 
			{
				performer.addObjectStringEvents("Ejected " + magazine.getObjectName() + " from " + gun.getObjectName() + ".\n");
			}
			gun.setMagazine(magazine);
			performer.getInventory().Remove(magazine);

			performer.addObjectStringEvents("Loaded " + magazine.getObjectName() + " into " + gun.getObjectName() + ".");
			return true;
		}

		public bool TakeOutMagazine(Entity performer, Gun gun, Magazine magazine)
		{
			if (gun.getMagazine() != null)
			{
				performer.addItemToInventory(magazine);
				gun.setMagazine(null);
				return true;
			}



			return false;
		}

		public int FillMagazine(Entity performer, Magazine magazine)
		{
			int numberLoaded = 0;
			for (int i = 0; i < performer.getInventory().Count; i ++) 
			{
				if (performer.getInventory()[i] is ProjectileAmmo && ((ProjectileAmmo)performer.getInventory()[i]).getDiameter() ==  magazine.getMagProjectileDiamiter()) 
				{
					magazine.addBullet(((ProjectileAmmo)performer.getInventory()[i]));
					performer.getInventory().Remove(performer.getInventory()[i]);
					numberLoaded++;
				}
			}
			performer.addObjectStringEvents("Filled " + magazine.getObjectName() + " with " + numberLoaded + " rounds.");
			return numberLoaded;
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

		public void ApproachGameObject(Entity performer, GameObject target)
		{

		}





		//public bool putOnWearable() {
		//return false;
		//}







	}

}

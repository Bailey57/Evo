using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo
{
	//package wasteland.entity;

	public static class EntityAction
	{

		//highest number action is prioritized 0-100
		//private double priority;

		//action being performed on
		//private GameObject target;


		//performer - the entity performing the action 

		public static double timeAfterAction(double timeLeft, double timeNeeded) 
		{
			timeLeft = -timeNeeded;
			return timeLeft;
		}


		public static void AttackGameObject(Entity performer, GameObject target)
		{

		}

		//public void bandageSelfWound() {		
		//}

		public static void bandageWound(Animal wounded, BodyPart bodyPart, Wound wound)
		{
			

			for (int i = 0; i < wounded.bodyParts.GetLength(0); i++)
			{
				if (wounded.bodyParts[i] == bodyPart)
				{
					wounded.bodyParts[i].removeWound(wound);
				}

			}
		}

		public static bool LoadGun(Entity performer, Gun gun, Magazine magazine)
		{
			if (performer.GetSecondsLeft() < 2)
			{
				return false;

			}
			performer.AddSecondsLeft(-2);



			if (TakeOutMagazine(performer, gun, magazine))
			{
				performer.addObjectStringEvents("Ejected " + magazine.getObjectName() + " from " + gun.getObjectName() + ".\n");
			}
			gun.setMagazine(magazine);
			performer.getInventory().Remove(magazine);

			performer.addObjectStringEvents("Loaded " + magazine.getObjectName() + " into " + gun.getObjectName() + ".");
			return true;
		}

		public static bool TakeOutMagazine(Entity performer, Gun gun, Magazine magazine)
		{


			if (performer.GetSecondsLeft() < 1)
			{
				return false;

			}
			performer.AddSecondsLeft(-1);


			if (gun.getMagazine() != null)
			{
				performer.addItemToInventory(magazine);
				gun.setMagazine(null);
				return true;
			}



			return false;
		}

		public static int FillMagazine(Entity performer, Magazine magazine)
		{
			if (performer.GetSecondsLeft() < .2)
			{
				return 0;

			}
			performer.AddSecondsLeft(-2);



			int numberLoaded = 0;
			for (int i = 0; i < performer.getInventory().Count; i++)
			{
				if (performer.getInventory()[i] is ProjectileAmmo && ((ProjectileAmmo)performer.getInventory()[i]).getDiameter() == magazine.getMagProjectileDiamiter())
				{
					magazine.addBullet(((ProjectileAmmo)performer.getInventory()[i]));
					performer.getInventory().Remove(performer.getInventory()[i]);
					numberLoaded++;
				}
			}
			performer.addObjectStringEvents("Filled " + magazine.getObjectName() + " with " + numberLoaded + " rounds.");
			return numberLoaded;
		}

		 


		public static bool AttackGameObjectMelee(Entity performer, GameObject target) 
		{
			if (performer.GetSecondsLeft() < .5) 
			{
				return false;

			}
			performer.AddSecondsLeft(-.5);


			if (!performer.inAttackRange(target))
			{
				return false;
			}
			else 
			{
				//add more calculations regurarding kenetic energy based on strength or whatever attack is used 
				if (performer.getEntityWeapon() == null)
				{
					Wound punchWound = new Wound("Punch wound", 0, 0, 0, "hurts but didnt really do anything");

					target.getGameObjectHitbox().getBodyParts()[0].addWound(punchWound);

					performer.addObjectStringEvents("Punched " + target.getObjectName());
					target.addObjectStringEvents("Got punched by " + performer.getObjectName());
				}
				else
				{
					Wound hitWound = new Wound("Hit wound", 1, 1, 1, "");

					target.getGameObjectHitbox().getBodyParts()[0].addWound(hitWound);

					performer.addObjectStringEvents("Hit " + target.getObjectName() + " using " + performer.getEntityWeapon().getObjectName());
					target.addObjectStringEvents("Got hit by " + performer.getObjectName() + " using " + performer.getEntityWeapon().getObjectName());
				}

			}

			//later add dodge and block checks 

			return true;
		}



		
		public static void AttackAndPursueGameObjectMelee(Entity performer, GameObject target)
		{
			if (performer.getAttackRange() < performer.getDistanceFromObject(target)) 
			{
				ApproachGameObject(performer, target);
			}
			else 
			{
				AttackGameObjectMelee(performer, target);
			}

		}

		public static void PatrollArea(Entity performer, double patrollRadius)
		{

		}

		public static void GuardArea(Entity performer, double patrollRadius)
		{

		}

		public static void GuardGameObject(Entity performer, GameObject target)
		{

		}

		public static void FollowGameObject(Entity performer, GameObject target)
		{

		}

		public static void ApproachGameObject(Entity performer, GameObject target)
		{
			if (performer.getAttackRange() < performer.getDistanceFromObject(target)) 
			{
				//performer.getMovementSpeed()


				if (performer.getGameObjectPos().GetOverallYPosition() > target.getGameObjectPos().GetOverallYPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("N", performer.getMovementSpeed() * performer.GetSecondsLeft());
					
				}
				else if (performer.getGameObjectPos().GetOverallYPosition() < target.getGameObjectPos().GetOverallYPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("S", performer.getMovementSpeed() * performer.GetSecondsLeft());
					
				}
				else if (performer.getGameObjectPos().GetOverallXPosition() < target.getGameObjectPos().GetOverallXPosition()) 
				{
					performer.getGameObjectPos().movePositionOnMapArea("E", performer.getMovementSpeed() * performer.GetSecondsLeft());
					
				}
				else if (performer.getGameObjectPos().GetOverallXPosition() > target.getGameObjectPos().GetOverallXPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("W", performer.getMovementSpeed() * performer.GetSecondsLeft());
					
				}
				//performer.addObjectStringEvents("Got closer to " + target.getObjectName());
			}

		}


		public static void ApproachGameObjectTenthOfASecond(Entity performer, GameObject target)
		{
			if (performer.getAttackRange() < performer.getDistanceFromObject(target))
			{
				//performer.getMovementSpeed()
				double tenthOfASecond = .1;

				if (performer.GetSecondsLeft() < .1)
				{
					return;
				}
				performer.AddSecondsLeft(-.1);


				if (performer.getGameObjectPos().GetOverallYPosition() > target.getGameObjectPos().GetOverallYPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("N", performer.getMovementSpeed() * tenthOfASecond);

				}
				else if (performer.getGameObjectPos().GetOverallYPosition() < target.getGameObjectPos().GetOverallYPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("S", performer.getMovementSpeed() * tenthOfASecond);

				}
				else if (performer.getGameObjectPos().GetOverallXPosition() < target.getGameObjectPos().GetOverallXPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("E", performer.getMovementSpeed() * tenthOfASecond);

				}
				else if (performer.getGameObjectPos().GetOverallXPosition() > target.getGameObjectPos().GetOverallXPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("W", performer.getMovementSpeed() * tenthOfASecond);

				}
				//performer.addObjectStringEvents("Got closer to " + target.getObjectName());
			}

		}

		public static void HorizontalDegreesToGameObject(Entity performer, GameObject target) 
		{
			
		}





		//public bool putOnWearable() {
		//return false;
		//}







	}

}
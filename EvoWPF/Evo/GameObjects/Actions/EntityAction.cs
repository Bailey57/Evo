using Evo.GameObjects.HitBoxes;
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
			ApproachGameObjectPosTenthOfASecond(performer, target.getGameObjectPos());

		}




		public static void ApproachPOITenthOfASecond(Entity performer, PointOfInterest pointOfInterest)
		{
			ApproachGameObjectPosTenthOfASecond(performer, pointOfInterest.GetGameObjectPos());

		}



		public static void ApproachGameObjectPos(Entity performer, GameObjectPos gameObjectPos, double secondsPassed)
		{
			if (performer.getAttackRange() < performer.getGameObjectPos().GetDistanceFromGameObjectPos(gameObjectPos))
			{
				//performer.getMovementSpeed()
				double tenthOfASecond = secondsPassed;

				if (performer.GetSecondsLeft() < secondsPassed)
				{
					return;
				}
				performer.AddSecondsLeft(-secondsPassed);


				if (performer.getGameObjectPos().GetOverallYPosition() > gameObjectPos.GetOverallYPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("N", performer.getMovementSpeed() * tenthOfASecond);

				}
				else if (performer.getGameObjectPos().GetOverallYPosition() < gameObjectPos.GetOverallYPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("S", performer.getMovementSpeed() * tenthOfASecond);

				}
				else if (performer.getGameObjectPos().GetOverallXPosition() < gameObjectPos.GetOverallXPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("E", performer.getMovementSpeed() * tenthOfASecond);

				}
				else if (performer.getGameObjectPos().GetOverallXPosition() > gameObjectPos.GetOverallXPosition())
				{
					performer.getGameObjectPos().movePositionOnMapArea("W", performer.getMovementSpeed() * tenthOfASecond);

				}
				//performer.addObjectStringEvents("Got closer to " + pointOfInterest.getObjectName());
			}

		}

		public static void ApproachGameObjectPosTenthOfASecond(Entity performer, GameObjectPos gameObjectPos)
		{
			ApproachGameObjectPos(performer, gameObjectPos, .1);

		}



		public static void HorizontalDegreesToGameObject(Entity performer, GameObject target) 
		{
			
		}

		public static bool FireGunAtEntityCenterOfMass(Entity shooter, Entity target)
		{
			return FireGunAtEntityBodyPart(shooter, target, null);


		}


			public static bool FireGunAtEntityBodyPart(Entity shooter, Entity target, BodyPart bodyPart)
		{
			//double 0
			if (shooter.getEntityWeapon() == null || !(shooter.getEntityWeapon() is Gun)) 
			{
				return false;
			}

			bool targetHit = false;
			double distanceFromTarget = shooter.getDistanceFromObject(target);



			if (((Gun)shooter.getEntityWeapon()).getLoadedProjectile() != null && target.getGameObjectHitbox() != null)
			{

				//add code to perception check and if failed they dont know what it is
				if (((Gun)shooter.getEntityWeapon()).getMagazine() != null && ((Gun)shooter.getEntityWeapon()).getMagazine().getBulletsInMag()[0] != null)
				{
					shooter.addObjectStringEvents("\nShot at " + target + " using " + ((Gun)shooter.getEntityWeapon()).getObjectName() + " with " + ((Gun)shooter.getEntityWeapon()).getMagazine().getBulletsInMag()[0].getObjectName() + "\n");
					target.addObjectStringEvents("\nShot at by " + shooter.getObjectName() + " using " + ((Gun)shooter.getEntityWeapon()).getObjectName() + " with " + ((Gun)shooter.getEntityWeapon()).getMagazine().getBulletsInMag()[0].getObjectName() + "\n");
					shooter.addObjectStringEvents("\nInitial velocity of " + ((Gun)shooter.getEntityWeapon()).getMagazine().getBulletsInMag()[0].getObjectName() + ": " + ((Gun)shooter.getEntityWeapon()).getMagazine().getBulletsInMag()[0].getInitV() + " mps\n");
				}
				else
				{
					shooter.addObjectStringEvents("\nShot at " + target + " using " + ((Gun)shooter.getEntityWeapon()).getObjectName() + "\n");
					target.addObjectStringEvents("\nShot at by " + shooter.getObjectName() + " using " + ((Gun)shooter.getEntityWeapon()).getObjectName() + "\n");
				}


				if (bodyPart != null) 
				{
					shooter.addObjectStringEvents("\nTargeting " + bodyPart.getName());
				}


				RandomNumbers randNum = new RandomNumbers();
				BulletPenetration panCalc = new BulletPenetration(((Gun)shooter.getEntityWeapon()).getLoadedProjectile(), distanceFromTarget);

				
				double distanceIn_mm_fromAimPoint = randNum.rollRandDouble(shooter.getTargetGroupSize(target), 0);
				//c = Sqrt(a^2 + b^2), a^2 + b^2 = c^2
				//b^2 = c^2 - a^2, rng a

				double side_y = randNum.rollRandDouble(distanceIn_mm_fromAimPoint, 0);
				double base_x = Math.Pow(distanceIn_mm_fromAimPoint, 2) - Math.Pow(side_y, 2);

				double yPosHit = 0;
				double xPosHit = 0;

				if (randNum.rollRandInt(1, 0) == 1)
				{
					side_y *= -1;
				}
				if (randNum.rollRandInt(1, 0) == 1)
				{
					base_x *= -1;
				}


				//target.getGameObjectHitbox().onHitboxCheck(base_x, side_y);


				//each chance to be negative


				//yPosHit = target.getGameObjectHitbox().getHitboxCenterY() + side_y;
				//1180 is center y pos of human hitbox
				double damage = 0;
				if (bodyPart == null)
				{

					yPosHit = 1180 + side_y;
					xPosHit = target.getGameObjectHitbox().getHitboxCenterX() + base_x;

					panCalc.setFinalV(panCalc.finalVelocity());
					panCalc.setDistance(0);
					damage = panCalc.currentKeneticEnergy();
					((Gun)shooter.getEntityWeapon()).setLastDamage(damage);

				}
				else 
				{

					yPosHit = bodyPart.getyCenter() + side_y;
					xPosHit = bodyPart.getxCenter() + base_x;

					panCalc.setFinalV(panCalc.finalVelocity());
					panCalc.setDistance(0);
					damage = panCalc.currentKeneticEnergy();
					((Gun)shooter.getEntityWeapon()).setLastDamage(damage);

				}
				




				//;


				target.getGameObjectHitbox().getHitboxCenterY();



				if (target.getGameObjectHitbox().bodyPartsHitCheck(xPosHit, yPosHit) != null)
				{
					//target is hit

					//target.gameObjectHitbox.projectileImpactHitbox(loadedProjectile, side_y, base_x);

					shooter.addObjectStringEvents(panCalc.penetraitHitBox(target.getGameObjectHitbox(), xPosHit, yPosHit, 0));
					if (target.getGameObjectHitbox().VitalOrganDamaged()) 
					{
						target.alive = false;
					}
					//add damage/wound

				}



				if (!Double.IsNaN(damage))
				{
					target.setIntegraty(target.getIntegraty() - ((Gun)shooter.getEntityWeapon()).getLastDamage());
					targetHit = true;

					// gain accuracy when you hit things successfully, get more for hitting
					// something alive
					if (target is Entity)
					{
						if (((Entity)target).isAlive())
						{
							shooter.setAccuracy(shooter.getAccuracy() + ((distanceFromTarget + 1) / 100));
						}
						else
						{
							shooter.setAccuracy(shooter.getAccuracy() + ((distanceFromTarget + 1) / 200));
						}

					}
					else
					{
						shooter.setAccuracy(shooter.getAccuracy() + ((distanceFromTarget + 1) / 200));
					}

					if (target is Entity)
					{

						//((Entity)target).aliveCheck();

						if (shooter.isThePlayer)
						{
							((Entity)target).DeathCheckCloseToPlayer(shooter);
						}
						else
						{
							((Entity)target).DeathCheck();
						}


					}
					else
					{
						target.integrityCheck();
					}

				}

				((Gun)shooter.getEntityWeapon()).cycleGunAfterFiring();




			}
			else if (((Gun)shooter.getEntityWeapon()).getLoadedProjectile() == null)
			{
				((Gun)shooter.getEntityWeapon()).addObjectStringEvents("\nThe gun made a clicking noise but nothing happened\n");
				shooter.addObjectStringEvents("\nThe gun made a clicking noise but nothing happened\n");
			}

			return targetHit;
			// double targetGroupSize = shooter.getTargetGroupSize(target);

		}



		//public bool putOnWearable() {
		//return false;
		//}







	}

}
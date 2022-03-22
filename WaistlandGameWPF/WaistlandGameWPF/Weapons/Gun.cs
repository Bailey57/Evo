using System;


namespace WaistlandGameWPF
{
	[System.Serializable]
	public class Gun : BaseItem
	{

	// Gun mosin = new Gun();

		/**
		 * 
		 */

	double ammoSize;

	Magazine magazine;

	ProjectileAmmo loadedProjectile;// aka bullet in chamber

	bool cockable;

	bool magazineFed;

	bool boltAction;

	public double meanTimeBetweenFailure;

	public double maxFiringRange;

	public GunAttachments[] attachments;

	public double lastDamage;

	// might move to Ammo class, ammoDispersion
	public double bulletDispersion;

	public Gun(GameObjectPos gameObjectPos, String objectName, double ammoSize) : base(gameObjectPos, objectName, 1.4)
		{
		this.ammoSize = ammoSize;

	}

	public Gun(GameObjectPos gameObjectPos, String objectName, double ammoSize, bool cockable, bool magazineFed) :
			base(gameObjectPos, objectName, 1.4) {
		
		this.ammoSize = ammoSize;
		this.cockable = cockable;
		this.magazineFed = magazineFed;

	}

	/**
	 * @return the ammoSize
	 */
	public double getAmmoSize()
	{
		return ammoSize;
	}

	/**
	 * @param ammoSize the ammoSize to set
	 */
	public void setAmmoSize(double ammoSize)
	{
		this.ammoSize = ammoSize;
	}

	/**
	 * @return the magazine
	 */
	public Magazine getMagazine()
	{
		return magazine;
	}

	/**
	 * @param magazine the magazine to set
	 */
	public void setMagazine(Magazine magazine)
	{
		this.magazine = magazine;
		magazine.setInInventory(true);
	}

	/**
	 * @return the loadedProjectile
	 */
	public ProjectileAmmo getLoadedProjectile()
	{
		return loadedProjectile;
	}

	/**
	 * @param loadedProjectile the loadedProjectile to set
	 */
	public void setLoadedProjectile(ProjectileAmmo loadedProjectile)
	{
		this.loadedProjectile = loadedProjectile;
	}

	/**
	 * @return the cockable
	 */
	public bool isCockable()
	{
		return cockable;
	}

	/**
	 * @param cockable the cockable to set
	 */
	public void setCockable(bool cockable)
	{
		this.cockable = cockable;
	}

	/**
	 * @return the magazineFed
	 */
	public bool isMagazineFed()
	{
		return magazineFed;
	}

	/**
	 * @param magazineFed the magazineFed to set
	 */
	public void setMagazineFed(bool magazineFed)
	{
		this.magazineFed = magazineFed;
	}

	/**
	 * @return the boltAction
	 */
	public bool isBoltAction()
	{
		return boltAction;
	}

	/**
	 * @param boltAction the boltAction to set
	 */
	public void setBoltAction(bool boltAction)
	{
		this.boltAction = boltAction;
	}

	/**
	 * @return the meanTimeBetweenFailure
	 */
	public double getMeanTimeBetweenFailure()
	{
		return meanTimeBetweenFailure;
	}

	/**
	 * @param meanTimeBetweenFailure the meanTimeBetweenFailure to set
	 */
	public void setMeanTimeBetweenFailure(double meanTimeBetweenFailure)
	{
		this.meanTimeBetweenFailure = meanTimeBetweenFailure;
	}

	/**
	 * @return the maxFiringRange
	 */
	public double getMaxFiringRange()
	{
		return maxFiringRange;
	}

	/**
	 * @param maxFiringRange the maxFiringRange to set
	 */
	public void setMaxFiringRange(double maxFiringRange)
	{
		this.maxFiringRange = maxFiringRange;
	}

	/**
	 * @return the attachments
	 */
	public GunAttachments[] getAttachments()
	{
		return attachments;
	}

	/**
	 * @param attachments the attachments to set
	 */
	public void setAttachments(GunAttachments[] attachments)
	{
		this.attachments = attachments;
	}

	/**
	 * @return the bulletDispersion
	 */
	public double getBulletDispersion()
	{
		return bulletDispersion;
	}

	/**
	 * @param bulletDispersion the bulletDispersion to set
	 */
	public void setBulletDispersion(double bulletDispersion)
	{
		this.bulletDispersion = bulletDispersion;
	}


	/**
	 * @return the lastDamage
	 */
	public double getLastDamage()
	{
		return lastDamage;
	}

	/**
	 * @param lastDamage the lastDamage to set
	 */
	public void setLastDamage(double lastDamage)
	{
		this.lastDamage = lastDamage;
	}

	// cock gun that have mags
	public bool cockGun()
	{
		// takes 1 sec
		// maybe return a number 0 to x based on what didnt pass in if statements to
		// give more info about gun
		bool cocked = false;

		if (cockable && loadedProjectile == null && magazine != null)
		{
			loadedProjectile = magazine.removeBullet();

			cocked = true;

			if (loadedProjectile != null)
			{
				// loaded = true;
				// cocked = true;
			}
		}

		return cocked;
	}

	public bool rackGun()
	{
		bool racked = false;
		return racked;
	}

	public bool cycleMag()
	{
		bool cycled = false;
		if (magazine != null)
		{

			if (loadedProjectile == null)
			{
				loadedProjectile = magazine.removeBullet();
				if (loadedProjectile != null)
				{
					cycled = true;
				}

			}

		}

		return cycled;
	}

	public bool ejectMag()
	{
		return false;
	}

	public bool reload()
	{
		return false;
	}

	public bool cycleGunAfterFiring()
	{
		bool cycled = false;
		loadedProjectile = null;
		if (magazine != null)
		{

			if (loadedProjectile == null)
			{
				loadedProjectile = magazine.removeBullet();
				if (loadedProjectile != null)
				{
					cycled = true;
				}

			}

		}

		return cycled;
	}

	// fires gun and projectile flies on map, checks for collisions and takes angle
	// into account
	public void fireGunOnMap(Entity shooter, GameObject target)
	{
		// double targetGroupSize = shooter.getTargetGroupSize(target);

	}

	// fires gun and projectile hits targets hitbox
	public bool fireGunAtGameObject(Entity shooter, GameObject target)
	{
		//double 0

		bool targetHit = false;
		double distanceFromTarget = shooter.getDistanceFromObject(target);

		

		if (loadedProjectile != null && target.getGameObjectHitbox() != null)
		{

				//add code to perception check and if failed they dont know what it is
				if (this.getMagazine() != null && this.getMagazine().getBulletsInMag()[0] != null) 
				{
					shooter.addObjectStringEvents("\nShot at " + target + " using " + this.getObjectName() + " with " + this.getMagazine().getBulletsInMag()[0].getObjectName() + "\n");
					target.addObjectStringEvents("\nShot at by " + shooter.getObjectName() + " using " + this.getObjectName() + " with " + this.getMagazine().getBulletsInMag()[0].getObjectName() + "\n");
				}
				else
				{ 	
					shooter.addObjectStringEvents("\nShot at " + target + " using " + this.getObjectName() + "\n");
					target.addObjectStringEvents("\nShot at by " + shooter.getObjectName() + " using " + this.getObjectName() + "\n");
				}
				
				
			RandomNumbers randNum = new RandomNumbers();
			BulletPenetration panCalc = new BulletPenetration(loadedProjectile, distanceFromTarget);


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

			yPosHit = 1180 + side_y;
			xPosHit = target.getGameObjectHitbox().getHitboxCenterX() + base_x;

			panCalc.setFinalV(panCalc.finalVelocity());
			panCalc.setDistance(0);
			double damage = panCalc.currentKeneticEnergy();
			setLastDamage(damage);




			;


			target.getGameObjectHitbox().getHitboxCenterY();



			if (target.getGameObjectHitbox().bodyPartsHitCheck(xPosHit, yPosHit) != null)
			{
				//target is hit

				//target.gameObjectHitbox.projectileImpactHitbox(loadedProjectile, side_y, base_x);

				shooter.addObjectStringEvents(panCalc.penetraitHitBox(target.getGameObjectHitbox(), xPosHit, yPosHit, 0));
				//add damage/wound

			}



			if (!Double.IsNaN(damage))
			{
				target.setIntegraty(target.getIntegraty() - damage);
				targetHit = true;

				// gain accuracy when you hit things successfully, get more for hitting
				// something alive
				if (target is Entity) {
					if (((Entity)target).isAlive())
					{
						shooter.setAccuracy(shooter.getAccuracy() + ((distanceFromTarget + 1) / 100));
					}
					else
					{
						shooter.setAccuracy(shooter.getAccuracy() + ((distanceFromTarget + 1) / 200));
					}

				} else
				{
					shooter.setAccuracy(shooter.getAccuracy() + ((distanceFromTarget + 1) / 200));
				}

				if (target is Entity) {

					((Entity)target).aliveCheck();

				} else
				{
					target.integrityCheck();
				}

			}

			cycleGunAfterFiring();




		}

		return targetHit;
		// double targetGroupSize = shooter.getTargetGroupSize(target);

	}

	// fires gun and projectile hits target not reguarding hitbox
	public bool fireGunAtGameObjectNoHitbox(Entity shooter, GameObject target)
	{
		bool targetHit = false;
		double distanceFromTarget = shooter.getDistanceFromObject(target);

		if (loadedProjectile != null)
		{

			double targetGroupSize = shooter.getTargetGroupSize(target);

			RandomNumbers randNum = new RandomNumbers();

			BulletPenetration panCalc = new BulletPenetration(loadedProjectile, distanceFromTarget);

			// change to target dimensions later
			int shoulderWidth = 400;
			int height = 1753;

			// rng to see projectile hits target based on width and height of a person, need
			// to add a tester for rng to get % of success
			if (randNum.rollRandDouble(shoulderWidth, 0) >= targetGroupSize
					&& randNum.rollRandDouble(height, 0) >= targetGroupSize)
			{

				panCalc.finalPenValue();

				double damage = panCalc.currentKeneticEnergy() / 10;
				setLastDamage(damage);



				if (!Double.IsNaN(damage))
				{
					target.setIntegraty(target.getIntegraty() - damage);
					targetHit = true;

					// gain accuracy when you hit things successfully, get more for hitting
					// something alive
					if (target is Entity) {
						if (((Entity)target).isAlive())
						{
							shooter.setAccuracy(shooter.getAccuracy() + ((distanceFromTarget + 1) / 100));
						}
						else
						{
							shooter.setAccuracy(shooter.getAccuracy() + ((distanceFromTarget + 1) / 200));
						}

					} else
					{
						shooter.setAccuracy(shooter.getAccuracy() + ((distanceFromTarget + 1) / 200));
					}

					if (target is Entity) {

						((Entity)target).aliveCheck();

					} else
					{
						target.integrityCheck();
					}

				}

				cycleGunAfterFiring();

			}

		}

		return targetHit;

	}

	//	public double getKE_Damage(Double distance) {
	//		this.getLoadedProjectile().get
	//		
	//		
	//		return 0.0;
	//	}

	public static void main(String[] args)
	{
		// test shooting at targets here
		Map map = new Map(12);
		map.makeGameMap1();
		GameObjectPos objPos = new GameObjectPos(null, 0, 0, 0, 0);
		GameObjectPos objPos2 = new GameObjectPos(null, 0, 0, 400, 0);

		Entity shooter = new Entity("Shooter", true, 100, 1.5, 20, objPos);
		Entity target = new Entity("Target", true, 100, 1.5, 20, objPos2);

		Magazine _9mm_mag = new Magazine(objPos, "9mm mag", .95, 6, 9);

		for (int i = 0; i < 8; i++)
		{
			ProjectileAmmo bullet = new ProjectileAmmo(objPos, "9mm Federal FMJ:" + i, 0.00804, 9, 350);
			ProjectileAmmo bullet2_withL = new ProjectileAmmo(objPos, "9mm Federal FMJ:" + i, 0.00804, 9, 14.335, 350);


			//ProjectileAmmo bullet = new ProjectileAmmo(objPos, "9mm Federal FMJ:" + i, 0.00804, 9, 350);
			_9mm_mag.addBullet(bullet);
		}

		Gun gun = new Gun(objPos2, "9mm pistol", 9, true, true);
		gun.setMagazine(_9mm_mag);

		Console.WriteLine(gun.getMagazine().getAmmountOfBulletsInMag());
		Console.WriteLine(gun.getMagazine().bulletsInMagToString());
		Console.WriteLine(gun.cockGun());

		Console.WriteLine("Loaded ammo: " + gun.getLoadedProjectile().getObjectName());
		Console.WriteLine(gun.getMagazine().getAmmountOfBulletsInMag());
		Console.WriteLine(gun.getMagazine().bulletsInMagToString());

		int timesShot = 6;
		for (int i = 0; i < timesShot; i++)
		{
			if (i == 4)
			{
				int debug = 0;
			}

			Console.WriteLine("\n" + gun.getMagazine().getAmmountOfBulletsInMag() + ": "
					+ gun.getLoadedProjectile().getObjectName());
			Console.WriteLine("Target Hit: " + gun.fireGunAtGameObjectNoHitbox(shooter, target));
			Console.WriteLine("Target integraty: " + target.getIntegraty());
			Console.WriteLine("Target alive: " + target.isAlive());
			Console.WriteLine("Shooter accuracy: " + shooter.getAccuracy());
			Console.WriteLine("Shooter target group size: " + shooter.getTargetGroupSize(target));

		}

	}

}
//9mm fmj = 14.335mm long
//ProjectileAmmo bullet = new ProjectileAmmo(objPos, "9mm Federal FMJ:" + i, 0.00804, 9, 14.335, 350);

}
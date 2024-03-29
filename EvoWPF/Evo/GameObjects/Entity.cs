﻿using Evo.GameObjects.HitBoxes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Evo.Calculator.Destinations;

//later: add entity levels wich affect how skilled they are ex: high lvl might have high accuracy
namespace Evo
{
    [System.Serializable]
	public class Entity : GameObject {
	// types: humaniod, vehicle,

	/**
	 * 
	 */
	//private static final long serialVersionUID = 1L;

	// energy, health, stealth
	public bool isThePlayer = false;

	public bool alive = true;
	public double energy = 100;
	public double movementSpeed = 1;// meters per second
	public double accuracy = 50;

	// add evasion: affects dodging of things like punches, bites, ect
	public double evasion = 40;

	public double strength = 20; // out of 100

	public double viewDistance = 40;

	// might delete later
	public String entityName = "unnamed entity";
	
	private double millilitersOfBlood = 5700; // die at >50%, pass out at 40% and possible organ failure, stats affected at 20% loss
	//millileters

	public double attackRange = 1.5;
	public bool inCombat = false;
	public bool inCover = false;
	
	
	public double medicalKnowlege;

	// carrie over seconds
	public double secondsLeft = 0;

		// change to be based off of mass and volume

		//private BaseItem[] inventory;
		private ObservableCollection<BaseItem> inventory = new ObservableCollection<BaseItem>();

		//private BaseItem[] inventory = new BaseItem[99];

		// maybe make an array for duel wielding
		public BaseItem entityWeapon;
	
	public BodyPart[] bodyParts;
	//public statusEffects;

	private double TIME_MOVE_TAKES = 2.5;// change to where its based on speed

	private BaseItem[] itemsInSight;

		private Path path;


		//private bool wounded;





		public Entity(String objectName, bool alive, double energy, double movementSpeed, double accuracy,
		GameObjectPos gameObjectPos) : base(gameObjectPos, objectName)
		{
			this.alive = alive;
			this.energy = energy;
			this.accuracy = accuracy;
			this.gameObjectPos = gameObjectPos;
			this.movementSpeed = movementSpeed;
			Path path = new Path(false);
			this.SetPath(path);
		}

		public bool getIsThePlayer() {
		return this.isThePlayer;
	}

	public void setIsThePlayer(bool isThePlayer) {
		this.isThePlayer = isThePlayer;
	}


	public bool isAlive() {
		return alive;
	}

	public void setAlive(bool alive) {
		this.alive = alive;
	}

	public double getEnergy() {
		return energy;
	}

	public void setEnergy(double energy) {
		this.energy = energy;
	}

	public double getAccuracy() {
		return accuracy;
	}

	public void setAccuracy(double accuracy) {
		this.accuracy = accuracy;
	}



	/**
	 * @return the viewDistance
	 */
	public double getViewDistance() {
		return viewDistance;
	}

	/**
	 * @param viewDistance the viewDistance to set
	 */
	public void setViewDistance(double viewDistance) {
		this.viewDistance = viewDistance;
	}

	/**
	 * @return the movementSpeed
	 */
	public double getMovementSpeed() {
		return movementSpeed;
	}

	/**
	 * @param movementSpeed the movementSpeed to set
	 */
	public void setMovementSpeed(double movementSpeed) {
		this.movementSpeed = movementSpeed;
	}

	/**
	 * @return the evasion
	 */
	public double getEvasion() {
		return evasion;
	}

	/**
	 * @param evasion the evasion to set
	 */
	public void setEvasion(double evasion) {
		this.evasion = evasion;
	}

	/**
	 * @return the strength
	 */
	public double getStrength() {
		return strength;
	}

	/**
	 * @param strength the strength to set
	 */
	public void setStrength(double strength) {
		this.strength = strength;
	}

	/**
	 * @return the entityName
	 */
	public String getEntityName() {
		return entityName;
	}

	/**
	 * @param entityName the entityName to set
	 */
	public void setEntityName(String entityName) {
		this.entityName = entityName;
	}

	/**
	 * @return the attackRange
	 */
	public double getAttackRange() {
		return attackRange;
	}

	/**
	 * @param attackRange the attackRange to set
	 */
	public void setAttackRange(double attackRange) {
		this.attackRange = attackRange;
	}

	/**
	 * @return the inCombat
	 */
	public bool isInCombat() {
		return inCombat;
	}

	/**
	 * @param inCombat the inCombat to set
	 */
	public void setInCombat(bool inCombat) {
		this.inCombat = inCombat;
	}

	/**
	 * @return the entityWeapon
	 */
	public BaseItem getEntityWeapon() {
		return entityWeapon;
	}

	/**
	 * @param entityWeapon the entityWeapon to set
	 */
	public void setEntityWeapon(BaseItem entityWeapon) {
		this.entityWeapon = entityWeapon;
	}

	/**
	 * @return the inCover
	 */
	public bool isInCover() {
		return inCover;
	}

	/**
	 * @param inCover the inCover to set
	 */
	public void setInCover(bool inCover) {
		this.inCover = inCover;
	}

	/**
	 * @return the secondsLeft
	 */
	public double getSecondsLeft() {
		return secondsLeft;
	}

	/**
	 * @param secondsLeft the secondsLeft to set
	 */
	public void setSecondsLeft(double secondsLeft) {
		this.secondsLeft = secondsLeft;
	}

	/**
	 * @return the inventory
	 */
	public ObservableCollection<BaseItem> getInventory() {
		return inventory;
	}

	/**
	 * @param inventory the inventory to set
	 */
	public void setInventory(ObservableCollection<BaseItem> inventory) {
		this.inventory = inventory;
	}



		public double GetSecondsLeft()
		{
			return secondsLeft;
		}

		/**
		 * @param secondsLeft the secondsLeft to set
		 */
		public void SetSecondsLeft(double secondsLeft)
		{
			this.secondsLeft = secondsLeft;
		}

		public void AddSecondsLeft(double secondsLeft)
		{

			this.secondsLeft += secondsLeft;
		}
		public double GetMillilitersOfBlood()
		{
			return this.millilitersOfBlood;
		}

		public void SetMillilitersOfBlood(double millilitersOfBlood)
		{

			this.millilitersOfBlood = millilitersOfBlood;
		}

		public void AddMillilitersOfBlood(double millilitersOfBlood)
		{

			this.millilitersOfBlood += millilitersOfBlood;
			
		}

		public Path GetPath() 
		{
			return this.path;
		}
		public void SetPath(Path path) 
		{
			this.path = path;
		}



		/**
		 * @param sorts inventory
		 */
		/*
		public void sortInventory() {
			for (int i = 0; i < getInventory().GetLength(0); i++) {




				if (getInventory()[i] != null && i > 0) {

					for (int k = 0; k < getInventory().GetLength(0); k++) {	
						if (getInventory()[k] == null && k > 0 && k < i) {
							getInventory()[k] = getInventory()[i];
							getInventory()[i] = null;
							break;
						}
					}

				}



			}

		}
		*/


		public bool DeathCheck() 
		{
			if (!this.isAlive()) 
			{
				return true;
			}
			double minBloodInBody = 2850;
			if (this.getGameObjectHitbox().VitalOrganDamaged())
			{
				
				this.addObjectStringEvents("Died from vital organ damage to thier " + this.getGameObjectHitbox().GetDamagedVitalOrgan().getName());
				this.setAlive(false);
				return true;
			}
			else if (this.GetMillilitersOfBlood() < minBloodInBody) 
			{
				this.addObjectStringEvents("Died from blood loss");
				this.setAlive(false);
				return true;
			}

			return false;
		}


		public bool DeathCheckCloseToPlayer(Entity player)
		{
			if (!this.isAlive())
			{
				return true;
			}
			double infoRange = 1000;
			double minBloodInBody = 2850;
			if (this.getGameObjectHitbox().VitalOrganDamaged())
			{

				this.addObjectStringEvents("Died from vital organ damage to thier " + this.getGameObjectHitbox().GetDamagedVitalOrgan().getName());
				if (player.getDistanceFromObject(this) < infoRange) 
				{
					player.addObjectStringEvents(this.getObjectName() + " died from " + this.getGameObjectHitbox().GetDamagedVitalOrgan().getName() + " damage");
				}
				this.setAlive(false);
				return true;
			}
			else if (this.GetMillilitersOfBlood() < minBloodInBody)
			{
				this.addObjectStringEvents("Died from blood loss");
				if (player.getDistanceFromObject(this) < infoRange)
				{
					player.addObjectStringEvents(this.getObjectName() + " died from blood loss");
				}
				this.setAlive(false);
				return true;
			}

			return false;
		}

		public bool aliveCheck() {

		if (integrityCheck() == true && alive == true) {

			return true;
		} else {
			alive = false;
			return false;
		}

	}

		/*
		public bool GetWounded()
		{
			return this.wounded;
		}

		public void SetWounded(bool wounded)
		{
			this.wounded = wounded;
		}
		*/

		/**
		 * 
		 * @param targetGameObject
		 * @return targetGrouping size in mm
		 */
		public double getTargetGroupSize(GameObject targetGameObject) {
		getAccuracy();
		double groupingFalloff = 10 + (getAccuracy() / 10);

		double targetGrouping = getDistanceFromObject(targetGameObject) / groupingFalloff;

		//targetGrouping += 500; //temporary for testing
		return targetGrouping;
	}



	public String entitiesInSightListToString(Map worldMap) {
		String stringOutput = "";
		// bool done = false;
		Entity[] entityList;
		entityList = entitiesInSightList(worldMap);

		for (int i = 0; i < 999000; i++) {

			if (entityList[i] != null) {
				stringOutput += "\n" + i + ": " + entityList[i].getObjectName() + ", "
						+ getDistanceFromObject(entityList[i]) + " meters away. \n";
			}

		}

		if (entityList[0] != null) {
			return stringOutput;
		} else {
			return "No entities in sight.\n";
		}

	}

	/**
	 * Gets a list of entities in sight within a certain radius
	 * 
	 * @param worldMap
	 * @param radius
	 * @param xPos
	 * @param yPos
	 * @return
	 */
	public Entity[] entitiesInSightList(Map worldMap) {
		GameObject[] worldGameObjectList = gameObjectInSightList(worldMap);

		Entity[] entitiesInSightList = new Entity[999000];

		int iterations = 0;

		for (int i = 0; i < worldGameObjectList.GetLength(0); i++) {
			if (worldGameObjectList[i] is Entity) {
				entitiesInSightList[iterations] = (Entity) worldGameObjectList[i];
				iterations++;
			}

		}

		return entitiesInSightList;

//		Entity[] worldEntityList = new Entity[999000];
//		worldEntityList = worldMap.entitiesOnMap;
//
//		Entity[] entitiesInSight = new Entity[999000];
//
//		int entityListCount = 0;
//		int iterations = 0;
//		bool done = false;
//
//		while (!done) {
//			if (worldEntityList[iterations] != null) {
//
//				if (entityInSight(worldEntityList[iterations])) {
//					entitiesInSight[entityListCount] = worldEntityList[iterations];
//					entityListCount++;
//				}
//
//			} else {
//				done = true;
//			}
//			iterations++;
//		}
//
//		return entitiesInSight;

	}

	public bool entityInSight(Entity targetEntity) {
		// double viewDistance = 20; // in meters

		if (getDistanceFromObject(targetEntity) <= this.viewDistance) {
			if (targetEntity.isThePlayer) {
				// Console.WriteLine("You have been spotted by a " + entityName);
				// gameObjectPos.printToString();
			}

			return true;
		} else {
			return false;
		}

	}

	public String gameObjectInSightListToString(Map worldMap) {
		String stringOutput = "";
		// bool done = false;
		GameObject[] gameObjectList;
		gameObjectList = gameObjectInSightList(worldMap);

		for (int i = 0; i < 999000; i++) {

			if (gameObjectList[i] != null) {
				stringOutput += "\n" + i + ": " + gameObjectList[i].getObjectName() + ", "
						+ getDistanceFromObject(gameObjectList[i]) + " meters away. \n";
			}

		}

		if (gameObjectList[0] != null) {
			return stringOutput;
		} else {
			return "No GameObjects in sight.\n";
		}

	}

	public GameObject[] gameObjectInSightList(Map worldMap) {
		GameObject[] worldGameObjectList = new GameObject[999000];
		worldGameObjectList = worldMap.gameObjectsOnMapList;

		GameObject[] gameObjectsInSight = new GameObject[999000];

		int gameObjectListCount = 0;
		int iterations = 0;
		bool done = false;

		while (!done) {
			if (worldGameObjectList[iterations] != null) {

				if (gameObjectInSight(worldGameObjectList[iterations])) {
					gameObjectsInSight[gameObjectListCount] = worldGameObjectList[iterations];
					gameObjectListCount++;
				}

			} else {
				done = true;
			}
			iterations++;
		}

		return gameObjectsInSight;

	}

	public bool gameObjectInSight(GameObject gameObject) {
		// double viewDistance = 20; // in meters

		if (gameObject.getGameObjectPos() != null && getDistanceFromObject(gameObject) <= this.viewDistance) {
			if (gameObject is Entity && (((Entity) gameObject).isThePlayer)) {
				// Console.WriteLine("You have been spotted by a " + entityName);
				// gameObjectPos.printToString();
			}

			return true;
		} else {
			return false;
		}

	}

//fix for items
//	public Entity[] itemsInSightList(Map worldMap) {
//			Entity[] worldItemList = new Entity[999000];
//			worldItemList = worldMap.entitiesOnMap;
//
//			BaseItem[] itemsInSight = new BaseItem[999000];
//
//			int itemListCount = 0;
//			int iterations = 0;
//			bool done = false;
//
//			while (!done) {
//				if (worldItemList[iterations] != null) {
//
//					if (itemInSight(worldItemList[iterations])) {
//						itemsInSight[itemListCount] = worldItemList[iterations];
//						itemListCount++;
//					}
//
//				} else {
//					done = true;
//				}
//				iterations++;
//			}
//
//			return entitiesInSight;
//
//		}

	public String itemsInSightListToString(Map worldMap) {
		String stringOutput = "";
		// bool done = false;
		BaseItem[] itemList;
		itemList = itemsInSightList(worldMap);

		for (int i = 0; i < 999000; i++) {

			if (itemList[i] != null && !itemList[i].isInInventory()) {

				stringOutput += "\n" + i + ": " + itemList[i].getObjectName() + ", "
						+ getDistanceFromObject(itemList[i]) + " meters away. \n";
			}

		}

		if (itemList[0] != null) {
			return stringOutput;
		} else {
			return "No items in sight.\n";
		}

	}

	public BaseItem[] itemsInSightList(Map worldMap) {
		GameObject[] worldGameObjectList = gameObjectInSightList(worldMap);

		BaseItem[] itemsInSightList = new BaseItem[999000];

		int iterations = 0;

		for (int i = 0; i < worldGameObjectList.GetLength(0); i++) {
			if (worldGameObjectList[i] is BaseItem && !((BaseItem) worldGameObjectList[i]).isInInventory()) {
				itemsInSightList[iterations] = (BaseItem) worldGameObjectList[i];
				iterations++;
			}

		}
		this.itemsInSight = itemsInSightList;
		return itemsInSightList;
	}

	public bool itemInSight(BaseItem targetItem) {

		// half the view distance to see objects (gonna change to be based off of the
		// objects size)
		if (getDistanceFromObject(targetItem) <= this.viewDistance * .5) {

			return true;
		} else {
			return false;
		}

	}

	/**
	 * Tells player they have been spotted
	 * 
	 * @param targetEntity
	 * @return
	 */
	public String playerSpottedMessage(Entity targetEntity) {

		return "\nSpotted by " + entityName + ".\n";
	}

	/**
	 * Mainly for zombies chasing player on map
	 * 
	 * @param worldMap
	 * @param targetEntity
	 * @param ticksPassed
	 */
	public double chaseEntityInMapArea(Map worldMap, Entity targetEntity, double secondsPassed) {
		secondsLeft += secondsPassed;
		bool objectCaught = false;

//		Random random = new Random();
//		int min = 0;
//		int max = 1;
//		
//		int randNum = (int) (Math.random() * (max - min + 1) + min);
//		
//		
//		if (randNum == 0) {
//		}
//		

		// make it rand between walking on x or y axis or travel on the longest axis
		// they are from the enemy

		while (!objectCaught && secondsLeft > 0) {

			if ((int) getGameObjectPos().getMapAreaXPos() < (int) targetEntity.getGameObjectPos().getMapAreaXPos()) {
				getGameObjectPos().moveMapAreaXPos(movementSpeed * worldMap.getWorldTickspeed());
			} else if ((int) getGameObjectPos().getMapAreaXPos() > (int) targetEntity.getGameObjectPos()
					.getMapAreaXPos()) {
				getGameObjectPos().moveMapAreaXPos(-(movementSpeed * worldMap.getWorldTickspeed()));
			} else if ((int) getGameObjectPos().getMapAreaYPos() < (int) targetEntity.getGameObjectPos()
					.getMapAreaYPos()) {
				getGameObjectPos().moveMapAreaYPos(movementSpeed * worldMap.getWorldTickspeed());
			} else if ((int) getGameObjectPos().getMapAreaYPos() > (int) targetEntity.getGameObjectPos()
					.getMapAreaYPos()) {
				getGameObjectPos().moveMapAreaYPos(-(movementSpeed * worldMap.getWorldTickspeed()));
			}

			secondsLeft -= .5;

			if ((int) getGameObjectPos().getMapAreaXPos() == (int) targetEntity.getGameObjectPos().getMapAreaXPos()
					&& (int) getGameObjectPos().getMapAreaYPos() == (int) targetEntity.getGameObjectPos()
							.getMapAreaYPos()) {
				objectCaught = true;

				if (targetEntity.isThePlayer) {

					Console.WriteLine("A " + entityName + " is right beside you.");
				}
				// Console.WriteLine("Caught!");
			}
			if (secondsLeft <= 0) {
				// Console.WriteLine("\nRan out of seconds!\n");
			}

		}

		// Console.WriteLine("\nSeconds left: " + getTicksLeft() + "\n");
		// Console.WriteLine();

		// Console.WriteLine(gameObjectPos.getMapAreaYPos() + "\n");

		return secondsLeft;
	}

//	/**
//	 * Note: out dated method
//	 * 
//	 * @param worldMap
//	 * @param targetEntity
//	 * @param ticksPassed
//	 * @return
//	 */
//	public bool inMeleRange(Map worldMap, Entity targetEntity, double ticksPassed) {
//		if (targetEntity.getGameObjectPos().getCurrentArea() == getGameObjectPos().getCurrentArea()
//				&& (int) getGameObjectPos().getMapAreaXPos() == (int) targetEntity.getGameObjectPos().getMapAreaXPos()
//				&& (int) getGameObjectPos().getMapAreaYPos() == (int) targetEntity.getGameObjectPos()
//						.getMapAreaYPos()) {
//			return true;
//			// attackEntityMele(worldMap, targetEntity, ticksPassed);
//		}
//
//		return false;
//	}

	public bool inAttackRange(GameObject target) {

		if (getDistanceFromObject(target) <= attackRange
				|| (entityWeapon != null && getDistanceFromObject(target) <= entityWeapon.getAttackRange())) {
			return true;

		} else {
			return false;
		}

	}

	public double getMeleDamage() {
		return this.strength / 5;
	}

//	/**
//	 * 
//	 * 
//	 * @param worldMap
//	 * @param targetEntity
//	 * @param ticksPassed  Ticks entity is allowed to use for action
//	 * @return
//	 */
//	public double attackEntityMele(Map worldMap, Entity targetEntity, double ticksPassed) {
//		RandomNumbers rand = new RandomNumbers();
//		setTicksLeft(ticksPassed);
//
//		if (entityInSight(targetEntity)) {
//
//			if (!inMeleRange(worldMap, targetEntity, ticksPassed)) {
//
//				if (isThePlayer) {
//
//					Console.WriteLine("Target is too far for mele.");
//					return ticksPassed;
//				}
//				chaseEntityInMapArea(worldMap, targetEntity, ticksPassed);
//
//			} else if (movementSpeed * getTicksLeft() > TIME_MOVE_TAKES) {
//
//				// add evasion calculation later
//				if (getAccuracy() > rand.rollRandNum(50, 0)) {// add constants
//
//					targetEntity.integraty -= getMeleDamage();
//				}
//				Console.WriteLine("Target hit for " + getMeleDamage());
//
//			}
//
//		} else {
//			if (isThePlayer) {
//
//				Console.WriteLine("\nTarget out of sight.\n");
//			}
//
//		}
//
//		return getTicksLeft();
//	}

	/**
	 * TODO: get rid of secondsPassed and make the move take time
	 * 
	 * @param worldMap
	 * @param targetEntity
	 * @param ticksPassed
	 * @param intialMove   Dictates to use or produce ticks passed.
	 * @return
	 */
	public double attackEntity(Map worldMap, Entity targetEntity, double secondsPassed, bool intialMove) {
		RandomNumbers rand = new RandomNumbers();

		if (intialMove) {
			secondsPassed = 0;
		}
		if (this.alive) {
			// for entity

			secondsLeft += secondsPassed;

			if (entityInSight(targetEntity)) {

				if (!inAttackRange(targetEntity)) {

					if (isThePlayer) {
						
						this.addObjectStringEvents("\nTarget is out of range.\n");
						Console.WriteLine("Target is out of range.");
						return secondsPassed;
					} else {
						chaseEntityInMapArea(worldMap, targetEntity, secondsPassed);
					}

				}

				if (movementSpeed * secondsLeft > TIME_MOVE_TAKES || intialMove) {

					if (entityWeapon != null && entityWeapon is Gun) {
						((Gun) entityWeapon).fireGunAtGameObjectNoHitbox(this, targetEntity);

					} else if (getAccuracy() > rand.rollRandInt(50, 0)) {// add constants
						// add evasion calculation later
						// getTargetGroupSize(targetEntity);
						if (entityWeapon != null) {

							targetEntity.integraty -= entityWeapon.getHighestDamageType();

							secondsLeft -= TIME_MOVE_TAKES;

						} else {
							targetEntity.integraty -= getMeleDamage();
							secondsLeft -= TIME_MOVE_TAKES;
						}

					}

					// add something to indicate where hit and with what weapon after hit boxes and
					// weapons are added
					addObjectStringEvents("\n" + entityName + " attacked " + targetEntity.getObjectName() + " for "
							+ getMeleDamage() + " damage.");
					Console.WriteLine(entityName + " attacked " + targetEntity.getObjectName() + " for "
							+ getMeleDamage() + " damage.");

					if (targetEntity.integraty <= 0) {
						targetEntity.setAlive(false);
						this.addObjectStringEvents("\n" + targetEntity.getObjectName() + " died.\n");
						Console.WriteLine(targetEntity.getObjectName() + " died.");
					}

				}
				addObjectStringEvents(getObjectStringEvents() + "\n" + targetEntity.getObjectName() + " has " + targetEntity.getIntegraty() + "integraty");
				Console.WriteLine(targetEntity.getObjectName() + " has " + targetEntity.getIntegraty() + "integraty");
			}

		}
		return secondsLeft;

	}
	
	
	public bool shootEntity(Entity targetEntity, bool intialMove) {
		// change later
		double distanceFromTarget = this.getDistanceFromObject(targetEntity);
		double secondsPassed = 5 / targetEntity.getMovementSpeed();
		double damageToTarget = 0;

		RandomNumbers rand = new RandomNumbers();

		if (intialMove) {
			secondsPassed = 0;
		}
		if (this.alive) {
			// for entity

			secondsLeft += secondsPassed;

			if (entityInSight(targetEntity)) {

				if (!inAttackRange(targetEntity)) {

					if (isThePlayer) {
						
						this.addObjectStringEvents("\nTarget is out of range.\n");
						Console.WriteLine("Target is out of range.");
						return false;
					} else {
						chaseEntityInMapArea(this.getGameObjectPos().getCurrentMap(), targetEntity, secondsPassed);
					}

				}

				if (movementSpeed * secondsLeft > TIME_MOVE_TAKES || intialMove) {

					if (entityWeapon != null && entityWeapon is Gun &&  ((Gun) entityWeapon).getLoadedProjectile() != null) {
						
						((Gun) entityWeapon).fireGunAtGameObjectNoHitbox(this, targetEntity);
						
						//damageToTarget = ((Gun) this.getEntityWeapon()).getLoadedProjectile().getDamamage(distanceFromTarget);
						
						
						addObjectStringEvents("\n" + entityName + " attacked " + targetEntity.getObjectName() + " for "
								+ ((Gun) entityWeapon).getLastDamage() + " damage.");
						
						
						
						
						Console.WriteLine(entityName + " attacked " + targetEntity.getObjectName() + " for "
								+ ((Gun) entityWeapon).getLastDamage() + " damage.");
					} else {
						
						addObjectStringEvents("Gun not equipped or no projectile loaded.\n");
						
					}

					// add something to indicate where hit and with what weapon after hit boxes and
					// weapons are added


					if (targetEntity.integraty <= 0) {
						targetEntity.setAlive(false);
						this.addObjectStringEvents("\n" + targetEntity.getObjectName() + " died.\n");
						Console.WriteLine(targetEntity.getObjectName() + " died.");
					}

				}
				addObjectStringEvents(getObjectStringEvents() + "\n" + targetEntity.getObjectName() + " has " + targetEntity.getIntegraty() + "integraty");
				Console.WriteLine(targetEntity.getObjectName() + " has " + targetEntity.getIntegraty() + "integraty");
			}

		}
		
		
		return false;
	}

	public bool equipItemAsWeapon(BaseItem item) {

		setEntityWeapon(item);
		this.addObjectStringEvents("\nEquiped " + item.getObjectName() + " as a weapon\n");

			return false;
	}

	/**
	 * Directly adds a BaseItem to entity inventory
	 * @param item
	 * @return true if added
	 */
	public bool addItemToInventory(BaseItem item) {


			inventory.Add(item);
			item.setGameObjectPos(null);
		
		// Console.WriteLine("Could not add item to inventory.");
		
		return true;

	}

	public bool removeItemFromInventory(BaseItem item) {

		for (int i = 0; i < inventory.Count; i++) {
			if (inventory[i] == item) {
				inventory[i] = null;
				
				return true;
			}
		}
		
		return false;
	}

	public bool itemInInventory(BaseItem item) {

		for (int i = 0; i < inventory.Count; i++) {
			if (inventory[i] == item) {
				return true;
			}
		}

		return false;
	}

	public String showInventory() {
		String inventoryString = "\n";
		int objInInv = 0;

		for (int i = 0; i < inventory.Count; i++) {
			if (inventory[i] != null) {

				inventoryString += i + ": " + inventory[i].objectName + "\n";
				objInInv++;
			}

		}

		if (objInInv == 0) {
			inventoryString += "Inventory empty.\n";
		}

		return inventoryString;

	}

	public bool equipInvintoryItemAsWeapon(int index) {

		if (index < inventory.Count && inventory[index] != entityWeapon) {
			setEntityWeapon(inventory[index]);
				//removeItemFromInventory(entityWeapon);
				this.addObjectStringEvents("Equiped " + inventory[index].getObjectName() + " as a weapon");
			return true;
		}

		return false;

	}

	public bool unEquipInvintoryItemAsWeapon() {
		//addItemToInventory(getEntityWeapon());
		setEntityWeapon(null);

		return true;

	}
	
	private void createNewInventory() {
		this.inventory = new ObservableCollection<BaseItem>();
	}
	
	private void increaseInventoryLength() {
			ObservableCollection<BaseItem> newInventory = new ObservableCollection<BaseItem>();
		
		for (int i = 0; i < this.inventory.Count; i++) {
			newInventory[i] = inventory[i];
			
		}
		inventory = newInventory;
		return;
	}


	private bool inPickupDistcance(BaseItem item) {
		if (item.getDistanceFromObject(this) < 2) {
			return true;

		} else {

			return false;
		}

	}

	private bool pickUpItem(BaseItem item) {
		bool itemAdded = false;
		
		if (this.inventory == null) {
			createNewInventory();
		}
		

		if (inPickupDistcance(item)) {
			itemAdded = addItemToInventory(item);

			// method that removes objets off of map
		}
		item.setInInventory(itemAdded);
		addObjectStringEvents("\nPicked up "+ item.getObjectName() + "\n");

		return itemAdded;
	}

	public bool pickUpItemFromInventory(Entity entity, BaseItem item) {
		bool itemAdded = false;
			ObservableCollection<BaseItem> baseItem = entity.getInventory();

		for (int i = 0; i < baseItem.Count; i++) {
			if (baseItem[i] == item) {
				entity.getInventory()[i] = null;
				itemAdded = pickUpItem(item);
			}

		}

		return itemAdded;

	}

	public bool pickUpItemOffOfGround(BaseItem item) {
		if (item != null && !item.isInInventory()) {
			return pickUpItem(item);

		} else {
			return false;
		}

	}

	public bool dropItem(BaseItem item) {

		if (itemInInventory(item)) {

			if (getEntityWeapon() == item) {
				setEntityWeapon(null);

			}

			inventory.Remove(item);
			item.setGameObjectPos(getGameObjectPos());
			item.setInInventory(false);
			addObjectStringEvents("\nDropped " + item.getObjectName());
			return true;

		} else {
			return false;
		}
	}
	
	
	public bool cockGun() {
		
		
		if (entityWeapon != null && entityWeapon is Gun) {
			((Gun) entityWeapon).cockGun(this);
			this.addObjectStringEvents("\nCocked " + entityWeapon.getObjectName() + "\n");
			return true;
		} else {
			return false;
		}
		
		
		
	}

	public String toString() {
		String output = "";

		return output;
	}

	/**
	 * Player waits for x minutes
	 * 
	 * @param worldMap
	 * @param minuets
	 */
	public void playerWait(Map worldMap, Entity player, double minutes) {

		worldMap.runThroughEntityActions(worldMap, player, minutes * 60);
		addObjectStringEvents("\nWaited for " + minutes + " minutes.\n");
	}

	// this entities actions are run through every game loop
	public void entityActions() {

	}

	public static void main(String[] args) {
		Map tstMap = new Map(25);
		GameObjectPos entPos = new GameObjectPos(tstMap, 0, 0, 0, 0);
		GameObjectPos entPos2 = new GameObjectPos(tstMap, 0, 0, 0, 0);
		GameObjectPos entPos3 = new GameObjectPos(tstMap, 15, 15, 0, 0);
		GameObjectPos entPos4 = new GameObjectPos(tstMap, 0, 0, 0, 0);

		Entity player = new Entity("Player", true, 100, 1.5, 100, entPos);

		Entity zombie = new Entity("Zombie 1", true, 100, 1.5, 100, entPos2);

		Entity zombie2 = new Entity("Zombie 2", true, 100, 1.5, 100, entPos3);

		tstMap.addGameObjectToMapList(player);
		player.setIsThePlayer(true);
		player.setInCombat(true);
		player.setSpotted(true);
		tstMap.addGameObjectToMapList(zombie);
//		tstMap.addEntityToMap(zombie2);

		entPos.setMapAreaXPos(100);
		entPos.setMapAreaYPos(100);

		entPos2.setMapAreaXPos(90);
		entPos2.setMapAreaYPos(90);

//		entPos3.setMapAreaXPos(15 * 200);
//		entPos3.setMapAreaYPos(15 * 200);

		Console.WriteLine("Distance from each other: " + player.getDistanceFromObject(zombie));
//		Console.WriteLine("Distance from each other: " + player.getDistanceFromObject(zombie2));

		// double ticksPassed = 4000;

		// Console.WriteLine(entPos2.toString());
		// zombie.chaseEntityInMapArea(tstMap, player, ticksPassed);
		// zombie.attackEntityMele(tstMap, player, ticksPassed);
		// Console.WriteLine(entPos2.toString());

//		Console.WriteLine(tstMap.entitiesOnMapToString());
		Magazine _9mm_mag = new Magazine(entPos4, "9mm mag", .95, 6, 9);

		Console.WriteLine(player.entitiesInSightListToString(tstMap));
		Console.WriteLine(zombie.entitiesInSightListToString(tstMap));

		Console.WriteLine("Picked up: " + player.pickUpItem(_9mm_mag));
		Console.WriteLine(player.showInventory());

		Console.WriteLine("Dropped: " + player.dropItem(_9mm_mag)); 
		Console.WriteLine(player.showInventory());

		Console.WriteLine(player.isInCombat());
		Console.WriteLine(player.isSpotted());
		zombie.setAlive(false);
		tstMap.runThroughEntityActions(tstMap, player, 0);
		Console.WriteLine(player.isInCombat());
		Console.WriteLine(player.isSpotted());

	}

}
}
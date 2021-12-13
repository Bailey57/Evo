using System;


//later: add entity levels wich affect how skilled they are ex: high lvl might have high accuracy
namespace Wasteland_game {
public class Animal : Entity {
	// types: humaniod, vehicle,

	/**
	 * 
	 */
	//private static final long serialVersionUID = 1L;

	// energy, health, stealth
	private bool isThePlayer = false;



	// add evasion: affects dodging of things like punches, bites, ect
	public double evasion = 40;

	public double strength = 20; // out of 100

	public double viewDistance = 40;


	//4500 to 5700 ml of blood in a human
	public double blood_ml = 5700; // die at >50%, pass out at 40% and possible organ failure, stats affected at 20% loss
	

	public double attackRange = 1.5;
	public bool inCombat = false;
	public bool inCover = false;

	// carrie over seconds
	public double secondsLeft = 0;

	// change to be based off of mass and volume
	public BaseItem[] inventory = new BaseItem[99];

	// maybe make an array for duel wielding
	public BaseItem entityWeapon;
	


	public bool concious = false;





	/**
	 * 
	 */
	public bool isThePlayerBool() {
		return this.isThePlayer;
	}

	/**
	 * @param isThePlayer the isThePlayer to set
	 */
	public void setThePlayer(bool isThePlayer) {
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

	public GameObjectPos getGameObjectPos() {
		return gameObjectPos;
	}

	public void setGameObjectPos(GameObjectPos gameObjectPos) {
		this.gameObjectPos = gameObjectPos;
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
	public BaseItem[] getInventory() {
		return inventory;
	}

	/**
	 * @param inventory the inventory to set
	 */
	public void setInventory(BaseItem[] inventory) {
		this.inventory = inventory;
	}
	
	

	/**
	 * @return the blood_ml
	 */
	public double getBlood_ml() {
		return blood_ml;
	}

	/**
	 * @param blood_ml the blood_ml to set
	 */
	public void setBlood_ml(double blood_ml) {
		this.blood_ml = blood_ml;
	}

	/**
	 * @return the concious
	 */
	public bool isConcious() {
		return concious;
	}

	/**
	 * @param concious the concious to set
	 */
	public void setConcious(bool concious) {
		this.concious = concious;
	}

	public bool aliveCheck() {

		if (integrityCheck() == true && alive == true) {

			return true;
		} else {
			alive = false;
			return false;
		}

	}

	/**
	 * 
	 * @param targetGameObject
	 * @return targetGrouping size in mm
	 */
	public double getTargetGroupSize(GameObject targetGameObject) {
		getAccuracy();
		double groupingFalloff = 10 + (getAccuracy() / 10);

		double targetGrouping = getDistanceFromObject(targetGameObject) / groupingFalloff;

		return targetGrouping;
	}
	
	
	
	
	

	public Animal(String objectName, bool alive, double energy, double movementSpeed, double accuracy,
			GameObjectPos gameObjectPos) : base(objectName, alive, energy, movementSpeed, accuracy,
				 gameObjectPos)
		{
		this.alive = alive;
		this.energy = energy;
		this.accuracy = accuracy;
		this.gameObjectPos = gameObjectPos;
		this.movementSpeed = movementSpeed;
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

		for (int i = 0; i < worldGameObjectList.Length; i++) {
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
				// Console.Write("You have been spotted by a " + entityName);
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

		if (getDistanceFromObject(gameObject) <= this.viewDistance) {
			if (gameObject is Entity && (((Entity) gameObject).isThePlayer)) {
				// Console.Write("You have been spotted by a " + entityName);
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

					Console.Write("A " + entityName + " is right beside you.");
				}
				// Console.Write("Caught!");
			}
			if (secondsLeft <= 0) {
				// Console.Write("\nRan out of seconds!\n");
			}

		}

		// Console.Write("\nSeconds left: " + getTicksLeft() + "\n");
		// Console.Write();

		// Console.Write(gameObjectPos.getMapAreaYPos() + "\n");

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

	public bool inAttackRange(Map worldMap, Entity targetEntity) {

		if (getDistanceFromObject(targetEntity) <= attackRange
				|| (entityWeapon != null && getDistanceFromObject(targetEntity) <= entityWeapon.getAttackRange())) {
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
//					Console.Write("Target is too far for mele.");
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
//				Console.Write("Target hit for " + getMeleDamage());
//
//			}
//
//		} else {
//			if (isThePlayer) {
//
//				Console.Write("\nTarget out of sight.\n");
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
		double timeMoveTakes = 2.5;

		if (intialMove) {
			secondsPassed = 0;
		}
		if (this.alive) {
			// for entity

			secondsLeft += secondsPassed;

			if (entityInSight(targetEntity)) {

				if (!inAttackRange(worldMap, targetEntity)) {

					if (isThePlayer) {
						
						this.addObjectStringEvents("\nTarget is out of range.\n");
						Console.Write("Target is out of range.");
						return secondsPassed;
					} else {
						chaseEntityInMapArea(worldMap, targetEntity, secondsPassed);
					}

				}

				if (movementSpeed * secondsLeft > timeMoveTakes || intialMove) {

					if (entityWeapon != null && entityWeapon is Gun) {
						((Gun) entityWeapon).fireGunAtGameObjectNoHitbox(this, targetEntity);

					} else if (getAccuracy() > rand.rollRandInt(50, 0)) {// add constants
						// add evasion calculation later
						// getTargetGroupSize(targetEntity);
						if (entityWeapon != null) {

							targetEntity.integraty -= entityWeapon.getHighestDamageType();

							secondsLeft -= timeMoveTakes;

						} else {
							targetEntity.integraty -= getMeleDamage();
							secondsLeft -= timeMoveTakes;
						}

					}

					// add something to indicate where hit and with what weapon after hit boxes and
					// weapons are added
					addObjectStringEvents("\n" + entityName + " attacked " + targetEntity.getObjectName() + " for "
							+ getMeleDamage() + " damage.");
					Console.Write(entityName + " attacked " + targetEntity.getObjectName() + " for "
							+ getMeleDamage() + " damage.");

					if (targetEntity.integraty <= 0) {
						targetEntity.setAlive(false);
						this.addObjectStringEvents("\n" + targetEntity.getObjectName() + " died.\n");
						Console.Write(targetEntity.getObjectName() + " died.");
					}

				}
				addObjectStringEvents(getObjectStringEvents() + "\n" + targetEntity.getObjectName() + " has " + targetEntity.getIntegraty() + "integraty");
				Console.Write(targetEntity.getObjectName() + " has " + targetEntity.getIntegraty() + "integraty");
			}

		}
		return secondsLeft;

	}
	
	
	public bool shootEntity(Entity targetEntity, bool intialMove) {
		double timeMoveTakes = 2.5;
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

				if (!inAttackRange(this.getGameObjectPos().getCurrentMap(), targetEntity)) {

					if (isThePlayer) {
						
						this.addObjectStringEvents("\nTarget is out of range.\n");
						Console.Write("Target is out of range.");
						return false;
					} else {
						chaseEntityInMapArea(this.getGameObjectPos().getCurrentMap(), targetEntity, secondsPassed);
					}

				}

				if (movementSpeed * secondsLeft > timeMoveTakes || intialMove) {

					if (entityWeapon != null && entityWeapon is Gun &&  ((Gun) entityWeapon).getLoadedProjectile() != null) {
						
						((Gun) entityWeapon).fireGunAtGameObjectNoHitbox(this, targetEntity);
						
						//damageToTarget = ((Gun) this.getEntityWeapon()).getLoadedProjectile().getDamamage(distanceFromTarget);
						
						
						addObjectStringEvents("\n" + entityName + " attacked " + targetEntity.getObjectName() + " for "
								+ ((Gun) entityWeapon).getLastDamage() + " damage.");
						
						
						
						
						Console.Write(entityName + " attacked " + targetEntity.getObjectName() + " for "
								+ ((Gun) entityWeapon).getLastDamage() + " damage.");
					} else {
						
						addObjectStringEvents("Gun not equipped or no projectile loaded.\n");
						
					}

					// add something to indicate where hit and with what weapon after hit boxes and
					// weapons are added


					if (targetEntity.integraty <= 0) {
						targetEntity.setAlive(false);
						this.addObjectStringEvents("\n" + targetEntity.getObjectName() + " died.\n");
						Console.Write(targetEntity.getObjectName() + " died.");
					}

				}
				addObjectStringEvents(getObjectStringEvents() + "\n" + targetEntity.getObjectName() + " has " + targetEntity.getIntegraty() + "integraty");
				Console.Write(targetEntity.getObjectName() + " has " + targetEntity.getIntegraty() + "integraty");
			}

		}
		
		
		return false;
	}

	public bool equipItemAsWeapon(BaseItem item) {

		setEntityWeapon(item);

		return false;
	}

//	private bool addItemToInventory(BaseItem item) {
//
//		for (int i = 0; i < inventory.GetLength(0); i++) {
//			if (inventory[i] == null) {
//				inventory[i] = item;
//				return true;
//			}
//
//		}
//		// Console.Write("Could not add item to inventory.");
//		return false;
//
//	}

	public bool removeItemFromInventory(BaseItem item) {
		for (int i = 0; i < inventory.GetLength(0); i++) {
			if (inventory[i] == item) {
				inventory[i] = null;
				return true;
			}
		}

		return false;
	}

	public bool itemInInventory(BaseItem item) {

		for (int i = 0; i < inventory.GetLength(0); i++) {
			if (inventory[i] == item) {
				return true;
			}
		}

		return false;
	}

	public String showInventory() {
		String inventoryString = "\n";
		int objInInv = 0;

		for (int i = 0; i < inventory.GetLength(0); i++) {
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

		if (index < inventory.GetLength(0) && inventory[index] != entityWeapon) {
			setEntityWeapon(inventory[index]);
			//removeItemFromInventory(entityWeapon);
			return true;
		}

		return false;

	}

	public bool unEquipInvintoryItemAsWeapon() {
		//addItemToInventory(getEntityWeapon());
		setEntityWeapon(null);

		return true;

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
		BaseItem[] baseItem = entity.getInventory();

		for (int i = 0; i < baseItem.GetLength(0); i++) {
			if (baseItem[i] == item) {
				entity.getInventory()[i] = null;
				itemAdded = pickUpItem(item);
			}

		}

		return itemAdded;

	}

	public bool pickUpItemOffOfGround(BaseItem item) {
		if (!item.isInInventory()) {
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

			removeItemFromInventory(item);
			item.setGameObjectPos(getGameObjectPos());
			item.setInInventory(false);
			addObjectStringEvents("\nDropped " + item.getObjectName());
			return true;

		} else {
			return false;
		}
	}
	
	


	public String toString() {
		String output = "";

		return output;
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

		Console.Write("Distance from each other: " + player.getDistanceFromObject(zombie));
//		Console.Write("Distance from each other: " + player.getDistanceFromObject(zombie2));

		// double ticksPassed = 4000;

		// Console.Write(entPos2.toString());
		// zombie.chaseEntityInMapArea(tstMap, player, ticksPassed);
		// zombie.attackEntityMele(tstMap, player, ticksPassed);
		// Console.Write(entPos2.toString());

//		Console.Write(tstMap.entitiesOnMapToString());
		Magazine _9mm_mag = new Magazine(entPos4, "9mm mag", .95, 6, 9);

		Console.Write(player.entitiesInSightListToString(tstMap));
		Console.Write(zombie.entitiesInSightListToString(tstMap));

		Console.Write("Picked up: " + player.pickUpItemOffOfGround(_9mm_mag));
		Console.Write(player.showInventory());

		Console.Write("Dropped: " + player.dropItem(_9mm_mag)); 
		Console.Write(player.showInventory());

		Console.Write(player.isInCombat());
		Console.Write(player.isSpotted());
		zombie.setAlive(false);
		tstMap.runThroughEntityActions(tstMap, player, 0);
		Console.Write(player.isInCombat());
		Console.Write(player.isSpotted());

	}

}
}
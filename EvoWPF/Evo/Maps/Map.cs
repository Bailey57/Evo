using System;


namespace Evo
{
	[System.Serializable]
	public class Map
	{

	

	private int mapSize;
	public int mapAreaSize = 200; //200x200 meters by default

	public int mapX_max;
	public int mapY_Max;

	public double[,] mapGrid;

	/**
	 * World ticks per second
	 */
	public double worldTickSpeed = .5; // rename ticks to seconds

	/**
	 * The worldMap, made of MapAreas
	 */
	public MapArea[,] gameMap;



	public int currentAmmountOfEntitiesOnMap = 0;
	public int entityMapLimit = 999000;

	//public Entity[] entitiesOnMap = new Entity[999000]; // limit initially 1000

	public GameObject[,,] gameObjectsOnMap;
	public GameObject[] gameObjectsOnMapList = new GameObject[999000];




	public int currentAmmountOfGameObjectsOnMap = 0;
	public int gameObjectMapLimit = 999000;



	//	
	//	/**
	//	 * Map constructor 1
	//	 * 
	//	 * @param mapSize
	//	 */
	//	public Map() {
	//		
	//	}

	/**
	 * Map constructor 2
	 * 
	 * @param mapSize
	 */
	
	public Map(int mapSize)
	{
		this.mapSize = mapSize;

		//mapSize = 1000;
		gameMap = new MapArea[mapSize, mapSize];
		gameObjectsOnMap = new GameObject[mapSize * mapAreaSize, mapSize * mapAreaSize, 5];

	}

	/**
	 * @return the mapX_max
	 */
	public int getMapX_max()
	{
		return mapX_max;
	}

	/**
	 * @param mapX_max the mapX_max to set
	 */
	public void setMapX_max(int mapX_max)
	{
		this.mapX_max = gameMap.Length;
	}

	/**
	 * @return the mapY_Max
	 */
	public int getMapY_Max()
	{
		return mapY_Max;
	}

	/**
	 * @param mapY_Max the mapY_Max to set
	 */
	public void setMapY_Max(int mapY_Max)
	{
		this.mapY_Max = gameMap.Length;
	}

	/**
	 * @return the worldTickSpeed
	 */
	public double getWorldTickSpeed()
	{
		return worldTickSpeed;
	}

	/**
	 * @param worldTickSpeed the worldTickSpeed to set
	 */
	public void setWorldTickSpeed(double worldTickSpeed)
	{
		this.worldTickSpeed = worldTickSpeed;
	}

	/**
	 * @return the currentAmmountOfEntitiesOnMap
	 */
	public int getCurrentAmmountOfEntitiesOnMap()
	{
		return currentAmmountOfEntitiesOnMap;
	}

	/**
	 * @param currentAmmountOfEntitiesOnMap the currentAmmountOfEntitiesOnMap to set
	 */
	public void setCurrentAmmountOfEntitiesOnMap(int currentAmmountOfEntitiesOnMap)
	{
		this.currentAmmountOfEntitiesOnMap = currentAmmountOfEntitiesOnMap;
	}

	/**
	 * @return the entityMapLimit
	 */
	public int getEntityMapLimit()
	{
		return entityMapLimit;
	}

	/**
	 * @param entityMapLimit the entityMapLimit to set
	 */
	public void setEntityMapLimit(int entityMapLimit)
	{
		this.entityMapLimit = entityMapLimit;
	}




	/**
	 * @return the gameObjectsOnMap
	 */
	public GameObject[] getGameObjectsOnMap()
	{
		return gameObjectsOnMapList;
	}

	/**
	 * @param gameObjectsOnMap the gameObjectsOnMap to set
	 */
	public void setGameObjectsOnMap(GameObject[] gameObjectsOnMapList)
	{
		this.gameObjectsOnMapList = gameObjectsOnMapList;
	}

	public double getWorldTickspeed()
	{
		return worldTickSpeed;
	}

	public void setWorldTickspeed(double worldTickspeed)
	{
		this.worldTickSpeed = worldTickspeed;
	}



	/**
	 * @return the gameObjectsOnMapList
	 */
	public GameObject[] getGameObjectsOnMapList()
	{
		return gameObjectsOnMapList;
	}

	/**
	 * @param gameObjectsOnMapList the gameObjectsOnMapList to set
	 */
	public void setGameObjectsOnMapList(GameObject[] gameObjectsOnMapList)
	{
		this.gameObjectsOnMapList = gameObjectsOnMapList;
	}

	/**
	 * @return the currentAmmountOfGameObjectsOnMap
	 */
	public int getCurrentAmmountOfGameObjectsOnMap()
	{
		return currentAmmountOfGameObjectsOnMap;
	}

	/**
	 * @param currentAmmountOfGameObjectsOnMap the currentAmmountOfGameObjectsOnMap to set
	 */
	public void setCurrentAmmountOfGameObjectsOnMap(int currentAmmountOfGameObjectsOnMap)
	{
		this.currentAmmountOfGameObjectsOnMap = currentAmmountOfGameObjectsOnMap;
	}

	/**
	 * @return the gameObjectMapLimit
	 */
	public int getGameObjectMapLimit()
	{
		return gameObjectMapLimit;
	}

	/**
	 * @param gameObjectMapLimit the gameObjectMapLimit to set
	 */
	public void setGameObjectMapLimit(int gameObjectMapLimit)
	{
		this.gameObjectMapLimit = gameObjectMapLimit;
	}

	/**
	 * @param gameMap the gameMap to set
	 */
	public void setGameMap(MapArea[,] gameMap)
	{
		this.gameMap = gameMap;
	}

	/**
	 * @param gameObjectsOnMap the gameObjectsOnMap to set
	 */
	public void setGameObjectsOnMap(GameObject[,,] gameObjectsOnMap)
	{
		this.gameObjectsOnMap = gameObjectsOnMap;
	}

	public String getWorldGameObjectInfo()
	{
		String info = "";
		for (int i = 0; i < gameObjectMapLimit; i++)
		{
			if (gameObjectsOnMapList[i] != null)
			{
					info += gameObjectsOnMapList[i].getGameObjectPos().toString();
			}

		}

		return info;
	}

	public void printWorldGameObjectInfo()
	{
		Console.WriteLine(getWorldGameObjectInfo());

	}

	//	public void addEntityToMapList(Entity entity) {
	//		bool placedOnMap = false;
	//		int entityNum = 0;
	//
	//		for (int i = 0; i < entityMapLimit; i++) {
	//			if (entitiesOnMap[i] == null) {
	//				entitiesOnMap[i] = entity;
	//				placedOnMap = true;
	//				currentAmmountOfEntitiesOnMap++;
	//				break;
	//
	//			} else if (entitiesOnMap[i] == entity){
	//				//Console.WriteLine("Entity already on map");
	//				return;
	//			}
	//			entityNum++;
	//		}
	//
	//		if (!placedOnMap) {
	//			// Console.WriteLine("Map full, can't add any more Entities.");
	//			Console.WriteLine("Map full, can't add any more Entities." + "\nEntities on map: " + entityNum + "\n\n");
	//			return;
	//		}
	//
	//	}

	public String gameObjectsOnMapToString()
	{
		String stringOutput = "";
		bool done = false;
		int iteration = 0;
		GameObject[] objectOnMap = getGameObjectsOnMap();

		while (!done)
		{
			if (objectOnMap[iteration] == null)
			{
				done = true;
				break;
			}
			else
			{

				stringOutput += "\n" + iteration + ": " + objectOnMap[iteration].getObjectName() + "\n";

				//				stringOutput += "\n" + iteration + ": " + entOnMap[iteration].getObjectName() + ", " +
				//						+ getDistanceFromObject(entOnMap[iteration]) + " meters away. \n";

				iteration++;

			}

			// entOnMap[iteration]
		}

		return stringOutput;
	}



	public bool addGameObjectToMapList(GameObject gameObject)
	{
		bool placedOnMap = false;
		int gameObjectNum = 0;

		for (int i = 0; i < entityMapLimit; i++)
		{
			if (gameObjectsOnMapList[i] == null)
			{
				gameObjectsOnMapList[i] = gameObject;
				placedOnMap = true;
				currentAmmountOfGameObjectsOnMap++;
				return placedOnMap;
				//break;

			}
			else if (gameObjectsOnMapList[i] == gameObject)
			{
				//Console.WriteLine("GameObject already on map");
				placedOnMap = false;
				return placedOnMap;
			}
			gameObjectNum++;
		}

		if (!placedOnMap)
		{
			// Console.WriteLine("Map full, can't add any more Entities.");
			Console.WriteLine("Map full, can't add any more GameObjects." + "\nGameObjects on map: " + gameObjectNum + "\n\n");
			placedOnMap = false;
		}
		return placedOnMap;

	}


	public bool removeGameObjectFromMapList(GameObject gameObject)
	{
		bool removedFromMap = false;
		int gameObjectNum = 0;

		for (int i = 0; i < entityMapLimit; i++)
		{
			if (gameObjectsOnMapList[i] == gameObject)
			{
				gameObjectsOnMapList[i] = null;
				removedFromMap = true;
				currentAmmountOfGameObjectsOnMap--;
				break;

			}
		}

		if (!removedFromMap)
		{
			// Console.WriteLine("Map full, can't add any more Entities.");
			Console.WriteLine("Cant remove GameObject: " + gameObject.getObjectName() + "\n");
			removedFromMap = false;
		}
		return removedFromMap;

	}




	public bool runThroughEntityActions(Map worldMap, Entity player, double secondsPassed)
	{
		bool spotted = false;

		for (int i = 0; i < entityMapLimit; i++)
		{
			if (!(gameObjectsOnMapList[i] is Entity) 
					|| gameObjectsOnMap[i,0,0] == null
					|| (((Entity)gameObjectsOnMapList[i]).getIsThePlayer())) {
			break;
		} else
		{

			if (((Entity)gameObjectsOnMapList[i]).entityInSight(player) && (((Entity)gameObjectsOnMapList[i]).alive))
			{
				((Entity)gameObjectsOnMapList[i]).attackEntity(worldMap, player, secondsPassed, false);

				if (player.getIsThePlayer())
				{
					if (!player.isSpotted() && !player.isInCombat())
					{

						player.addObjectStringEvents("\nSpotted by a " + ((Entity)gameObjectsOnMapList[i]).getEntityName() + ".\n");
						player.addObjectStringEvents("\nEntered combat.\n");

						Console.WriteLine("Spotted by a " + ((Entity)gameObjectsOnMapList[i]).getEntityName() + ".");
						Console.WriteLine("Entered combat.");
					}
					player.setSpotted(true);
					player.setInCombat(true);
					spotted = true;


				}




			}

		}

	}
		if (!spotted) {
			//Console.WriteLine("\n" + player.getObjectName() + " is hidden from view.");
			
			player.setSpotted(false);
			if (player.isInCombat() && player.getIsThePlayer()) {
				player.addObjectStringEvents("\nExited combat.\n");
				Console.WriteLine("Exited combat.");
}
player.setInCombat(false);
			
			
		}
		return spotted;

	}
	// MapArea forest = new MapArea("Forest", "F", .1);

	// MapArea street = new MapArea("Street", "S", .01);

	// MapArea town = new MapArea("Town", "T", .2);

	/**
	 * Makes a 1x1 area for the game map.
	 * 
	 * @param areaName
	 * @param displayLetter
	 * @param zombieDensity
	 * @return new area
	 */
//	public MapArea makeArea(String areaName, String displayLetter, double zombieDensity) {
//		MapArea newMA = new MapArea(areaName, displayLetter, zombieDensity);
//		return newMA;
//	}





	/**
	 * Returns the global map
	 * 
	 * @return map
	 */
	public MapArea[,] getGameMap()
{
	return this.gameMap;
}

/**
 * Initialize the player onto the map.
 * 
 * @param xPos
 * @param yPos
 * @param playerOnArea
 */
public void setGameMapPlayer(int xPos, int yPos, bool playerOnArea_)
{
	gameMap[yPos, xPos].playerOnArea = playerOnArea_;
}

/**
 * Makes a test gameMap, not gonna use in final game.
 */
public void makeGameMap1()
{
	MapAreaFactory mapFact = new MapAreaFactory(this);
	mapFact.worldMap = this;
	this.gameMap = new MapArea[25, 25];

	for (int i = 0; i < 25; i++)
	{


		Console.WriteLine();




		for (int k = 0; k < 25; k++)
		{
			if (i == 9 && k > 10)
			{
				this.gameMap[i, k] = mapFact.makeStreet(i, k);

			}
			else if (k == 10)
			{
				this.gameMap[i, k] = mapFact.makeStreet(i, k);

			}
			else if (k == 9)
			{
				this.gameMap[i, k] = mapFact.makeTown(i, k);

			}
			else
			{
				this.gameMap[i, k] = mapFact.makeForest(i, k);
			}

			if (gameMap[i, k].playerOnArea)
			{
				// Console.Write("P ");
			}
			else
			{
				// Console.Write(map[i][k].areaName + " ");
			}

		}

	}



	//		Console.WriteLine();
	//		Console.WriteLine(map[0].length);
	//		Console.WriteLine(map[1].length);
}



public String getGameMapString()
{
	String mapString = "";
	for (int i = 0; i < 25; i++)
	{
		mapString += "\n";

		for (int k = 0; k < 25; k++)
		{


			if (gameMap[i, k] != null)
			{
				if (gameMap[i, k].playerOnArea)
				{
					mapString += "P ";

				}
				else
				{
					mapString += gameMap[i, k].getDisplayLetter() + " ";

				}

			}


		}

	}

	mapString += "\n";
	return mapString;

}

/**
 * Prints the game map
 */
public void printGameMapString()
{
	Console.WriteLine(getGameMapString());

}




public static void main(String[] args)
{
	Map US_forest = new Map(25);

	//US_forest.makeMap1(US_forest);
	//US_forest
	MapAreaFactory mapFact = new MapAreaFactory(US_forest);
	mapFact.makeMapAreaForGameMap(0, 0);

	GameObjectPos entPos = new GameObjectPos(US_forest, 0, 0, 2, 2);
	GameObjectPos entPos2 = new GameObjectPos(US_forest, 0, 0, 0, 0);
	BaseItem spear = new BaseItem(entPos2, "spear", 20);
	spear.setPierce(20);



	Entity player = new Entity("player", true, 100, 1.5, 100, entPos);
	player.setViewDistance(1000);
	player.setIsThePlayer(true); ;

	Entity zombie = new Entity("zombie", true, 100, 1.5, 100, entPos2);

	entPos.setMapAreaXPos(100);
	entPos.setMapAreaYPos(100);

	entPos2.setMapAreaXPos(50);
	entPos2.setMapAreaYPos(50);



	// US_forest.runThroughEntitieActions(US_forest, player, 1000);

	if (US_forest.addGameObjectToMapList(zombie))
	{
		Console.WriteLine("z added");
	}

	if (US_forest.addGameObjectToMapList(player))
	{
		Console.WriteLine("player added");
	}

	if (US_forest.addGameObjectToMapList(spear))
	{
		Console.WriteLine("spear added");
	}






	//US_forest.printWorldGameObjectInfo();

	US_forest.printGameMapString();
	Console.WriteLine("Entities on map: " + US_forest.getCurrentAmmountOfEntitiesOnMap() + "\n");
	// player start: [24][12]



	Console.WriteLine(player.itemInSight(spear));
	Console.WriteLine(player.itemsInSightListToString(US_forest));



}

}


}
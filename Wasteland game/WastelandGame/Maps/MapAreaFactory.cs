using System;


namespace Wasteland_game
{

	public class MapAreaFactory
	{
		//Note: add something to keep track of entities in the map area 

		private int difficulty;

		private int elevation;


		public Map worldMap;
		public double xPosOnMap;
		public double yPosOnMap;


		/**
		 * Generates MapAreas for Map 
		 */
		public MapAreaFactory(Map worldMap)
		{
			this.worldMap = worldMap;
		}

		public int getDifficulty()
		{
			return difficulty;
		}

		public void setDifficulty(int difficulty)
		{
			this.difficulty = difficulty;
		}

		public int getElevation()
		{
			return elevation;
		}

		public void setElevation(int elevation)
		{
			this.elevation = elevation;
		}

		public double getXPosOnMap()
		{
			return xPosOnMap;
		}

		public void setXPosOnMap(int xPosOnMap)
		{
			this.xPosOnMap = xPosOnMap;
		}

		public double getYPosOnMap()
		{
			return yPosOnMap;
		}

		public void setYPosOnMap(int yPosOnMap)
		{
			this.yPosOnMap = yPosOnMap;
		}



		/**
		 * @return the worldMap
		 */
		public Map getWorldMap()
		{
			return worldMap;
		}

		/**
		 * @param worldMap the worldMap to set
		 */
		public void setWorldMap(Map worldMap)
		{
			this.worldMap = worldMap;
		}


		public MapArea makeMapAreaForGameMap(int xCordOnGameMap, int yCordOnGameMap)
		{



			MapArea mapArea = new MapArea("Test", "Test", 0, 10, xCordOnGameMap, yCordOnGameMap);
			mapArea.setMapAreaX_min(0);
			mapArea.setMapAreaX_max(200);

			mapArea.setMapAreaY_min(0);
			mapArea.setMapAreaY_max(200);

			worldMap.gameMap[yCordOnGameMap, yCordOnGameMap] = mapArea;




			return mapArea;
		}

		public MapArea makeForest(int xPosOnMap, int yPosOnMap)
		{
			difficulty = 5;
			elevation = 1000;
			int entitiesOnMapArea = entitiesOnMapArea(difficulty);

			MapArea newMapArea = new MapArea("forest", "F", entitiesOnMapArea, elevation, xPosOnMap, yPosOnMap);

			makeMultipleEntitieOnMapArea(entitiesOnMapArea, newMapArea, 5);

			return newMapArea;
		}

		public MapArea makeTown(int xPosOnMap, int yPosOnMap)
		{
			difficulty = 5;
			elevation = 1000;
			int entitiesOnMapArea = entitiesOnMapArea(difficulty);

			MapArea newMapArea = new MapArea("town", "T", entitiesOnMapArea, elevation, xPosOnMap, yPosOnMap);
			makeMultipleEntitieOnMapArea(entitiesOnMapArea, newMapArea, 5);
			return newMapArea;
		}

		public MapArea makeStreet(int xPosOnMap, int yPosOnMap)
		{
			difficulty = 5;
			elevation = 1000;
			int entitiesOnMapArea = entitiesOnMapArea(difficulty);

			MapArea newMapArea = new MapArea("street", "S", entitiesOnMapArea, elevation, xPosOnMap, yPosOnMap);
			makeMultipleEntitieOnMapArea(entitiesOnMapArea, newMapArea, 5);
			return newMapArea;
		}

		/**
		 * Generates a rand num of entities on a MapArea based on the area's difficulty
		 * 
		 * @param areaDifficulty
		 * @return
		 */
		public int entitiesOnMapArea(int areaDifficulty)
		{
			int entitiesOnAra = 0;
			int max = areaDifficulty;
			int min = 0;
			entitiesOnAra = (int)(Math.random() * (max - min + 1) + min);
			return entitiesOnAra;
		}

		public void makeMultipleEntitieOnMapArea(int ammountOfEntities, MapArea mapArea, int areaDifficulty)
		{
			if (ammountOfEntities == 0)
			{
				return;
			}
			for (int i = 0; i < ammountOfEntities; i++)
			{
				makeEntitieOnMapArea(mapArea, areaDifficulty);
			}


		}

		public void makeEntitieOnMapArea(MapArea mapArea, int areaDifficulty)
		{
			double max = 0;
			double min = 0;


			GameObjectPos entPos = new GameObjectPos(worldMap, mapArea.getPosOnMapX(), mapArea.getPosOnMapY(), 0, 0);


			Entity entity = new Entity("humanoid enemy", true, 100, 1, 50, entPos);
			Hitbox humanHitbox = new Hitbox();
			humanHitbox = humanHitbox.newHumanHitbox();
			entity.setGameObjectHitbox(humanHitbox);
			entPos.setGameObject(entity);

			//Entity(String objectName, double integraty, bool alive, double energy, double movementSpeed, double accuracy, GameObjectPos GameObjectPos)

			double entMapPos = 0;


			max = mapArea.getMapAreaX_max();
			min = mapArea.getMapAreaX_min();
			entMapPos = (int)(Math.random() * (max - min + 1) + min);

			entPos.setMapAreaXPos(entMapPos);


			max = mapArea.getMapAreaY_max();
			min = mapArea.getMapAreaY_min();

			entMapPos = (int)(Math.random() * (max - min + 1) + min);
			entPos.setMapAreaYPos(entMapPos);

			this.worldMap.addGameObjectToMapList(entity);

		}




		public static void main(String[] args)
		{


			//MapAreaFactory mapFac = new MapAreaFactory();

			//		System.out.println(mapFac.makeForest().entitiesOnArea);
			//		System.out.println(mapFac.makeForest().entitiesOnArea);
			//		System.out.println(mapFac.makeForest().entitiesOnArea);
			//		System.out.println(mapFac.makeForest().entitiesOnArea);
		}

	}


}
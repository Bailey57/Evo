using Evo.GameObjects.HitBoxes;
using System;
using Evo.Factions;

namespace Evo.Factories
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
            RandomNumbers rn = new RandomNumbers();
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
            int entitiesOnMapArea = entitiesOnMapAreaNum(difficulty);

            MapArea newMapArea = new MapArea("forest", "F", entitiesOnMapArea, elevation, xPosOnMap, yPosOnMap);

            //makeMultipleEntitieOnMapArea(entitiesOnMapArea, newMapArea, 5);

            return newMapArea;
        }

        public MapArea makeTown(int xPosOnMap, int yPosOnMap)
        {
            difficulty = 5;
            elevation = 1000;
            int entitiesOnMapArea = entitiesOnMapAreaNum(difficulty);

            MapArea newMapArea = new MapArea("town", "T", entitiesOnMapArea, elevation, xPosOnMap, yPosOnMap);
            //makeMultipleEntitieOnMapArea(entitiesOnMapArea, newMapArea, 5);
            return newMapArea;
        }

        public MapArea makeStreet(int xPosOnMap, int yPosOnMap)
        {
            difficulty = 5;
            elevation = 1000;
            int entitiesOnMapArea = entitiesOnMapAreaNum(difficulty);

            MapArea newMapArea = new MapArea("street", "S", entitiesOnMapArea, elevation, xPosOnMap, yPosOnMap);
            //makeMultipleEntitieOnMapArea(entitiesOnMapArea, newMapArea, 5);
            return newMapArea;
        }

        /**
		 * Generates a rand num of entities on a MapArea based on the area's difficulty
		 * 
		 * @param areaDifficulty
		 * @return
		 */
        public int entitiesOnMapAreaNum(int areaDifficulty)
        {
            int entitiesOnAra = 0;
            int max = areaDifficulty;
            int min = 0;
            Random random = new Random();
            //entitiesOnAra = (int)(Math.Random() * (max - min + 1) + min);
            entitiesOnAra = random.Next(min, max);

            return entitiesOnAra;
        }



        public void PopulateGameMap(GameState gameState) 
        {
            int Xmax = gameState.GetMainMap().getMapX_max();
            int Ymax = gameState.GetMainMap().getMapY_max();
            for (int x = 0; x < Xmax; x++) 
            {
                for (int y = 0; y < Ymax; y++) 
                {
                    // Faction facion = gameState.GetFactionList()[1];
                    makeMultipleEntitieOnMapArea(3, gameState.GetMainMap().getGameMap()[y, x], 1, gameState.GetFactionList()[0]);
                    //gameState.GetMainMap().getGameMap()[y,x].

                }
            }


            //makeMultipleEntitieOnMapArea(entitiesOnMapArea, newMapArea, 5);


        }

        public void makeMultipleEntitieOnMapArea(int ammountOfEntities, MapArea mapArea, int areaDifficulty, Faction faction)
        {
            if (ammountOfEntities == 0)
            {
                return;
            }
            for (int i = 0; i < ammountOfEntities; i++)
            {
                makeEntitieOnMapArea(mapArea, areaDifficulty, faction);
            }


        }

        public void makeEntitieOnMapArea(MapArea mapArea, int areaDifficulty, Faction faction)
        {
            
            double max = 0;
            double min = 0;
            Random random = new Random();
            RandomNumbers rn = new RandomNumbers();

            GameObjectPos entPos = new GameObjectPos(worldMap, mapArea.getPosOnMapX(), mapArea.getPosOnMapY(), 0, 0);
            Armor armor = ArmorFactory.randomArmor();
            Armor armor2 = ArmorFactory.MakeGenericArmorPlate_TESTING_4mm();
            int rand = rn.rollRandInt(1, 0);



            RandomNumbers rn2 = new RandomNumbers();
            int randNum = rn2.rollRandInt(1000, -1000);
            Entity entity = new Entity("humanoid enemy " + randNum, true, 100, 1, 50, entPos);
            Hitbox humanHitbox = new Hitbox();
            humanHitbox = humanHitbox.newHumanHitbox();
            entity.setGameObjectHitbox(humanHitbox);
            entPos.setGameObject(entity);

            //add armor chance
            //50% 
            if (rand == 1) 
            {
                //entity.getGameObjectHitbox().addArmorToHitbox(armor);
            }
            entity.getGameObjectHitbox().addArmorToHitbox(armor2);
            //Entity(String objectName, double integraty, bool alive, double energy, double movementSpeed, double accuracy, GameObjectPos GameObjectPos)

            double entMapPos = 0;


            max = mapArea.getMapAreaX_max();
            min = mapArea.getMapAreaX_min();
            entMapPos = random.Next((int)min, (int)max);
            //entMapPos = (int)(Math.random() * (max - min + 1) + min);





            entPos.setMapAreaXPos(entMapPos);


            max = mapArea.getMapAreaY_max();
            min = mapArea.getMapAreaY_min();

            entMapPos = random.Next((int)min, (int)max);
            //entMapPos = (int)(Math.random() * (max - min + 1) + min);


            entPos.setMapAreaYPos(entMapPos);
            entity.Faction = faction;
            worldMap.addGameObjectToMapList(entity);

        }




        public static void main(string[] args)
        {


            //MapAreaFactory mapFac = new MapAreaFactory();

            //		System.out.println(mapFac.makeForest().entitiesOnArea);
            //		System.out.println(mapFac.makeForest().entitiesOnArea);
            //		System.out.println(mapFac.makeForest().entitiesOnArea);
            //		System.out.println(mapFac.makeForest().entitiesOnArea);
        }

    }


}
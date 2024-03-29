﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo
{
	/*
    package wasteland.map;

import java.io.Serializable;

using Wasteland.GameObject;
using Wasteland.entity.Entity;
*/
	[System.Serializable]
	public class GameObjectPos {
	/**
	 * 
	 */
	//private static final long serialVersionUID = 1L;

	GameObject gameObject;
	
	int worldMapXPos = 0;
	int worldMapYPos = 0;

	double mapAreaXPos = 0;
	double mapAreaYPos = 0;
	
	double mapAreaZPos = 0;

	MapArea currentArea;

	Map currentMap;

//	/**
//	 * The players current position on the world map
//	 * 
//	 * @param xPos
//	 * @param yPos
//	 */
//	public GameObjectPos(int xPos, int yPos) {
//		this.worldMapXPos = xPos;
//		this.worldMapYPos = yPos;
//		// setGameMapPlayer(xPos, yPos, true);
//	}
	
	/**
	 * The players current position on the world map
	 * 
	 * @param xPos
	 * @param yPos
	 */
	public GameObjectPos(Map currentMap, int worldMapXPos, int worldMapYPos, double mapAreaXPos, double mapAreaYPos) {
		
		this.currentMap = currentMap;
		
		this.worldMapXPos = worldMapXPos;
		this.worldMapYPos = worldMapYPos;
		this.mapAreaXPos = mapAreaXPos;
		this.mapAreaYPos = mapAreaYPos;
		
		if (currentMap != null) {
			this.currentArea = currentMap.gameMap[worldMapYPos, worldMapXPos];
		}


	}
	
	

//	/**
//	 * The players current position on the world map
//	 * 
//	 * @param xPos
//	 * @param yPos
//	 */
//	public GameObjectPos(GameObject gameObject, int xPos, int yPos, MapArea currentArea) {
//		this.gameObject = gameObject;
//		this.worldMapXPos = xPos;
//		this.worldMapYPos = yPos;
//
//		this.currentArea = currentArea;
//		
//		
//		
//		this.currentArea.getGameObjectsOnMapAreaCords()[(int) mapAreaXPos][(int) mapAreaYPos] = gameObject;
//		// setGameMapPlayer(xPos, yPos, true);
//	}

	
	/**
	 * @return the currentArea
	 */
	public MapArea getCurrentArea() {
		return currentArea;
	}

	/**
	 * @param currentArea the currentArea to set
	 */
	private void setCurrentArea(MapArea currentArea) {
		
		this.currentArea = currentArea;
	}

	public double getMapAreaXPos() {
		return mapAreaXPos;
	}

	public void setMapAreaXPos(double mapAreaXPos) {
		
		this.mapAreaXPos = mapAreaXPos;
		
	}

	public void moveMapAreaXPos(double movingDistance) {
		this.mapAreaXPos += movingDistance;
	}

	public double getMapAreaYPos() {
		return mapAreaYPos;
	}

	public void setMapAreaYPos(double mapAreaYPos) {
		this.mapAreaYPos = mapAreaYPos;
	}

	public void moveMapAreaYPos(double movingDistance) {
		this.mapAreaYPos += movingDistance;
	}

	/**
	 * @return the worldMapXPos
	 */
	public int getWorldMapXPos() {
		return worldMapXPos;
	}

	/**
	 * @param worldMapXPos the worldMapXPos to set
	 */
	public void setWorldMapXPos(int worldMapXPos) {
		this.worldMapXPos = worldMapXPos;
	}

	/**
	 * @return the worldMapYPos
	 */
	public int getWorldMapYPos() {
		return worldMapYPos;
	}

	/**
	 * @param worldMapYPos the worldMapYPos to set
	 */
	public void setWorldMapYPos(int worldMapYPos) {
		this.worldMapYPos = worldMapYPos;
	}

	/**
	 * @return the currentMap
	 */
	public Map getCurrentMap() {
			return currentMap;
	}
	
	
	

	/**
	 * @return the gameObject
	 */
	public GameObject getGameObject() {
		return gameObject;
	}

	/**
	 * @param gameObject the gameObject to set
	 */
	public void setGameObject(GameObject gameObject) {
		
		//change to GameObject later
		if (gameObject is Entity) {			
			
			currentMap.addGameObjectToMapList(((Entity) gameObject));
		}
		
		
		this.gameObject = gameObject;
	}

	/**
	 * @param currentMap the currentMap to set 
	 */
	public void setCurrentMap(Map currentMap) {
		this.currentMap = currentMap;
	}

		//	/**
		//	 * Moves player on the map
		//	 * 
		//	 * @param currentMap
		//	 * @param xMove
		//	 * @param yMove
		//	 */
		//	public void changePlayerPos(MapArea currentMap[][], int xMove, int yMove) {
		//		int newXPos = worldMapXPos + xMove;
		//		int newYPos = worldMapYPos + yMove;
		//
		//		// check to see if at edge of map
		//		if (currentMap[1].GetLength(0) <= newXPos || newXPos < 0) {
		//			Console.WriteLine("You cant go that way on the x axis");
		//		} else if (currentMap[0].GetLength(0) <= newYPos || newYPos < 0) {
		//			Console.WriteLine("You cant go that way on the y axis");
		//		} else {
		//			currentMap[worldMapYPos][worldMapXPos].playerOnArea = false;
		//			currentArea.getGameObjectsOnMapAreaCords()[(int) mapAreaYPos / 200][(int) mapAreaXPos / 200] = null;
		//
		//			if (newXPos > worldMapXPos) {
		//				mapAreaXPos = 0;
		//			}
		//			if (newXPos < worldMapXPos) {
		//				mapAreaXPos += 200;
		//			}
		//			if (newYPos > worldMapYPos) {
		//				mapAreaYPos = 200;
		//			}
		//			if (newYPos < worldMapYPos) {
		//				mapAreaYPos = 0;
		//			}
		//			this.worldMapXPos = newXPos;
		//			this.worldMapYPos = newYPos;
		//			currentMap[newYPos][newXPos].playerOnArea = true;
		//			currentArea = currentMap[newYPos][newXPos];
		//
		//			currentArea.getGameObjectsOnMapAreaCords()[worldMapYPos / 200][worldMapXPos / 200] = null;
		//		}
		//
		//	}

		//	public void movePositionOnMap(String direction) {
		//
		//		if (direction.Equals("n") || direction.Equals("N")) {
		//			changePlayerPos(currentMap.gameMap, 0, -1);
		//		} else if (direction.Equals("s") || direction.Equals("S")) {
		//			changePlayerPos(currentMap.gameMap, 0, 1);
		//		} else if (direction.Equals("e") || direction.Equals("E")) {
		//			changePlayerPos(currentMap.gameMap, 1, 0);
		//		} else if (direction.Equals("w") || direction.Equals("W")) {
		//			changePlayerPos(currentMap.gameMap, -1, 0);
		//		} else {
		//			Console.WriteLine("input invalid");
		//		}
		//
		//	}







		public double GetOverallXPosition() 
		{
			//return this.getMapAreaXPos() + (this.sizeOfMapArea()  this.getWorldMapXPos());
			return this.getMapAreaXPos() + (200 * getWorldMapXPos());
		}
		public double GetOverallYPosition()
		{
			//return this.getMapAreaXPos() + (this.sizeOfMapArea()  this.getWorldMapXPos());
			return this.getMapAreaYPos() + (200 * getWorldMapYPos());
		}


		public double GetDistanceFromGameObjectPos(GameObjectPos gameObjectpos)
		{
			double distance = 0;

			//		distance = Math.abs(entity.getGameObjectPos().getMapAreaXPos() - getGameObjectPos().getMapAreaXPos());
			//		distance += Math.abs(entity.getGameObjectPos().getMapAreaYPos() - getGameObjectPos().getMapAreaYPos());
			//
			//		Math.pow(entity.getGameObjectPos().getMapAreaXPos() - getGameObjectPos().getMapAreaXPos(), 2);
			//		Math.pow(entity.getGameObjectPos().getMapAreaYPos() - getGameObjectPos().getMapAreaYPos(), 2);

			distance = Math.Sqrt(Math.Pow(gameObjectpos.GetOverallXPosition() - this.GetOverallXPosition(), 2) + 
				Math.Pow(gameObjectpos.GetOverallYPosition() - this.GetOverallYPosition(), 2));

			return distance;
		}





		// rename to travelOnMapArea
		//redo this 
		public bool movePositionOnMapArea(String direction, double distance) {
		int oldMapX = gameObject.getGameObjectPos().getWorldMapXPos();
		int oldMapY = gameObject.getGameObjectPos().getWorldMapYPos();
				
		
		double oldMapAreaX = gameObject.getGameObjectPos().getMapAreaXPos();
		double oldMapAreaY = gameObject.getGameObjectPos().getMapAreaYPos();
		
		
		bool moved = false;
		// entity.getGameObjectPos().getCurrentArea();

		// MapArea oldMapArea = entity.getGameObjectPos().getCurrMapArea();

		int yMove = 0;
		int xMove = 0;
		if (direction.Equals("n") || direction.Equals("N")) {
			// changePlayerPos(currentMap, 0, -1);
			yMove = -1;
			//moveGameObjectOnMapAreaY(currentMap, gameObject, -distance);
		} else if (direction.Equals("s") || direction.Equals("S")) {
			// changePlayerPos(currentMap, 0, 1);
			yMove = 1;
			//moveGameObjectOnMapAreaY(currentMap, gameObject, distance);
		} else if (direction.Equals("e") || direction.Equals("E")) {
			xMove = 1;
			// changePlayerPos(currentMap, 1, 0);
			//moveGameObjectOnMapAreaX(currentMap, gameObject, distance);
		} else if (direction.Equals("w") || direction.Equals("W")) {
			// changePlayerPos(currentMap, -1, 0);
			xMove = -1;
			//moveGameObjectOnMapAreaX(currentMap, gameObject, -distance);
		} else {
			Console.WriteLine("input invalid");
			this.gameObject.addObjectStringEvents("\ninput invalid\n");
			return moved;
		}
		
		
		double newMapAreaYPos = gameObject.getGameObjectPos().mapAreaYPos + yMove;
		double newMapAreaXPos = gameObject.getGameObjectPos().mapAreaXPos + xMove;


		if (currentMap.gameMap.GetLength(0) * 199 >= newMapAreaXPos && newMapAreaXPos >= 0) {

			gameObject.getGameObjectPos().mapAreaXPos = newMapAreaXPos;

		} if (currentMap.gameMap.GetLength(0) * 199 >= newMapAreaYPos && newMapAreaYPos >= 0) {

			gameObject.getGameObjectPos().mapAreaYPos = newMapAreaYPos;

		} else {
			Console.WriteLine("Thats off the map.");
			this.gameObject.addObjectStringEvents("\nThats off the map.\n");
			return moved;
		}

		if (onCorrectMapArea()) {
			if (oldMapY < currentMap.gameMap.GetLength(0) && oldMapX < currentMap.gameMap.GetLength(0)) {
				currentMap.gameMap[oldMapY, oldMapX].playerOnArea = false;
				
				//change later to accept z values in last place
				currentMap.gameObjectsOnMap[(int) oldMapAreaY, (int) oldMapAreaX, 0] = null;
				
			}
			
			this.getCurrentArea().gameObjectsOnMapAreaCords[(int) oldMapAreaY  / (getWorldMapYPos() + 1), (int) oldMapAreaX / (getWorldMapXPos() + 1)] = null;
		
			
			
			updateGameObjectMapPosition();
		}
		
		if (oldMapAreaX == newMapAreaXPos && oldMapAreaY == newMapAreaYPos) {
			moved = false;
		} else {
			moved = true;
		}





			//this.gameObject.addObjectStringEvents("\nTraveled " + direction + " " + distance + " meters." + "\n");
			return moved;

	}

	/**
	 * Checks if the GameObject is in correct MapArea
	 * 
	 * @param gameObject
	 * @return
	 */
	private bool onCorrectMapArea() {
			if (gameObject.getGameObjectPos() != null && gameObject.getGameObjectPos().getCurrentArea() == null)
			{
				gameObject.getGameObjectPos().setCurrentArea(gameObject.getGameObjectPos().getCurrentMap().getGameMap()[gameObject.getGameObjectPos().getWorldMapXPos(),
					gameObject.getGameObjectPos().getWorldMapYPos()]);


			} else if (gameObject.getGameObjectPos() == null) 
			{
				return false;
			}

		if (gameObject.getGameObjectPos().getCurrentArea().getMapAreaX_max() < gameObject.getGameObjectPos()
				.getMapAreaXPos()
				&& gameObject.getGameObjectPos().getCurrentArea().getMapAreaY_max() < gameObject.getGameObjectPos()
						.getMapAreaYPos()
				&& gameObject.getGameObjectPos().getCurrentArea().getMapAreaX_min() > gameObject.getGameObjectPos()
						.getMapAreaXPos()
				&& gameObject.getGameObjectPos().getCurrentArea().getMapAreaY_min() > gameObject.getGameObjectPos()
						.getMapAreaYPos()) {
			return false;
		} else {
			return true;
		}

	}

	/**
	 * Player chooses how long to move in a single direction in minutes, updates
	 * entities as the player moves
	 * 
	 * @param currentMap
	 * @param entity
	 * @param direction
	 * @param time       in minutes
	 */
	public void movePlayerOnMapArea(Map currentMap, Entity entity, String direction, double minutes) {
		double secondsPassed = 1;// change name to secondsPassedEachLoop

		double seconds = minutes * 60; // convert to seconds
		int iterations = 0;
		
		bool moved = false;

		// might need to change back to i = 0
		for (double i = 0; i < seconds; i += secondsPassed) {
			if (this.getMapAreaXPos() == 0) {
				//int daofd = 0;
			}

//			if (i >= 133) {
//				int m = 0;
//			}
			
			moved = movePositionOnMapArea(direction, entity.movementSpeed * secondsPassed);

			if (moved) {
				
				// change to spotted by an enemy method and uncomment
				//!entity.isInCombat()
				if (!entity.isInCombat() && currentMap.runThroughEntityActions(currentMap, entity, secondsPassed) && entity.isSpotted()) {
					this.gameObject.addObjectStringEvents("\nSpotted: Walked " + (i * secondsPassed * entity.movementSpeed) + " meters in "
							+ i * secondsPassed + " seconds.\n");
					
					Console.WriteLine("Spotted: Walked " + (i * secondsPassed * entity.movementSpeed) + " meters in "
							+ i * secondsPassed + " seconds.\n");
					return;
				}
				
			} else {
				if (iterations == 0) {
					this.gameObject.addObjectStringEvents("\nDidnt move.\n");
				} else {
					this.gameObject.addObjectStringEvents("\nStopped moving.\n");
				}
				
				return;
			}
		



			iterations++;
		}

		// tst using
//		while (iterations < seconds) {
//			movePositionOnMapArea(currentMap, entity, direction, entity.movementSpeed * secondsPassed);
//			
//			//change to spotted by an enemy method
//			if (currentMap.runThroughEntitieActionsWhilePlayerMoves(currentMap, entity, secondsPassed)) {
//				Console.WriteLine("\nspotted: Walked " + (i * secondsPassed * entity.movementSpeed) + " meters in " + i * secondsPassed + " seconds.\n");
//				return;
//			}
//			
//			iterations++;
//			
//		}

		// Console.WriteLine("\ndone moving\n");
		this.gameObject.addObjectStringEvents("\nWalked " + (iterations * secondsPassed * entity.movementSpeed)
				+ " meters in " + iterations * secondsPassed + " seconds.\n");
		Console.WriteLine("Walked " + (iterations * secondsPassed * entity.movementSpeed)
				+ " meters in " + iterations * secondsPassed + " seconds.\n");

	}
	
	
	//add part that delets object from MapArea when it isnt on there any more
	private void updateGameObjectMapPosition() {
		int mapMaxSize = 25;
		
		
		//double newMapAreaX, double newMapAeraY

		//oldMapArea.playerOnArea = false;
		// maybe add check to see if on same map
		//gameObject.getGameObjectPos().getCurrentMap().map[(int) getMapAreaYPos()][(int) getMapAreaXPos()].playerOnArea = false;
		
		if((int) Math.Floor(getMapAreaXPos() / 199) < mapMaxSize && (int) Math.Floor(getMapAreaYPos() / 199) < mapMaxSize) {
			
			gameObject.getGameObjectPos().setWorldMapXPos((int) Math.Floor(getMapAreaXPos() / 199));
			gameObject.getGameObjectPos().setWorldMapYPos((int) Math.Floor(getMapAreaYPos() / 199));
			

			gameObject.getGameObjectPos().setCurrentArea(this.currentMap.gameMap[(int) getWorldMapYPos(), (int) getWorldMapXPos()]);
			
			
			this.getCurrentArea().gameObjectsOnMapAreaCords[(int) getMapAreaYPos() / (getWorldMapYPos() + 1), (int) getMapAreaXPos() / (getWorldMapXPos() + 1)] = this.getGameObject();

			if (gameObject is Entity && ((Entity)gameObject).getIsThePlayer()) {
				gameObject.getGameObjectPos().getCurrentArea().playerOnArea = true;
			}
			
		}



	}

//	private void moveGameObjectOnMapArea(Map currentMap, GameObject gameObject, double xMove, double yMove) {
//		double newMapAreaYPos = gameObject.getGameObjectPos().mapAreaYPos + yMove;
//		double newMapAreaXPos = gameObject.getGameObjectPos().mapAreaXPos + xMove;
//
//		if (currentMap.gameMap.GetLength(0) * 199 >= newMapAreaXPos && newMapAreaXPos >= 0) {
//
//			gameObject.getGameObjectPos().mapAreaXPos = newMapAreaXPos;
//
//		} else if (currentMap.gameMap.GetLength(0) * 199 >= newMapAreaYPos && newMapAreaYPos >= 0) {
//
//			gameObject.getGameObjectPos().mapAreaYPos = newMapAreaYPos;
//
//		} else {
//			Console.WriteLine("Thats off the map");
//		}
//		
//		
//
//
//
//	}
//
//	private void moveGameObjectOnMapAreaY(Map currentMap, GameObject gameObject, double yMove) {
//
//		double newMapAreaYPos = gameObject.getGameObjectPos().mapAreaYPos + yMove;
//
//		if (currentMap.gameMap.GetLength(0) * 199 >= newMapAreaYPos && newMapAreaYPos >= 0) {
//
//			gameObject.getGameObjectPos().mapAreaYPos = newMapAreaYPos;
//
//		} else {
//			Console.WriteLine("Thats off the map");
//		}
//	
//
//	}
//	
	
//	/**
//	 * Replaces all the old Map Area data with new data
//	 * 
//	 */
//	private void overwriteGameObjectMapPosition(int newWorldMapX, int newWorldMapY, double newMapAreaX, double newMapAreaY) {
//		//add code to replace old
//		
//		
//	}

	public String getPlayerAreaName(MapArea[,] currentMap) {
		return currentMap[worldMapYPos, worldMapXPos].getAreaName();
	}

	//@Override
	public String toString() {
		return "\nMap X: " + worldMapXPos + ", " + "\nMap Y: " + worldMapYPos + "\n\nMap Area X: " + mapAreaXPos
				+ "\nMap Area Y: " + mapAreaYPos;
	}

	public void printToString() {
		Console.WriteLine(toString());
	}

	public void setCurrMapArea(MapArea[][] currentMap) {
		currentArea = currentMap[worldMapXPos][worldMapYPos];
	}

	public static void main(String[] args) {

		

		Map newMap = new Map(25);
		newMap.makeGameMap1();
		
		GameObjectPos newPlayerPos = new GameObjectPos( newMap, 0, 0, 0, 0);

		Entity player = new Entity("Player", true, 100, 1.5, 100, newPlayerPos);
		player.setIsThePlayer(true);
//		newPlayerPos.currentArea = newMap.map[0][0];
//		newPlayerPos.setMapAreaXPos(0);
//		newPlayerPos.setMapAreaYPos(0);

		newMap.setGameMapPlayer(0, 0, true);
		newMap.printGameMapString();

//		Console.WriteLine(newPlayerPos.getPlayerAreaName(newMap.map));
//		Console.WriteLine(newPlayerPos.toString());
//		newMap.printGameMap();

//		newPlayerPos.changePlayerPos(newMap.map, 1, -30);
//		Console.WriteLine(newPlayerPos.getPlayerAreaName(newMap.map));
//		Console.WriteLine(newPlayerPos.toString());
//		newMap.printGameMap();
//		
//		newPlayerPos.setMapAreaYPos(100);
//		newPlayerPos.setMapAreaXPos(100);

		// newPlayerPos.movePositionOnMapArea(newMap, player, "e", 300);
		newPlayerPos.movePlayerOnMapArea(newMap, player, "e", 10);

		player.getGameObjectPos().getCurrentArea().printMapAreaCordsInfo();
		player.getGameObjectPos().printToString();
		newMap.printGameMapString();

//		Console.WriteLine(newPlayerPos.getPlayerAreaName(newMap.map));
//		Console.WriteLine(newPlayerPos.toString());
//		newMap.printGameMap();
//
//		newPlayerPos.changePlayerPos(newMap.map, -11, 0);
//		Console.WriteLine(newPlayerPos.getPlayerAreaName(newMap.map));
//		Console.WriteLine(newPlayerPos.toString());
//		newMap.printGameMap();
//		
//		//newPlayerPos.movePosition(newMap.map, "n");
//		Console.WriteLine(newPlayerPos.getPlayerAreaName(newMap.map));
//		Console.WriteLine(newPlayerPos.toString());
//		newMap.printGameMap();

	}

}

}

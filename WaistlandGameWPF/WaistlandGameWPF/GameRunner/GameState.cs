using System;


namespace WaistlandGameWPF
{
	/*
    package wasteland.gameRunner;

import java.io.Serializable;

using Wasteland.entity.Entity;
using Wasteland.map.GameObjectPos;
using Wasteland.map.Map;
*/
	/**
	 * GameState represents the current state of play, like the map, player location, and so on.
	 *
	 */
	[System.Serializable]
	public class GameState 
	{



		public String gameStateSaveName;

		private PlayerAction playerAction;
		private Map mainMap;
		private Entity player;

		private GameObjectPos playerPos;

		private String lastPosition;
		private String thisPosition;
		private bool isGameEnded;

		private bool didPlayerMoveThisTurn;


		private double timePassed;






		/**
		 * @return the gameStateSaveName
		 */
		public String GetGameStateSaveName()
		{
			return gameStateSaveName;
		}



		/**
		 * @param gameStateSaveName the gameStateSaveName to set
		 */
		public void SetGameStateSaveName(String gameStateSaveName)
		{
			this.gameStateSaveName = gameStateSaveName;
		}



		public PlayerAction GetPlayerAction()
		{
			return playerAction;
		}

		public Map GetMainMap()
		{
			return mainMap;
		}

		public Entity GetPlayer()
		{
			return player;
		}

		public GameObjectPos GetPlayerPos()
		{
			return playerPos;
		}
		public String GetLastPosition()
		{
			return lastPosition;
		}

		public String GetThisPosition()
		{
			return thisPosition;
		}
		public bool GetIsGameEnded()
		{
			return isGameEnded;
		}

		public bool GetDidPlayerMoveThisTurn()
		{
			return didPlayerMoveThisTurn;
		}


		public void SetPlayerAction(PlayerAction playerAction)
		{
			this.playerAction = playerAction;
		}

		public void SetMainMap(Map mainMap)
		{
			this.mainMap = mainMap;
		}

		public void SetPlayer(Entity player)
		{
			this.player = player;
		}

		public void SetPlayerPos(GameObjectPos playerPos)
		{
			this.playerPos = playerPos;
		}

		public void SetLastPosition(String lastPosition)
		{
			this.lastPosition = lastPosition;
		}

		public void SetThisPosition(String thisPosition)
		{
			this.thisPosition = thisPosition;
		}
		public void SetIsGameEnded(bool isGameEnded)
		{
			this.isGameEnded = isGameEnded;
		}

		public void SetDidPlayerMoveThisTurn(bool didPlayerMoveThisTurn)
		{
			this.didPlayerMoveThisTurn = didPlayerMoveThisTurn;
		}


		/**
		 * @return the timePassed
		 */
		public double GetTicksPassed()
		{
			return timePassed;
		}

		/**
		 * @param timePassed the timePassed to set
		 */
		public void SetTicksPassed(double timePassed)
		{
			this.timePassed = timePassed;
		}







		public GameState MakeBuild1() 
		{
			// create new command handler
			//commandHandler = CommandHandler.GetInstance();

			// create new game state
			GameState gameState = new GameState();


			// Set game state values
			gameState.SetPlayerAction(new PlayerAction());
			gameState.SetMainMap(new Map(25));

			int initMapX = 0;
			int initMapY = 0;
			int initMapAreaX = 0;
			int initMapAreaY = 0;
			gameState.GetMainMap().makeGameMap1();
			GameObjectPos startPos = new GameObjectPos(gameState.GetMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
			GameObjectPos startPos2 = new GameObjectPos(gameState.GetMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);


			//gameState.GetMainMap().makeMap1(gameState.GetMainMap());
			gameState.SetPlayerPos(startPos);





			gameState.SetPlayer(new Entity("Player", true, 100, 1.5, .1, gameState.GetPlayerPos()));
			//gameState.GetPlayer().GetGameObjectPos().SetGameObject(gameState.GetPlayer());
			gameState.GetPlayer().setObjectName("Player");
			gameState.GetPlayer().setEntityName("Player");
			gameState.GetPlayer().setStrength(25);

			Hitbox hitbox = new Hitbox();
			gameState.GetPlayer().setGameObjectHitbox(hitbox.newHumanHitbox());
			//ask player to enter the name of their character 

			gameState.GetPlayer().setIsThePlayer(true);
			gameState.GetMainMap().setGameMapPlayer(initMapX, initMapY, true);

			gameState.GetMainMap().printGameMapString();
			gameState.GetPlayer().getGameObjectPos().getCurrentArea().printMapAreaCordsInfo();
			//gameState.GetPlayer().GetGameObjectPos();


			//make a spear
			BaseItem spear = new BaseItem(startPos2, "Spear", 10);
			spear.setInInventory(false);
			spear.setPierce(20);
			spear.setSlash(5);
			gameState.GetMainMap().addGameObjectToMapList(spear);


			GameObjectPos startPos3 = new GameObjectPos(gameState.GetMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
			Magazine _9mm_mag = new Magazine(startPos3, "9mm mag", .95, 6, 9);
			_9mm_mag.setInInventory(false);

			Magazine _9mm_mag2 = new Magazine(startPos3, "9mm mag", .95, 6, 9);
			_9mm_mag2.setInInventory(false);


			for (int i = 0; i < 8; i++)
			{
				startPos3 = new GameObjectPos(gameState.GetMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
				ProjectileAmmo bullet = new ProjectileAmmo(startPos3, "9mm Federal FMJ:" + i, 0.00804, 9, 350);
				_9mm_mag.addBullet(bullet);

				bullet = new ProjectileAmmo(startPos3, "9mm Federal FMJ:" + i, 0.00804, 9, 350);
				_9mm_mag2.addBullet(bullet);
			}
			gameState.GetMainMap().addGameObjectToMapList(_9mm_mag);
			startPos3 = new GameObjectPos(gameState.GetMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
			Gun gun = new Gun(startPos3, "9mm pistol", 9, true, true);
			gun.setInInventory(false);
			gameState.GetMainMap().addGameObjectToMapList(gun);
			gun.setMagazine(_9mm_mag);
			gun.setAttackRange(50);


			gameState.GetPlayer().addObjectStringEvents("Started\n");
			//this = gameState;
			return gameState;
			//UnityGUI unityGUI = new UnityGUI(gameState);
		}


		public void MainGameLoop2022(GameState gameState) 
		{
			double seconds = 0;


			//gameState.GetPlayer().GetSecondsPassed()
			gameState.GetMainMap().runThroughEntityActions(gameState.GetMainMap(), gameState.GetPlayer(), seconds);

		}

		


	}

	
}




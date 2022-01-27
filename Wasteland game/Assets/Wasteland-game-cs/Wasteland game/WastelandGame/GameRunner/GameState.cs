using System;
using UnityEngine;
using UnityEngine.UI;

namespace Wasteland_game
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
	 * @author tyler
	 *
	 */
	[System.Serializable]
	public class GameState : MonoBehaviour
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

	}
}




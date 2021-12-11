using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wasteland_game.WastelandGame;

namespace Wasteland_game.WastelandGame.GameState
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
public class GameState {

	
	
	public String gameStateSaveName;
	
	private PlayerAction playerAction;
	private Map mainMap;
	private Entity player;

	private GameObjectPos playerPos;

	private String lastPosition;
	private String thisPosition;
	
	private bool isGameEnded;
	private bool didPlayerMoveThisTurn;
	
	private double ticksPassed;

	public GameState() {
		isGameEnded = false;
	}
	
	

	/**
	 * @return the gameStateSaveName
	 */
	public String getGameStateSaveName() {
		return gameStateSaveName;
	}



	/**
	 * @param gameStateSaveName the gameStateSaveName to set
	 */
	public void setGameStateSaveName(String gameStateSaveName) {
		this.gameStateSaveName = gameStateSaveName;
	}



	public PlayerAction getPlayerAction() {
		return playerAction;
	}

	public Map getMainMap() {
		return mainMap;
	}

	public Entity getPlayer() {
		return player;
	}

	public GameObjectPos getPlayerPos() {
		return playerPos;
	}

	public String getLastPosition() {
		return lastPosition;
	}

	public String getThisPosition() {
		return thisPosition;
	}
	
	public bool isGameEnded() {
		return isGameEnded;
	}
	
	public bool didPlayerMoveThisTurn() {
		return didPlayerMoveThisTurn;
	}

	public void setPlayerAction(PlayerAction playerAction) {
		this.playerAction = playerAction;
	}

	public void setMainMap(Map mainMap) {
		this.mainMap = mainMap;
	}

	public void setPlayer(Entity player) {
		this.player = player;
	}

	public void setPlayerPos(GameObjectPos playerPos) {
		this.playerPos = playerPos;
	}

	public void setLastPosition(String lastPosition) {
		this.lastPosition = lastPosition;
	}

	public void setThisPosition(String thisPosition) {
		this.thisPosition = thisPosition;
	}

	public void setIsGameEnded(bool isGameEnded) {
		this.isGameEnded = isGameEnded;
	}
	
	public void setDidPlayerMoveThisTurn(bool didPlayerMoveThisTurn) {
		this.didPlayerMoveThisTurn = didPlayerMoveThisTurn;
	}

	/**
	 * @return the ticksPassed
	 */
	public double getTicksPassed() {
		return ticksPassed;
	}

	/**
	 * @param ticksPassed the ticksPassed to set
	 */
	public void setTicksPassed(double ticksPassed) {
		this.ticksPassed = ticksPassed;
	}
	
	
}

}

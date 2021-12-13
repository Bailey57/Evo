using System;


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
	
	private double timePassed;

	public GameState() {
		this.isGameEnded = false;
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
	
	public bool getIsGameEnded() {
		return isGameEnded;
	}
	
	public bool getDidPlayerMoveThisTurn() {
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
	 * @return the timePassed
	 */
	public double getTicksPassed() {
		return timePassed;
	}

	/**
	 * @param timePassed the timePassed to set
	 */
	public void setTicksPassed(double timePassed) {
		this.timePassed = timePassed;
	}
	
	
}

}

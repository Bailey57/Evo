using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_game.WastelandGame.GameRunner
{
	/*
    package wasteland.gameRunner;

import java.io.Serializable;

import wasteland.entity.Entity;
import wasteland.map.GameObjectPos;
import wasteland.map.Map;
*/
/**
 * GameState represents the current state of play, like the map, player location, and so on.
 * 
 * @author tyler
 *
 */
public class GameState : Serializable {

	
	
	public String gameStateSaveName;
	
	private PlayerAction playerAction;
	private Map mainMap;
	private Entity player;

	private GameObjectPos playerPos;

	private String lastPosition;
	private String thisPosition;
	
	private boolean isGameEnded;
	private boolean didPlayerMoveThisTurn;
	
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
	
	public boolean isGameEnded() {
		return isGameEnded;
	}
	
	public boolean didPlayerMoveThisTurn() {
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

	public void setIsGameEnded(boolean isGameEnded) {
		this.isGameEnded = isGameEnded;
	}
	
	public void setDidPlayerMoveThisTurn(boolean didPlayerMoveThisTurn) {
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

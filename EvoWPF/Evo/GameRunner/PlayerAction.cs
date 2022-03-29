using System;


namespace Evo
{
	/*
    package wasteland.gameRunner;

import java.io.Serializable;
import java.util.Scanner;

using Wasteland.entity.Entity;
using Wasteland.map.GameObjectPos;
using Wasteland.map.Map;
using Wasteland.map.MapArea;
*/
	[System.Serializable]
	public class PlayerAction {
	
	
	
	public PlayerAction() {
		
	}
	
	public void chooseDirection(Map currentMap, Entity player) {
		//Scanner scn = new Scanner(System.in);
		//GameObjectPos GameObjectPos = new GameObjectPos();
		
		Console.WriteLine("Type what direction you want to go: N, S, E or W");
		Console.ReadLine();
		
		
		
		//player.movePosition(currentMap.map, player.GameObjectPos);
		
		//entity.GameObjectPos.movePosition(MapArea currentMap[][], String direction);
		
	}
	

	public void lookAround(Map currentMap, GameObjectPos pos) {
		
		//pos.setCurrMapArea(currentMap.getGameMap());
		pos.getCurrentArea().printMapAreaInfo();
		
		//printMapAreaInfo
		//currentMap.map
	}
	
	public void attackEntity() {
		
	}
	
	public void talkToEntity() {
		
	}
	

}

}

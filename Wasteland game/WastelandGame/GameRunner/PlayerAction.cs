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
import java.util.Scanner;

import wasteland.entity.Entity;
import wasteland.map.GameObjectPos;
import wasteland.map.Map;
import wasteland.map.MapArea;
*/
public class PlayerAction : Serializable {
	
	
	
	public PlayerAction() {
		
	}
	
	public void chooseDirection(Map currentMap, Entity player) {
		//Scanner scn = new Scanner(System.in);
		//GameObjectPos GameObjectPos = new GameObjectPos();
		
		Console.Writeln("Type what direction you want to go: N, S, E or W");
		scn.next();
		
		
		
		//player.movePosition(currentMap.map, player.GameObjectPos);
		
		//entity.GameObjectPos.movePosition(MapArea currentMap[][], String direction);
		
	}
	
	public void lookAround(Map currentMap, GameObjectPos pos) {
		
		pos.setCurrMapArea(currentMap.gameMap);
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

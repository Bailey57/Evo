using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_game
{
	/*
    package wasteland.gameRunner;
using Wasteland.saveAndLoad.*;
import java.io.Serializable;
import java.util.Scanner;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
using Wasteland.entity.Entity;
using Wasteland.entity.Hitbox;
using Wasteland.gui.GameGUI;
using Wasteland.items.BaseItem;
using Wasteland.items.ProjectileAmmo;
using Wasteland.items.weapons.Gun;
using Wasteland.items.weapons.Magazine;
using Wasteland.map.GameObjectPos;
using Wasteland.map.Map;
*/
/**
 * 
 * 
 * @author bailey
 *
 */
public class GameRunner {

	/**
	 * 
	 */
	//private static final long serialVersionUID = 1L;

	// command handler
	private static CommandHandler commandHandler;

	// game state
	private static GameState gameState;

	/**
	 * private no-args constructor for GameRunner This way, no instance of
	 * GameRunner can ever be created or used by another class
	 */
	public GameRunner() {
	}

	/**
	 * Get an instance of the GameRunner, create a new one if not created already
	 * 
	 * @return the GameRunner instance
	 */
	public static void init() {

		// create new command handler
		commandHandler = CommandHandler.getInstance();

		// create new game state
		gameState = new GameState();
			

		// set game state values
		gameState.setPlayerAction(new PlayerAction());
		gameState.setMainMap(new Map(25));

		int initMapX = 0; 
		int initMapY = 0;
		int initMapAreaX = 0; 
		int initMapAreaY = 0;
		gameState.getMainMap().makeGameMap1();
		GameObjectPos startPos = new GameObjectPos(gameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
		GameObjectPos startPos2 = new GameObjectPos(gameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
		
		
		//gameState.getMainMap().makeMap1(gameState.getMainMap());
		gameState.setPlayerPos(startPos);
		

		gameState.setLastPosition("");
		gameState.setThisPosition("");

		
		
		gameState.setPlayer(new Entity("Player", true, 100, 1.5, .1, gameState.getPlayerPos()));
		//gameState.getPlayer().getGameObjectPos().setGameObject(gameState.getPlayer());
		gameState.getPlayer().setObjectName("Player");
		gameState.getPlayer().setEntityName("Player");
		gameState.getPlayer().setStrength(25);
		
		Hitbox hitbox = new Hitbox();
		gameState.getPlayer().setGameObjectHitbox(hitbox.newHumanHitbox());
		//ask player to enter the name of their character 

		gameState.getPlayer().setIsThePlayer(true);
		gameState.getMainMap().setGameMapPlayer(initMapX, initMapY, true);

		gameState.getMainMap().printGameMapString();
		gameState.getPlayer().getGameObjectPos().getCurrentArea().printMapAreaCordsInfo();
		//gameState.getPlayer().getGameObjectPos();
		
		
		//make a spear
		BaseItem spear = new BaseItem(startPos2, "Spear", 10);
		spear.setInInventory(false);
		spear.setPierce(20);
		spear.setSlash(5);
		gameState.getMainMap().addGameObjectToMapList(spear);
		
		
		GameObjectPos startPos3 = new GameObjectPos(gameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
		Magazine _9mm_mag = new Magazine(startPos3, "9mm mag", .95, 6, 9);
		_9mm_mag.setInInventory(false);
		
		Magazine _9mm_mag2 = new Magazine(startPos3, "9mm mag", .95, 6, 9);
		_9mm_mag2.setInInventory(false);
		
		
		for (int i = 0; i < 8; i ++) {
			startPos3 = new GameObjectPos(gameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
			ProjectileAmmo bullet = new ProjectileAmmo(startPos3, "9mm Federal FMJ:" + i, 0.00804, 9, 350);
			_9mm_mag.addBullet(bullet);
			
			bullet = new ProjectileAmmo(startPos3, "9mm Federal FMJ:" + i, 0.00804, 9, 350);
			_9mm_mag2.addBullet(bullet);
		}
		gameState.getMainMap().addGameObjectToMapList(_9mm_mag);
		startPos3 = new GameObjectPos(gameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
		Gun gun = new Gun(startPos3, "9mm pistol", 9, true, true);
		gun.setInInventory(false);
		gameState.getMainMap().addGameObjectToMapList(gun);
		gun.setMagazine(_9mm_mag);
		gun.setAttackRange(50);


		//UnityGUI unityGUI = new UnityGUI(gameState);
	}
	
	


	/**
	 * initiate the main loop of the game
	 */
	public static void mainLoop() {

		// initial help message
		Console.WriteLine("enter \'h\' for a list of commands");

		// game loop, loop until the game ends
		while (!gameState.getIsGameEnded()) {
			
			
			
			

			// handle command using the command handler
			commandHandler = new CommandHandler(gameState);
			
			
			
			
			gameState = commandHandler.handleConsoleCommand(gameState);
			commandHandler.setGameState(gameState);
			
			double seconds = 0;
			//gameState.getPlayer().getSecondsPassed()
			gameState.getMainMap().runThroughEntityActions(gameState.getMainMap(), gameState.getPlayer(), seconds);
			
			  
			
		}

	}

	/**
	 * Main method, start of execution
	 * 
	 * @param args command line arguments
	 */
	public static void main(String[] args) {
		
		//GameGUI.main(args);
		
		
	
		
		//@SuppressWarnings("resource")
		//Scanner scn = new Scanner(System.in);
		bool mainMenuRunning = true;
		String input = "";
		Console.WriteLine("Note: Loading a game file takes roughly 38 seconds\n");
		
		while (mainMenuRunning) {
			Console.WriteLine("Type 0 to start new game.");
			Console.WriteLine("Type 1 to load from a save file.");
			input = Console.ReadLine();
			if (input.Equals("0")) {
				
				
				init();
				mainMenuRunning = false;
				break;
				
			} else if (input.Equals("1")) {
				//code to load file in
				String fileName = "";
				//Files files = new Files();
				Console.WriteLine("Enter file directory and name");
				fileName = Console.ReadLine();
				
				//commandHandler = CommandHandler.getInstance();
				//gameState = files.loadGame(fileName);
				
				if (gameState.getMainMap() != null && gameState.getPlayer() != null) {
					mainMenuRunning = false;
					break;
				}
				
			}
			Console.WriteLine("Incorrect input");
			
			
		}
		
		
		
		
		

		mainLoop();
		
		

		
		
	}

	/**
	 * return the current game state
	 * 
	 * @return the current game state
	 */
	public GameState getGameState() {
		return gameState;
	}
	
	/**
	 * set the new game state
	 * @param newGameState the new game state
	 */
	public void setGameState(GameState newGameState) {
		gameState = newGameState;
	}

	/**
	 * @return the commandHandler
	 */
	public static CommandHandler getCommandHandler() {
		return commandHandler;
	}

	/**
	 * @param commandHandler the commandHandler to set
	 */
	public static void setCommandHandler(CommandHandler commandHandler) {
		GameRunner.commandHandler = commandHandler;
	}
	
	
}

}

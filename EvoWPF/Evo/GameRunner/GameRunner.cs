using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaistlandGameWPF
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
		commandHandler = CommandHandler.GetInstance();

		// create new game state
		gameState = new GameState();
			

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
		
		
		for (int i = 0; i < 8; i ++) {
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


		//UnityGUI unityGUI = new UnityGUI(gameState);
	}
	
	


	/**
	 * initiate the main loop of the game
	 */
	public static void mainLoop() {

		// initial help message
		Console.WriteLine("enter \'h\' for a list of commands");

		// game loop, loop until the game ends
		while (!gameState.GetIsGameEnded()) {
			
			
			
			

			// handle command using the command handler
			commandHandler = new CommandHandler(gameState);
			
			
			
			
			gameState = commandHandler.handleConsoleCommand(gameState);
			commandHandler.SetGameState(gameState);
			
			double seconds = 0;
			//gameState.GetPlayer().GetSecondsPassed()
			gameState.GetMainMap().runThroughEntityActions(gameState.GetMainMap(), gameState.GetPlayer(), seconds);
			
			  
			
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
				
				//commandHandler = CommandHandler.GetInstance();
				//gameState = files.loadGame(fileName);
				
				if (gameState.GetMainMap() != null && gameState.GetPlayer() != null) {
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
	public GameState GetGameState() {
		return gameState;
	}
	
	/**
	 * Set the new game state
	 * @param newGameState the new game state
	 */
	public void SetGameState(GameState newGameState) {
		gameState = newGameState;
	}

	/**
	 * @return the commandHandler
	 */
	public static CommandHandler GetCommandHandler() {
		return commandHandler;
	}

	/**
	 * @param commandHandler the commandHandler to Set
	 */
	public static void SetCommandHandler(CommandHandler commandHandler) {
		GameRunner.commandHandler = commandHandler;
	}
	
	
}

}

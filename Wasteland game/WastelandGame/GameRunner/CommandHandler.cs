using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_game.WastelandGame.GameRunner
{
	/*
    package wasteland.gameRunner;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

using Wasteland.saveAndLoad.Files;
*/
/**
 * Handler class for running user commands
 * 
 * @author tyler
 *
 */
public class CommandHandler {

	// private instance for singleton design pattern
	private static CommandHandler instance;

	// scanner for user input
	private Scanner scn;

	private Files fileManager;

	private String gameOutput;

	// ammount of seconds players move takes
	private double seconds;

	public GameState gameState;

	/**
	 * @return the gameOutpu
	 */
	public String getGameOutput() {
		return gameOutput;
	}

	/**
	 * @return the gameState
	 */
	public GameState getGameState() {
		return gameState;
	}

	/**
	 * @param gameState the gameState to set
	 */
	public void setGameState(GameState gameState) {
		this.gameState = gameState;
	}

	/**
	 * @param gameOutpu the gameOutpu to set
	 */
	public void setGameOutput(String gameOutput) {
		this.gameOutput = gameOutput;
	}

	public String popGameOutput() {
		String stringOutput = this.gameOutput;
		this.gameOutput = "";

		return stringOutput;
	}

	public CommandHandler() {

		//scn = new Scanner(System.in);
		fileManager = new Files();
	}

	/**
	 * private constructor
	 */
	public CommandHandler(GameState gammeState) {
		this.gameState = gammeState;

		//scn = new Scanner(System.in);
		fileManager = new Files();
	}

	// doesnt work for some reason
	public bool isDouble(String output) {
		if (output == null) {
			return false;
		}

		try {
			Double.parseDouble(output);
			return true;
		} catch (NumberFormatException ex) {
			return false;
		}
	}

	/**
	 * Get an instance of the CommandHandler
	 * 
	 * @return an instance of the command handler
	 */
	public static CommandHandler getInstance() {

		// create a new instance if not created already
		if (instance == null) {
			instance = new CommandHandler();
		}

		// return the instance
		return instance;
	}

	public void saveGame(GameState gameState) {
		String input = scn.nextLine().toLowerCase();
		Console.Writeln("Enter name of the file: ");
		input = scn.nextLine();

		fileManager.saveGameAs(input, gameState);

		Console.Writeln("Game saved");

	}

	public void printEntityList(GameState gameState) {
		Console.Writeln(gameState.getMainMap().gameObjectsOnMapToString());

	}

	public String helpCommand() {
		String helpCommand = "";
		helpCommand += "\nGeneral coammnds: \n";
		helpCommand += String.format("%-20s %s%n", "h/help", "opens the help prompt");
		helpCommand += String.format("%-20s %s%n", "save game",
				"saves the game and asks for file directory and file name");
		// add load command
		helpCommand += String.format("%-20s %s%n", "exit/end game", "exits the game");

		helpCommand += String.format("\nMovement/Map commands: ");
		helpCommand += String.format("%-20s %s%n", "m/move (n,e,s,w)", "move the player in a cardinal direction");
		helpCommand += String.format("%-20s %s%n", "pm/print map", "prints out the game map");
		helpCommand += String.format("%-20s %s%n", "l/look", "look around");
		helpCommand += String.format("%-20s %s%n", "w/wait",
				"player waits for x ammount of time, cant be used in combat");

		helpCommand += String.format("\nCombat commands: ");
		helpCommand += String.format("%-20s %s%n", "wic/wait in combat", "same as wait but can be used in combat");
		helpCommand += String.format("%-20s %s%n", "a/attack",
				"gives list of things you can attack and you choose one");

		helpCommand += String.format("\nItems/Inventory commands: ");
		helpCommand += String.format("%-20s %s%n", "i/inventory",
				"shows your inventory and equipped weapon if you have one");
		helpCommand += String.format("%-20s %s%n", "pui/pick up item",
				"gives a list of items you can pick up if any around you");
		helpCommand += String.format("%-20s %s%n", "di/drop item", "drops the selected item");
		helpCommand += String.format("%-20s %s%n", "ew/equip weapon",
				"choose an item in inventory to equip as a weapon");

		helpCommand += String.format("\nDebugging/misc commands: ");
		helpCommand += String.format("%-20s %s%n", "pel/print entity list", "prints list of all entities on map");

		return helpCommand;
	}

//	public String attackCommand() {
//
//		// ex:
//		// 1: Zombie
//		// 2: Human
//
//		if (gameState.getPlayer().entitiesInSightList(gameState.getMainMap())[0] != null) {
//			Console.Writeln("Attack what enemy? ");
//			Console.Writeln(gameState.getPlayer().entitiesInSightListToString(gameState.getMainMap()));
//			bool done = false;
//			while (!done) {
//
//				Console.Writeln("Type number you want to attack.");
//				input = scn.nextLine();
//
//				if (input != null && Integer.parseInt(input) >= 0 && Integer.parseInt(input) < 999000) {
//
//					if (gameState.getPlayer().entitiesInSightList(gameState.getMainMap())[Integer
//							.parseInt(input)] != null) {
//						gameState.getPlayer()
//								.attackEntity(
//										gameState.getMainMap(), gameState.getPlayer()
//												.entitiesInSightList(gameState.getMainMap())[Integer.parseInt(input)],
//										0, true);
//						done = true;
//					} else {
//						Console.Writeln("Invalid input or entity doesnt exist.");
//					}
//
//				} else {
//					Console.Writeln("Invalid input, must be a number listed.");
//				}
//
//			}
//
//			
//
//		} else {
//			Console.Writeln("Nothing in sight to attack.");
//		}
//
//		return "";
//	}

	/**
	 * Handle a user command
	 * 
	 * @param gameState the current state of the game
	 * @return an updated game state after the command is handled
	 */
	public GameState handleConsoleCommand(GameState gameState) {
		// GameState gameState = gameRunner.getGameState();
		setSeconds(0);
		// enter command prompt
		Console.Write(">");
		setGameOutput(">");

		// get user input
		String input = scn.nextLine().toLowerCase();

		// help command
		if (input.equals("h") || input.equals("help")) {
			printHelpCommand();

		} else if (input.equals("save game") || input.equals("sg")) {
			saveGame(gameState);
		}

		else if (input.equals("print entity list") || input.equals("pel")) {

			printEntityList(gameState);

		}

		else if (input.equals("attack") || input.equals("a")) {

			// ex:
			// 1: Zombie
			// 2: Human

			if (gameState.getPlayer().entitiesInSightList(gameState.getMainMap())[0] != null) {
				Console.Writeln("Attack what enemy? ");
				Console.Writeln(gameState.getPlayer().entitiesInSightListToString(gameState.getMainMap()));
				bool done = false;
				while (!done) {

					Console.Writeln("Type number you want to attack.");
					input = scn.nextLine();

					if (input != null && Integer.parseInt(input) >= 0 && Integer.parseInt(input) < 999000) {

						if (gameState.getPlayer().entitiesInSightList(gameState.getMainMap())[Integer
								.parseInt(input)] != null) {
							gameState.getPlayer()
									.attackEntity(gameState.getMainMap(), gameState.getPlayer()
											.entitiesInSightList(gameState.getMainMap())[Integer.parseInt(input)], 0,
											true);
							done = true;
						} else {
							Console.Writeln("Invalid input or entity doesnt exist.");
						}

					} else {
						Console.Writeln("Invalid input, must be a number listed.");
					}

				}

				setSeconds(2);

			} else {
				Console.Writeln("Nothing in sight to attack.");
			}

		} else if (input.equals("pick up item") || input.equals("pui")) {
			// put code here

			if (gameState.getPlayer().itemsInSightList(gameState.getMainMap())[0] != null) {
				Console.Writeln("Pick up what item? ");

				Console.Writeln(gameState.getPlayer().itemsInSightListToString(gameState.getMainMap()));

				bool done = false;
				while (!done) {

					Console.Writeln("Type number you want to pick up. Type c to cancel.");
					input = scn.nextLine();
					if (input.equals("C") || input.equals("c")) {
						done = true;
						break;
					}

					// add checks to make sure its an int

					if (isDouble(input) && Integer.parseInt(input) >= 0 && Integer.parseInt(input) < 999000) {

						if (gameState.getPlayer().itemsInSightList(gameState.getMainMap())[Integer
								.parseInt(input)] != null) {

//							gameState.getPlayer().addItemToInventory(gameState.getPlayer()
//									.itemsInSightList(gameState.getMainMap())[Integer.parseInt(input)]);

							gameState.getPlayer().pickUpItemOffOfGround(gameState.getPlayer()
									.itemsInSightList(gameState.getMainMap())[Integer.parseInt(input)]);

							done = true;
						} else {
							Console.Writeln("Invalid input or item doesnt exist.");
						}

					} else {
						Console.Writeln("Invalid input, must be a number listed.");
					}

				}

			} else {
				Console.Writeln("No items in sight.");

			}

		} else if (input.equals("drop item") || input.equals("di")) {
			Console.Writeln("Drop what item? Type c to cancel.");

			bool done = false;
			Console.Writeln(gameState.getPlayer().showInventory());

			while (!done) {
				input = scn.nextLine();
				if (input.equals("C") || input.equals("c")) {
					done = true;
					break;
				}

				gameState.getPlayer().dropItem(gameState.getPlayer().getInventory()[Integer.parseInt(input)]);
				done = true;

			}
		}

		else if (input.equals("equip weapon") || input.equals("ew")) {

			if (gameState.getPlayer().inventory[0] == null) {

				Console.Writeln("\nNothing in inventory");
			} else {

				Console.Writeln(gameState.getPlayer().showInventory());

				Console.Writeln("Type number you want to equip. Type stop to exit comand.");
				input = scn.nextLine();
				if (input.equals("stop")) {

				} else {

					gameState.getPlayer().equipItemAsWeapon(gameState.getPlayer().inventory[Integer.parseInt(input)]);
				}

			}

			// gameState.getPlayer().getInventoryList();

		} else if (input.equals("invintory") || input.equals("i")) {

			// gameState.getPlayer().getInventoryList();
			if (gameState.getPlayer().inventory == null) {

				Console.Writeln("\nNothing in inventory");
			} else {
				if (gameState.getPlayer().entityWeapon != null) {
					Console.Writeln("Equipped weapon: " + gameState.getPlayer().entityWeapon.getObjectName());
				}

				Console.Writeln("Inventory: \n" + gameState.getPlayer().showInventory());
			}

		}

		else if (input.equals("w") || input.equals("wait")) {

			/*
			 * maybe move wait method to CommandHandler or choose to deal with time in
			 * CommandHandler only or make field in entity that keeps track of time passed
			 * after performing an action
			 */
			if (gameState.getPlayer().inCombat) {

				Console.Writeln("Cant wait while in combat.");

			} else {
				Console.Writeln("Wait for how many minuets? ");
				input = scn.nextLine();
				gameState.getPlayer().playerWait(gameState.getMainMap(), gameState.getPlayer(),
						Double.parseDouble(input));
			}

			// seconds = Double.parseDouble(input);

		} else if (input.equals("wic") || input.equals("wait in combat")) {

			Console.Writeln("Wait for how many minuets? ");
			input = scn.nextLine();

			gameState.getPlayer().playerWait(gameState.getMainMap(), gameState.getPlayer(), Double.parseDouble(input));

		}

		// look command
		else if (input.equals("l") || (input.equals("look"))) {

			gameState.getPlayerAction().lookAround(gameState.getMainMap(), gameState.getPlayerPos());

			// gameState.getPlayer().getGameObjectPos().getCurrentArea().printMapAreaCordsInfo();
			gameState.getPlayer().getGameObjectPos().printToString();
			// get Items in sight
			// gameState.getPlayer().getGame

		}

		// move command
		else if (input.equals("m") || input.startsWith("move")) {

			// get the command as a list of strings separated by spaces
			ArrayList<String> list = new ArrayList<String>(Arrays.asList(input.split(" ")));

			// if the user just typed m or move, then ask what direction they want to go
			if (list.size() == 1) {
				String directionPlayerMoves = "e";
				String directionPlayerDistance = "0";

				bool correctInput = false;

				while (!correctInput) {

					Console.Writeln("Type what direction you want to go: N, S, E or W");

					directionPlayerMoves = scn.nextLine().toLowerCase();

					Console.Writeln("Type how many minutes you want to travel: ");

					directionPlayerDistance = scn.nextLine();

					if (directionPlayerMoves.equals("n") || directionPlayerMoves.equals("s")
							|| directionPlayerMoves.equals("e")
							|| directionPlayerMoves.equals("w") && isDouble(directionPlayerDistance)) {

						correctInput = true;

					} else {
						Console.Writeln("\nInvalid input\n");
					}

				}

				gameState = handleMoveCommand(gameState, directionPlayerMoves,
						Double.parseDouble(directionPlayerDistance));
				// gameState = handleMoveCommand(gameState, directionPlayerMoves,
				// Integer.parseInt(directionPlayerDistance));
			}

			// if the user entered their command on one line, get the direction from the
			// second word in the command
			else {
				gameState = handleMoveCommand(gameState, list.get(1), 0);
			}
		}

		else if (input.equals("print map") || input.equals("pm")) {
			gameState.getMainMap().printGameMapString();
		}

		// exit command
		else if (input.equals("exit") || input.equals("end game")) {

			// tell the player and the game that the game is ending
			Console.Writeln("Game ended");
			gameState.setIsGameEnded(true);

			// close the scanner
			scn.close();
		}

		// invalid command case
		else {
			Console.Writeln("invalid command");
		}

		// Console.Writeln(popGameOutput());

		return gameState;
	}

	/**
	 * Print the help command
	 */
	private void printHelpCommand() {
		Console.Writeln("\nGeneral coammnds: ");
		Console.Writef("%-20s %s%n", "h/help", "opens the help prompt");
		Console.Writef("%-20s %s%n", "save game", "saves the game and asks for file directory and file name");
		// add load command
		Console.Writef("%-20s %s%n", "exit/end game", "exits the game");

		Console.Writeln("\nMovement/Map commands: ");
		Console.Writef("%-20s %s%n", "m/move (n,e,s,w)", "move the player in a cardinal direction");
		Console.Writef("%-20s %s%n", "pm/print map", "prints out the game map");
		Console.Writef("%-20s %s%n", "l/look", "look around");
		Console.Writef("%-20s %s%n", "w/wait", "player waits for x ammount of time, cant be used in combat");

		Console.Writeln("\nCombat commands: ");
		Console.Writef("%-20s %s%n", "wic/wait in combat", "same as wait but can be used in combat");
		Console.Writef("%-20s %s%n", "a/attack", "gives list of things you can attack and you choose one");

		Console.Writeln("\nItems/Inventory commands: ");
		Console.Writef("%-20s %s%n", "i/inventory", "shows your inventory and equipped weapon if you have one");
		Console.Writef("%-20s %s%n", "pui/pick up item", "gives a list of items you can pick up if any around you");
		Console.Writef("%-20s %s%n", "di/drop item", "drops the selected item");
		Console.Writef("%-20s %s%n", "ew/equip weapon", "choose an item in inventory to equip as a weapon");

		Console.Writeln("\nDebugging/misc commands: ");
		Console.Writef("%-20s %s%n", "pel/print entity list", "prints list of all entities on map");

	}

	/**
	 * Handle the move command by moving the player
	 */
	private GameState handleMoveCommand(GameState gameState, String direction, double minutesWalking) {
		gameState.setLastPosition(gameState.getPlayerPos().toString());
		// gameState.getPlayer().GameObjectPos.movePosition(gameState.getMainMap().map,
		// direction);
		gameState.getPlayer().gameObjectPos.movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(),
				direction, minutesWalking);

		gameState.setThisPosition(gameState.getPlayerPos().toString());

		if (!gameState.getLastPosition().equals(gameState.getThisPosition())) {
			gameState.setDidPlayerMoveThisTurn(true);
			gameState.getMainMap().printGameMapString();
		}

		return gameState;
	}

	public double getSeconds() {
		return seconds;
	}

	public void setSeconds(double seconds) {
		this.seconds = seconds;
	}
}

}

using System;
using System.Collections;

namespace WaistlandGameWPF
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
	//private Scanner scn;

	//private Files fileManager;

	private String gameOutput;

	// ammount of seconds players move takes
	private double seconds;

	public GameState gameState;

	/**
	 * @return the gameOutpu
	 */
	public String GetGameOutput() {
		return gameOutput;
	}

	/**
	 * @return the gameState
	 */
	public GameState GetGameState() {
		return gameState;
	}

	/**
	 * @param gameState the gameState to Set
	 */
	public void SetGameState(GameState gameState) {
		this.gameState = gameState;
	}

	/**
	 * @param gameOutpu the gameOutpu to Set
	 */
	public void SetGameOutput(String gameOutput) {
		this.gameOutput = gameOutput;
	}

	public String popGameOutput() {
		String stringOutput = this.gameOutput;
		this.gameOutput = "";

		return stringOutput;
	}

	public CommandHandler() {

		//scn = new Scanner(System.in);
		//fileManager = new Files();
	}

	/**
	 * private constructor
	 */
	public CommandHandler(GameState gammeState) {
		this.gameState = gammeState;

		//scn = new Scanner(System.in);
		//fileManager = new Files();
	}

	// doesnt work for some reason
	public bool isDouble(String output) {
		if (output == null) {
			return false;
		}

		//try {
			Double.Parse(output);
			return true;
		//} //catch (NumberFormatException ex) {
			//return false;
		//}
	}

	/**
	 * Get an instance of the CommandHandler
	 * 
	 * @return an instance of the command handler
	 */
	public static CommandHandler GetInstance() {

		// create a new instance if not created already
		if (instance == null) {
			instance = new CommandHandler();
		}

		// return the instance
		return instance;
	}

	/*
	public void saveGame(GameState gameState) {
		String input = scn.nextLine().toLowerCase();
		Console.WriteLine("Enter name of the file: ");
		input = scn.nextLine();

		fileManager.saveGameAs(input, gameState);

		Console.WriteLine("Game saved");

	}
	*/
	public void printEntityList(GameState gameState) {
		Console.WriteLine(gameState.GetMainMap().gameObjectsOnMapToString());

	}

	public String helpCommand() {
		String helpCommand = "";
		helpCommand += "\nGeneral coammnds: \n";
		helpCommand += String.Format("%-20s %s%n", "h/help", "opens the help prompt");
		helpCommand += String.Format("%-20s %s%n", "save game",
				"saves the game and asks for file directory and file name");
		// add load command
		helpCommand += String.Format("%-20s %s%n", "exit/end game", "exits the game");

		helpCommand += String.Format("\nMovement/Map commands: ");
		helpCommand += String.Format("%-20s %s%n", "m/move (n,e,s,w)", "move the player in a cardinal direction");
		helpCommand += String.Format("%-20s %s%n", "pm/print map", "prints out the game map");
		helpCommand += String.Format("%-20s %s%n", "l/look", "look around");
		helpCommand += String.Format("%-20s %s%n", "w/wait",
				"player waits for x ammount of time, cant be used in combat");

		helpCommand += String.Format("\nCombat commands: ");
		helpCommand += String.Format("%-20s %s%n", "wic/wait in combat", "same as wait but can be used in combat");
		helpCommand += String.Format("%-20s %s%n", "a/attack",
				"gives list of things you can attack and you choose one");

		helpCommand += String.Format("\nItems/Inventory commands: ");
		helpCommand += String.Format("%-20s %s%n", "i/inventory",
				"shows your inventory and equipped weapon if you have one");
		helpCommand += String.Format("%-20s %s%n", "pui/pick up item",
				"gives a list of items you can pick up if any around you");
		helpCommand += String.Format("%-20s %s%n", "di/drop item", "drops the selected item");
		helpCommand += String.Format("%-20s %s%n", "ew/equip weapon",
				"choose an item in inventory to equip as a weapon");

		helpCommand += String.Format("\nDebugging/misc commands: ");
		helpCommand += String.Format("%-20s %s%n", "pel/print entity list", "prints list of all entities on map");

		return helpCommand;
	}

//	public String attackCommand() {
//
//		// ex:
//		// 1: Zombie
//		// 2: Human
//
//		if (gameState.GetPlayer().entitiesInSightList(gameState.GetMainMap())[0] != null) {
//			Console.WriteLine("Attack what enemy? ");
//			Console.WriteLine(gameState.GetPlayer().entitiesInSightListToString(gameState.GetMainMap()));
//			bool done = false;
//			while (!done) {
//
//				Console.WriteLine("Type number you want to attack.");
//				input = scn.nextLine();
//
//				if (input != null && int.Parse(input) >= 0 && int.Parse(input) < 999000) {
//
//					if (gameState.GetPlayer().entitiesInSightList(gameState.GetMainMap())[Integer
//							.parseInt(input)] != null) {
//						gameState.GetPlayer()
//								.attackEntity(
//										gameState.GetMainMap(), gameState.GetPlayer()
//												.entitiesInSightList(gameState.GetMainMap())[int.Parse(input)],
//										0, true);
//						done = true;
//					} else {
//						Console.WriteLine("Invalid input or entity doesnt exist.");
//					}
//
//				} else {
//					Console.WriteLine("Invalid input, must be a number listed.");
//				}
//
//			}
//
//			
//
//		} else {
//			Console.WriteLine("Nothing in sight to attack.");
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
		// GameState gameState = gameRunner.GetGameState();
		SetSeconds(0);
		// enter command prompt
		Console.Write(">");
		SetGameOutput(">");

		// Get user input
		//String input = Console.ReadLine().ToLower();
			String input = Console.ReadLine();
			//String input = scn.nextLine().toLowerCase();

			// help command
			if (input.Equals("h") || input.Equals("help")) {
			printHelpCommand();

		} else if (input.Equals("save game") || input.Equals("sg")) {
			//saveGame(gameState);
		}

		else if (input.Equals("print entity list") || input.Equals("pel")) {

			printEntityList(gameState);

		}

		else if (input.Equals("attack") || input.Equals("a")) {

			// ex:
			// 1: Zombie
			// 2: Human

			if (gameState.GetPlayer().entitiesInSightList(gameState.GetMainMap())[0] != null) {
				Console.WriteLine("Attack what enemy? ");
				Console.WriteLine(gameState.GetPlayer().entitiesInSightListToString(gameState.GetMainMap()));
				bool done = false;
				while (!done) {

					Console.WriteLine("Type number you want to attack.");
					input = Console.ReadLine();

					if (input != null && int.Parse(input) >= 0 && int.Parse(input) < 999000) {

						if (gameState.GetPlayer().entitiesInSightList(gameState.GetMainMap())[int.Parse(input)] != null) {
							gameState.GetPlayer()
									.attackEntity(gameState.GetMainMap(), gameState.GetPlayer()
											.entitiesInSightList(gameState.GetMainMap())[int.Parse(input)], 0,
											true);
							done = true;
						} else {
							Console.WriteLine("Invalid input or entity doesnt exist.");
						}

					} else {
						Console.WriteLine("Invalid input, must be a number listed.");
					}

				}

				SetSeconds(2);

			} else {
				Console.WriteLine("Nothing in sight to attack.");
			}

		} else if (input.Equals("pick up item") || input.Equals("pui")) {
			// put code here

			if (gameState.GetPlayer().itemsInSightList(gameState.GetMainMap())[0] != null) {
				Console.WriteLine("Pick up what item? ");

				Console.WriteLine(gameState.GetPlayer().itemsInSightListToString(gameState.GetMainMap()));

				bool done = false;
				while (!done) {

					Console.WriteLine("Type number you want to pick up. Type c to cancel.");
					input = Console.ReadLine();
					if (input.Equals("C") || input.Equals("c")) {
						done = true;
						break;
					}

					// add checks to make sure its an int

					if (isDouble(input) && int.Parse(input) >= 0 && int.Parse(input) < 999000) {

						if (gameState.GetPlayer().itemsInSightList(gameState.GetMainMap())[int.Parse(input)] != null) {

//							gameState.GetPlayer().addItemToInventory(gameState.GetPlayer()
//									.itemsInSightList(gameState.GetMainMap())[int.Parse(input)]);

							gameState.GetPlayer().pickUpItemOffOfGround(gameState.GetPlayer()
									.itemsInSightList(gameState.GetMainMap())[int.Parse(input)]);

							done = true;
						} else {
							Console.WriteLine("Invalid input or item doesnt exist.");
						}

					} else {
						Console.WriteLine("Invalid input, must be a number listed.");
					}

				}

			} else {
				Console.WriteLine("No items in sight.");

			}

		} else if (input.Equals("drop item") || input.Equals("di")) {
			Console.WriteLine("Drop what item? Type c to cancel.");

			bool done = false;
			Console.WriteLine(gameState.GetPlayer().showInventory());

			while (!done) {
					input = Console.ReadLine();
				if (input.Equals("C") || input.Equals("c")) {
					done = true;
					break;
				}

				gameState.GetPlayer().dropItem(gameState.GetPlayer().getInventory()[int.Parse(input)]);
				done = true;

			}
		}

		else if (input.Equals("equip weapon") || input.Equals("ew")) {

			if (gameState.GetPlayer().getInventory()[0] == null) {

				Console.WriteLine("\nNothing in inventory");
			} else {

				Console.WriteLine(gameState.GetPlayer().showInventory());

				Console.WriteLine("Type number you want to equip. Type stop to exit comand.");
					input = Console.ReadLine();
				if (input.Equals("stop")) {

				} else {

					gameState.GetPlayer().equipItemAsWeapon(gameState.GetPlayer().getInventory()[int.Parse(input)]);
				}

			}

			// gameState.GetPlayer().GetInventoryList();

		} else if (input.Equals("invintory") || input.Equals("i")) {

			// gameState.GetPlayer().GetInventoryList();
			if (gameState.GetPlayer().getInventory() == null) {

				Console.WriteLine("\nNothing in inventory");
			} else {
				if (gameState.GetPlayer().entityWeapon != null) {
					Console.WriteLine("Equipped weapon: " + gameState.GetPlayer().entityWeapon.getObjectName());
				}

				Console.WriteLine("Inventory: \n" + gameState.GetPlayer().showInventory());
			}

		}

		else if (input.Equals("w") || input.Equals("wait")) {

			/*
			 * maybe move wait method to CommandHandler or choose to deal with time in
			 * CommandHandler only or make field in entity that keeps track of time passed
			 * after performing an action
			 */
			if (gameState.GetPlayer().inCombat) {

				Console.WriteLine("Cant wait while in combat.");

			} else {
				Console.WriteLine("Wait for how many minuets? ");
				input = Console.ReadLine();
				gameState.GetPlayer().playerWait(gameState.GetMainMap(), gameState.GetPlayer(),
						Double.Parse(input));
			}

			// seconds = Double.Parse(input);

		} else if (input.Equals("wic") || input.Equals("wait in combat")) {

			Console.WriteLine("Wait for how many minuets? ");
			input = Console.ReadLine();

			gameState.GetPlayer().playerWait(gameState.GetMainMap(), gameState.GetPlayer(), Double.Parse(input));

		}

		// look command
		else if (input.Equals("l") || (input.Equals("look"))) {

			gameState.GetPlayerAction().lookAround(gameState.GetMainMap(), gameState.GetPlayerPos());

			// gameState.GetPlayer().GetGameObjectPos().GetCurrentArea().printMapAreaCordsInfo();
			gameState.GetPlayer().getGameObjectPos().printToString();
			// Get Items in sight
			// gameState.GetPlayer().GetGame

		}

		// move command
		else if (input.Equals("m") || input.StartsWith("move")) {

				// Get the command as a list of strings separated by spaces
				//ArrayList list = new ArrayList(Arrays.AsList(input.Split('_')));


				// if the user just typed m or move, then ask what direction they want to go
				//if (list.Size() == 1) {
					String directionPlayerMoves = "e";
					String directionPlayerDistance = "0";

					bool correctInput = false;

					while (!correctInput)
					{

						Console.WriteLine("Type what direction you want to go: N, S, E or W");

						directionPlayerMoves = Console.ReadLine().ToLower();

						Console.WriteLine("Type how many minutes you want to travel: ");

						directionPlayerDistance = Console.ReadLine();

						if (directionPlayerMoves.Equals("n") || directionPlayerMoves.Equals("s")
								|| directionPlayerMoves.Equals("e")
								|| directionPlayerMoves.Equals("w") && isDouble(directionPlayerDistance))
						{

							correctInput = true;

						}
						else
						{
							Console.WriteLine("\nInvalid input\n");
						}

					}

					gameState = handleMoveCommand(gameState, directionPlayerMoves, Double.Parse(directionPlayerDistance));
					// gameState = handleMoveCommand(gameState, directionPlayerMoves,
					// int.Parse(directionPlayerDistance));
				//}

				// if the user entered their command on one line, Get the direction from the
				// second word in the command

				//else
				{
					//gameState = handleMoveCommand(gameState, list.Get(1), 0);
					//gameState = handleMoveCommand(gameState, input, 0);

				}
			}

		else if (input.Equals("print map") || input.Equals("pm")) {
			gameState.GetMainMap().printGameMapString();
		}

		// exit command
		else if (input.Equals("exit") || input.Equals("end game")) {

			// tell the player and the game that the game is ending
			Console.WriteLine("Game ended");
			gameState.SetIsGameEnded(true);
				gameState.SetIsGameEnded(true);

			// close the scanner
			//scn.close();
		}

		// invalid command case
		else {
			Console.WriteLine("invalid command");
		}

		// Console.WriteLine(popGameOutput());

		return gameState;
	}

	/**
	 * Print the help command
	 */
	private void printHelpCommand() {
			/*
		Console.WriteLine("\nGeneral coammnds: ");
		Console.Write("%-20s %s%n", "h/help", "opens the help prompt");
		Console.Writef("%-20s %s%n", "save game", "saves the game and asks for file directory and file name");
		// add load command
		Console.Writef("%-20s %s%n", "exit/end game", "exits the game");

		Console.WriteLine("\nMovement/Map commands: ");
		Console.Writef("%-20s %s%n", "m/move (n,e,s,w)", "move the player in a cardinal direction");
		Console.Writef("%-20s %s%n", "pm/print map", "prints out the game map");
		Console.Writef("%-20s %s%n", "l/look", "look around");
		Console.Writef("%-20s %s%n", "w/wait", "player waits for x ammount of time, cant be used in combat");

		Console.WriteLine("\nCombat commands: ");
		Console.Writef("%-20s %s%n", "wic/wait in combat", "same as wait but can be used in combat");
		Console.Writef("%-20s %s%n", "a/attack", "gives list of things you can attack and you choose one");

		Console.WriteLine("\nItems/Inventory commands: ");
		Console.Writef("%-20s %s%n", "i/inventory", "shows your inventory and equipped weapon if you have one");
		Console.Writef("%-20s %s%n", "pui/pick up item", "gives a list of items you can pick up if any around you");
		Console.Writef("%-20s %s%n", "di/drop item", "drops the selected item");
		Console.Writef("%-20s %s%n", "ew/equip weapon", "choose an item in inventory to equip as a weapon");

		Console.WriteLine("\nDebugging/misc commands: ");
		Console.Writef("%-20s %s%n", "pel/print entity list", "prints list of all entities on map");
		*/
	}

	/**
	 * Handle the move command by moving the player
	 */
	private GameState handleMoveCommand(GameState gameState, String direction, double minutesWalking) {
		gameState.SetLastPosition(gameState.GetPlayerPos().toString());
		// gameState.GetPlayer().GameObjectPos.movePosition(gameState.GetMainMap().map,
		// direction);
		gameState.GetPlayer().gameObjectPos.movePlayerOnMapArea(gameState.GetMainMap(), gameState.GetPlayer(),
				direction, minutesWalking);

		gameState.SetThisPosition(gameState.GetPlayerPos().toString());

		if (!gameState.GetLastPosition().Equals(gameState.GetThisPosition())) {
			gameState.SetDidPlayerMoveThisTurn(true);
			gameState.GetMainMap().printGameMapString();
		}

		return gameState;
	}

	public double GetSeconds() {
		return seconds;
	}

	public void SetSeconds(double seconds) {
		this.seconds = seconds;
	}
}

}

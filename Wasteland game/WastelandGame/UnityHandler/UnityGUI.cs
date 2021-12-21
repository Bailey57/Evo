using System;
using UnityEngine;
using UnityEngine.UI;


namespace Wasteland_game
{
    public class UnityGUI : MonoBehaviour
    {
        public int counter = 1;

        //public static GameState gameState = new GameState();
        public GameState gameState;
        public Text consoleOutput;
        public Text playerDirection;
        public int timePlayerMoving;


        //gameState.getMainMap().printGameMapString();

        public UnityGUI(GameState gameState) {
            SetGameState(gameState);
        }


        public GameState GetGameState() {
            return this.gameState;
        }
        public void SetGameState(GameState gameState) {
            this.gameState = gameState;
        }

        public Text GetConsoleOutput() {
            return this.consoleOutput;
        }
        public void SetConsoleOutput(Text consoleOutput) {
            this.consoleOutput = consoleOutput;
        }


        void Update() {
            //gameState.getPlayer().directionFacing = "N";
            gameState.getPlayer().setObjectStringEvents("lol" + gameState.getPlayer().getObjectStringEvents());



            // if (this.gameState != null) {
            consoleOutput.text = GetGameState().getPlayer().getObjectStringEvents();
                
            playerDirection.text = GetGameState().getPlayer().directionFacing;
            //playerDirection.text = "N";

            //}

            //gameState.getPlayer().setObjectStringEvents("going");
            //consoleOutput.text = "wow";
        }



        void Start() {
            // GameState mainGameState = new GameState();
            this.gameState = new GameState();
            

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
            gameState.getPlayer().setObjectStringEvents("start");

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


            for (int i = 0; i < 8; i++)
            {
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
            gameState.getPlayer().directionFacing = "?";

        }



        public void GetPlayerString()
        {
            consoleOutput.text = GetGameState().getPlayer().getObjectStringEvents();
        }

 


        public void MovePlayer() {

            //getGameState().getPlayer().getGameObjectPos().movePositionOnMapArea(gameState.getPlayer().directionFacing, timePlayerMoving);
            GetGameState().getPlayer().getGameObjectPos().movePositionOnMapArea(gameState.getPlayer().directionFacing, 1);
        }


        public void SetPlayerDirectionNorth() {
            gameState.getPlayer().directionFacing = "N";
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
                    //minuetsTraveling);
        }

        public void SetPlayerDirectionEast()
        {
            gameState.getPlayer().directionFacing = "E";
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
            //minuetsTraveling);
        }



        public void ClearConsole()
        {
            gameState.getPlayer().setObjectStringEvents("");
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
            //minuetsTraveling);
        }









    }






}

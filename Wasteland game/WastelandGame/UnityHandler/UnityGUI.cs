using System;
using UnityEngine;
using UnityEngine.UI;


namespace Wasteland_game
{
    public class UnityGUI : MonoBehaviour
    {
        public int counter = 1;

        //public static GameState gameState = new GameState();
        public static GameState GameState { get => GameState; set => GameState = value; }
        //private static GameState gameState;
        public Text consoleOutput;
        public Text playerDirection;
        public int timePlayerMoving;

        public Text tstText;
        public String txt = "";

        

        public void TextUp()
        {
            txt += "1 ";
            tstText.text = txt;
            Debug.Log("TextUp called");
        }

        //gameState.getMainMap().printGameMapString();

       // public UnityGUI(GameState gameState) {
           // SetGameState(gameState);
        //}


        //public GameState GetGameState() {
            //return this.gameState;
        //}
        //public void SetGameState(GameState gameState) {
            //this.gameState = gameState;
        //}

        public Text GetConsoleOutput() {
            return this.consoleOutput;
        }
        public void SetConsoleOutput(Text consoleOutput) {
            this.consoleOutput = consoleOutput;
        }

        //Update
         void Update() {
            //gameState.getPlayer().directionFacing = "N";
            //GameState.getPlayer().setObjectStringEvents("lol" + GameState.getPlayer().getObjectStringEvents());



            if (GameState != null)
            {
                consoleOutput.text = GameState.getPlayer().getObjectStringEvents();

                playerDirection.text = GameState.getPlayer().directionFacing;

                //playerDirection.text = "N";

            }
            else
            {
                Debug.Log("GameState null");
            }

            //gameState.getPlayer().setObjectStringEvents("going");
            //consoleOutput.text = "wow";
        }



        void Start() {
            // GameState mainGameState = new GameState();
            GameState = new GameState();
            

            // set game state values
            //gameState.setPlayerAction(new PlayerAction());
            GameState.setMainMap(new Map(25));

            int initMapX = 0;
            int initMapY = 0;
            int initMapAreaX = 0;
            int initMapAreaY = 0;
            GameState.getMainMap().makeGameMap1();
            GameObjectPos startPos = new GameObjectPos(GameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
            GameObjectPos startPos2 = new GameObjectPos(GameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);


            //gameState.getMainMap().makeMap1(gameState.getMainMap());
            GameState.setPlayerPos(startPos);


            GameState.setLastPosition("");
            GameState.setThisPosition("");



            GameState.setPlayer(new Entity("Player", true, 100, 1.5, .1, GameState.getPlayerPos()));
            //gameState.getPlayer().getGameObjectPos().setGameObject(gameState.getPlayer());
            GameState.getPlayer().setObjectName("Player");
            GameState.getPlayer().setEntityName("Player");
            GameState.getPlayer().setStrength(25);

            Hitbox hitbox = new Hitbox();
            GameState.getPlayer().setGameObjectHitbox(hitbox.newHumanHitbox());
            //ask player to enter the name of their character 

            GameState.getPlayer().setIsThePlayer(true);
            GameState.getMainMap().setGameMapPlayer(initMapX, initMapY, true);

            GameState.getMainMap().printGameMapString();
            GameState.getPlayer().getGameObjectPos().getCurrentArea().printMapAreaCordsInfo();
            //gameState.getPlayer().getGameObjectPos();
            

            //make a spear
            BaseItem spear = new BaseItem(startPos2, "Spear", 10);
            spear.setInInventory(false);
            spear.setPierce(20);
            spear.setSlash(5);
            GameState.getMainMap().addGameObjectToMapList(spear);


            GameObjectPos startPos3 = new GameObjectPos(GameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
            Magazine _9mm_mag = new Magazine(startPos3, "9mm mag", .95, 6, 9);
            _9mm_mag.setInInventory(false);

            Magazine _9mm_mag2 = new Magazine(startPos3, "9mm mag", .95, 6, 9);
            _9mm_mag2.setInInventory(false);


            for (int i = 0; i < 8; i++)
            {
                startPos3 = new GameObjectPos(GameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
                ProjectileAmmo bullet = new ProjectileAmmo(startPos3, "9mm Federal FMJ:" + i, 0.00804, 9, 350);
                _9mm_mag.addBullet(bullet);

                bullet = new ProjectileAmmo(startPos3, "9mm Federal FMJ:" + i, 0.00804, 9, 350);
                _9mm_mag2.addBullet(bullet);
            }
            GameState.getMainMap().addGameObjectToMapList(_9mm_mag);
            startPos3 = new GameObjectPos(GameState.getMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
            Gun gun = new Gun(startPos3, "9mm pistol", 9, true, true);
            gun.setInInventory(false);
            GameState.getMainMap().addGameObjectToMapList(gun);
            gun.setMagazine(_9mm_mag);
            gun.setAttackRange(50);


            //UnityGUI unityGUI = new UnityGUI(gameState);
            //GameState.getPlayer().setObjectStringEvents("start");
            GameState.getPlayer().setObjectStringEvents("start" + GameState.getPlayer().getObjectStringEvents());

            GameState.getPlayer().setDirectionFacing("?");
            
            Debug.Log("Game started");
        }



        //public void GetPlayerString()
        //{
            //consoleOutput.text = GetGameState().getPlayer().getObjectStringEvents();
       // }

 


        public void MovePlayer() {

            //getGameState().getPlayer().getGameObjectPos().movePositionOnMapArea(gameState.getPlayer().directionFacing, timePlayerMoving);
            GameState.getPlayer().getGameObjectPos().movePositionOnMapArea(GameState.getPlayer().directionFacing, 1);
            Debug.Log("Player moved");
        }


        public void SetPlayerDirectionNorth() {
            GameState.getPlayer().setDirectionFacing("N");
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
            //minuetsTraveling);
            
            Debug.Log("direction set to N");
        }

        public void SetPlayerDirectionEast()
        {
            GameState.getPlayer().setDirectionFacing("E");
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
            //minuetsTraveling);
            Debug.Log("direction set to E");
        }



        public void ClearConsole()
        {
            GameState.getPlayer().setObjectStringEvents("");
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
            //minuetsTraveling);
            Debug.Log("Console cleared");
        }









    }






}

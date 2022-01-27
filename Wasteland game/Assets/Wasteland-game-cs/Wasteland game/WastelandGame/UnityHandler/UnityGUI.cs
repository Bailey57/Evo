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



            if (gameState != null)
            {
               consoleOutput.text = gameState.GetPlayer().getObjectStringEvents();

                playerDirection.text = gameState.GetPlayer().directionFacing;

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
            
            Debug.Log("Game started");
            // GameState mainGameState = new GameState();
            //GameState gameState = new GameState();
            

            // set game state values
            //gameState.setPlayerAction(new PlayerAction());
            this.gameState = gameObject.AddComponent<GameState>();
            gameState.SetMainMap(new Map(25));

            int initMapX = 0;
            int initMapY = 0;
            int initMapAreaX = 0;
            int initMapAreaY = 0;
            gameState.GetMainMap().makeGameMap1();
            GameObjectPos startPos = new GameObjectPos(gameState.GetMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);
            GameObjectPos startPos2 = new GameObjectPos(gameState.GetMainMap(), initMapX, initMapY, initMapAreaX, initMapAreaY);


            //gameState.getMainMap().makeMap1(gameState.getMainMap());
            gameState.SetPlayerPos(startPos);





            gameState.SetPlayer(new Entity("Player", true, 100, 1.5, .1, gameState.GetPlayerPos()));
            //gameState.getPlayer().getGameObjectPos().setGameObject(gameState.getPlayer());
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
            //gameState.getPlayer().getGameObjectPos();
            

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


            for (int i = 0; i < 8; i++)
            {
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
            //GameState.getPlayer().setObjectStringEvents("start");
            gameState.GetPlayer().setObjectStringEvents("start" + gameState.GetPlayer().getObjectStringEvents());

            gameState.GetPlayer().setDirectionFacing("?");
            
            Debug.Log("Game finished starting");
        }



        //public void GetPlayerString()
        //{
            //consoleOutput.text = GetGameState().getPlayer().getObjectStringEvents();
       // }

 


        public void MovePlayer() {

            //getGameState().getPlayer().getGameObjectPos().movePositionOnMapArea(gameState.getPlayer().directionFacing, timePlayerMoving);
            gameState.GetPlayer().getGameObjectPos().movePositionOnMapArea(gameState.GetPlayer().directionFacing, 1);
            Debug.Log("Player moved");
        }


        public void SetPlayerDirectionNorth() {
            gameState.GetPlayer().setDirectionFacing("N");
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
            //minuetsTraveling);
            
            Debug.Log("direction set to N");
        }

        public void SetPlayerDirectionEast()
        {
            gameState.GetPlayer().setDirectionFacing("E");
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
            //minuetsTraveling);
            Debug.Log("direction set to E");
        }



        public void ClearConsole()
        {
            gameState.GetPlayer().setObjectStringEvents("");
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
            //minuetsTraveling);
            Debug.Log("Console cleared");
        }









    }






}

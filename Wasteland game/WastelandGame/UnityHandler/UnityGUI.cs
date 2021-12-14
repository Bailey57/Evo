using System;
//using UnityEngine;


namespace Wasteland_game
{
    public class UnityGUI
    {

        GameState gameState;

        //gameState.getMainMap().printGameMapString();

        public UnityGUI(GameState gameState) {
            setGameState(gameState);
        }


        public GameState getGameState() {
            return this.gameState;
        }
        public void setGameState(GameState gameState) {
            this.gameState = gameState;
        }




        public void setPlayerDirectionNorth() {
                gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), "N",
                    1);
            //gameState.getPlayerPos().movePlayerOnMapArea(gameState.getMainMap(), gameState.getPlayer(), direction,
                    //minuetsTraveling);

        }


        public String getPlayerString()
        {
            return getGameState().getPlayer().getObjectStringEvents();
        }

    }






}

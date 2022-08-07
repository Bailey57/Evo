using Evo.GameObjects.HitBoxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evo.Factions;
namespace Evo.Factories
{
    //package wasteland.entity;

    //using Wasteland.map.GameObjectPos;

    //maybe make a zombie class and MakeZombie class ect... later 
    public class MakeEntity
    {



        public MakeEntity()
        {

        }



        //make stats based on level
        public Entity MakeZombie(GameObjectPos GameObjectPos, int level)
        {
            bool alive;
            double energy;
            double movementSpeed;
            double accuracy;
            Hitbox hitbox = new Hitbox();



            //bool alive, double energy, double movementSpeed, double accuracy, GameObjectPos GameObjectPos
            Entity baseZombie = new Entity("Zombie", true, 100, .5, 50, GameObjectPos);
            //Entity(String objectName, double integraty, bool alive, double energy, double movementSpeed, double accuracy, GameObjectPos GameObjectPos)
            baseZombie.entityName = "zombie";


            baseZombie.setGameObjectHitbox(hitbox.newHumanHitbox());
            //Entity zombie = new Entity(alive, energy, movementSpeed, accuracy, GameObjectPos);


            return baseZombie;

        }


        public Entity MakeUS_MilitiaMan(GameObjectPos gameObjectPos, Faction faction) 
        {
            Entity militiaMan = new Entity("US militia man", true, 100, 1, 50, gameObjectPos);
            militiaMan.Faction = FactionFactory.FactionList[2];
            return militiaMan;
        }






    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.GameObjects.Factories
{
    /*
    package wasteland.gameObject;

using Wasteland.entity.Entity;
using Wasteland.items.weapons.Gun;
using Wasteland.map.GameObjectPos;
	*/

    public class GameObjectFactory
    {



        public GameObjectFactory()
        {

        }



        public Entity makeEnemy()
        {



            Entity entity = new Entity(null, false, 0, 0, 0, null);
            return entity;
        }









        //	public Gun makeGun(GameObjectPos objectPos) {
        //		
        //		
        //		Gun gun = new Gun(objectPos, "gun", 11.43, true, true);
        //		
        //		
        //		return gun;
        //	}


       








    }

}

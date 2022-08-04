using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.Factories
{
    public static class GunFactory
    {





        /**
        * Makes an M1911 pistol  
        * @param objectPos
        * @param condition
        * @return
        */
        public static Gun MakeGun_M1911(GameObjectPos objectPos, double condition)
        {
            GameObjectPos newObjectPos = objectPos;
            Gun M1911 = new Gun(newObjectPos, "M1911", 11.43, true, true);
            M1911.setMassInKg(1.1);
            M1911.setObjectDescription("An old but reliable pistol. Takes .45 cal (11.43mm) size ammo.");
            //M1911.setIntegraty(100);
            M1911.setQuality(100);
            M1911.setDamages(6, 2, 1);
            M1911.setLengthX(0.216);
            M1911.setCondition(condition);
            //last for 100000 rounds
            //max range: 50 meters
            return M1911;
        }



        public static Gun MakeGun_9mmPistol(GameObjectPos objectPos, double condition)
        {
            GameObjectPos newObjectPos = objectPos;
            Gun _9mmPistol = new Gun(newObjectPos, "9mmPistol", 9, true, true);
            _9mmPistol.setMassInKg(1.1);
            _9mmPistol.setObjectDescription("An old but reliable pistol. Takes 9mm size ammo.");
            //M1911.setIntegraty(100);
            _9mmPistol.setQuality(100);
            _9mmPistol.setDamages(6, 2, 1);
            _9mmPistol.setLengthX(0.216);
            _9mmPistol.setCondition(condition);
            //last for 100000 rounds
            //max range: 50 meters
            return _9mmPistol;
        }


        public static Gun MakeGun_AK47(GameObjectPos objectPos, double condition)
        {
            GameObjectPos newObjectPos = objectPos;
            Gun AK47 = new Gun(newObjectPos, "AK47", 7.62, true, true);
            AK47.setMassInKg(3.47);
            AK47.setObjectDescription("A reliable rifle used by generations of warmongers. Takes 7.62mm size ammo.");
            AK47.setIntegraty(100);
            AK47.setQuality(100);
            AK47.setDamages(10, 2, 1);
            AK47.setLengthX(0.88);
            AK47.setCondition(condition);
            //last for x rounds
            //max range: 350 meters
            return AK47;

        }










    }
}

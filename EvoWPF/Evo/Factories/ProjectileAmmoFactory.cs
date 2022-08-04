using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.Factories
{
    public static class ProjectileAmmoFactory
    {


        public static ProjectileAmmo Make9mmFederalFMJ(GameObjectPos gameObjectPos) 
        {
            ProjectileAmmo bullet = new ProjectileAmmo(gameObjectPos, "9mm Federal FMJ", 0.00804, 9, 350);
            return bullet;
        }



		public static ProjectileAmmo MakeAK_762_Standard(GameObjectPos gameObjectPos)
		{
			ProjectileAmmo bullet = new ProjectileAmmo(gameObjectPos, "AK 7.62 standard", 0.00797027, 7.62, 715.9752);
			return bullet;
		}


		public static ProjectileAmmo MakeM1CarbineFMJ(GameObjectPos gameObjectPos)
		{
			ProjectileAmmo bullet = new ProjectileAmmo(gameObjectPos, "M1 Carbine FMJ", 0.007127885, 7.62, 604);
			return bullet;
		}


		public static ProjectileAmmo MakePelletGunAmmo(GameObjectPos gameObjectPos)
		{
			ProjectileAmmo bullet = new ProjectileAmmo(gameObjectPos, "pelletGun ammo", 0.00055, 4.5, 292);
			return bullet;
		}






		/*
		_380ACP.finalVelocity();
		Debug.WriteLine("pen: " + _380ACP.kruppPenFormula());
		Debug.WriteLine(_380ACP.toString2());
		
		
		BulletPenetration M855 = new BulletPenetration("M855", 0.00401753, 5.56, 944.88, travelDistance);
		M855.finalVelocity();
		Debug.WriteLine("pen: " + M855.kruppPenFormula());
		Debug.WriteLine(M855.toString2());
		

		


		BulletPenetration slug12Gauge = new BulletPenetration("slug12Gauge", 0.028349523, 18.53, 564, 200);
		Debug.WriteLine(slug12Gauge.toString2());


		BulletPenetration sig = new BulletPenetration("sig", 0.00745187, 9, 335.4, 10.1346);
		Debug.WriteLine("pen: " + sig.kruppPenFormula());
		Debug.WriteLine(sig.toString2());

		BulletPenetration sigAt60 = new BulletPenetration("sig at 60mps", 0.00745187, 9, 60, 10.1346);
		Debug.WriteLine(sigAt60.toString2());

		BulletPenetration sig2 = new BulletPenetration("sig 200", 0.00745187, 9, 335.4, 200);
		Debug.WriteLine(sig2.toString2());

		

		BulletPenetration M2HB_50cal = new BulletPenetration("M2HB_50cal", 0.04, 12.7, 929, 10.1346);
		Debug.WriteLine(M2HB_50cal.kruppPenFormula());
		Debug.WriteLine(M2HB_50cal.toString2());
		*/


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_game.WastelandGame.Magazine
{
	/*
	package wasteland.items.weapons;

	using Wasteland.items.ProjectileAmmo;
	//using Wasteland.items.Ammo;
	using Wasteland.items.BaseItem;
	using Wasteland.map.GameObjectPos;
	*/
	//make it work same way as a stack basically 
	public class Magazine : BaseItem
	{

	/**
	 * 
	 */

	public int ammoCapacity;

	public ProjectileAmmo[] bulletsInMag;

	public int ammountOfBulletsInMag;

	public double magProjectileDiamiter;

	public Magazine(GameObjectPos gameObjectPos, String objectName, double mass, int ammoCapacity, double magProjectileDiamiter)
	{
		super(gameObjectPos, objectName, 0);

		this.ammoCapacity = ammoCapacity;
		this.magProjectileDiamiter = magProjectileDiamiter;
		bulletsInMag = new ProjectileAmmo[this.ammoCapacity];

	}

	/**
	 * @return the ammoCapacity
	 */
	public int getAmmoCapacity()
	{
		return ammoCapacity;
	}

	/**
	 * @param ammoCapacity the ammoCapacity to set
	 */
	public void setAmmoCapacity(int ammoCapacity)
	{
		this.ammoCapacity = ammoCapacity;
	}

	/**
	 * @return the bulletsInMag
	 */
	public ProjectileAmmo[] getBulletsInMag()
	{
		return bulletsInMag;
	}

	/**
	 * @param bulletsInMag the bulletsInMag to set
	 */
	public void setBulletsInMag(ProjectileAmmo[] bulletsInMag)
	{
		this.bulletsInMag = bulletsInMag;
	}

	/**
	 * @return the ammountOfBulletsInMag
	 */
	public int getAmmountOfBulletsInMag()
	{
		return ammountOfBulletsInMag;
	}

	/**
	 * @param ammountOfBulletsInMag the ammountOfBulletsInMag to set
	 */
	public void setAmmountOfBulletsInMag(int ammountOfBulletsInMag)
	{
		this.ammountOfBulletsInMag = ammountOfBulletsInMag;
	}

	/**
	 * @return the magProjectileDiamiter
	 */
	public double getMagProjectileDiamiter()
	{
		return magProjectileDiamiter;
	}

	/**
	 * @param magProjectileDiamiter the magProjectileDiamiter to set
	 */
	public void setMagProjectileDiamiter(double magProjectileDiamiter)
	{
		this.magProjectileDiamiter = magProjectileDiamiter;
	}


	public boolean fillMagazine(ProjectileAmmo[] projectile)
	{
		//ammoCapacity
		for (int i = 0; i < ammoCapacity; i++)
		{
			addBullet(projectile[i]);

		}
		if (ammountOfBulletsInMag == ammoCapacity)
		{
			return true;

		}
		else
		{
			return false;
		}

	}

	/**
	 * Same as push on a stack
	 * 
	 * @param projectile
	 */
	public boolean addBullet(ProjectileAmmo projectile)
	{
		boolean added = false;

		if (projectile.getDiameter() == magProjectileDiamiter && ammountOfBulletsInMag < ammoCapacity)
		{

			if (bulletsInMag == null)
			{
				bulletsInMag = new ProjectileAmmo[ammoCapacity];
			}
			bulletsInMag[ammountOfBulletsInMag] = projectile;
			added = true;
			projectile.setInInventory(added);
			ammountOfBulletsInMag++;



			//			for (int i = 0; i < bulletsInMag.length; i++) {
			//				if (bulletsInMag[i] == null) {
			//					bulletsInMag[i] = projectile;
			//					ammountOfBulletsInMag++;
			//					break;
			//				}
			//
			//			}

		}

		return added;

	}

	/**
	 * 
	 * @return
	 */
	public ProjectileAmmo removeBullet()
	{
		boolean removed = false;
		ProjectileAmmo projectile = null;

		if (ammountOfBulletsInMag >= 1)
		{
			projectile = bulletsInMag[ammountOfBulletsInMag - 1];
			bulletsInMag[ammountOfBulletsInMag - 1].setInInventory(false);
			GameObjectPos newPos = this.getGameObjectPos();
			bulletsInMag[ammountOfBulletsInMag - 1].setGameObjectPos(newPos);
			bulletsInMag[ammountOfBulletsInMag - 1] = null;
			removed = true;
			ammountOfBulletsInMag--;
		}

		//		for (int i = bulletsInMag.length; i > bulletsInMag.length; i--) {
		//			if (bulletsInMag[i] == null) {
		//				
		//				bulletsInMag[i] = null;
		//				removed = true;
		//				ammountOfBulletsInMag --;
		//				break;
		//			} 
		//		}

		return projectile;
	}


	public String bulletsInMagToString()
	{
		String output = "\n";

		for (int i = 0; i < bulletsInMag.length; i++)
		{
			if (bulletsInMag[i] != null)
			{
				output += bulletsInMag[i].getObjectName() + "\n";
			}

		}


		//bulletsInMag[i]


		return output;
	}





	public static void main(String[] args)
	{
		GameObjectPos gop = new GameObjectPos(null, 0, 0, 0, 0);
		ProjectileAmmo bullet = new ProjectileAmmo(gop, "9mm Federal FMJ", 0.00804, 9, 350);

		Magazine _9mm_mag = new Magazine(gop, "9mm mag", .95, 6, 9);

		for (int i = 0; i < 6; i++)
		{
			_9mm_mag.addBullet(bullet);
		}



		Console.Writeln(_9mm_mag.bulletsInMagToString());

	}

}

}
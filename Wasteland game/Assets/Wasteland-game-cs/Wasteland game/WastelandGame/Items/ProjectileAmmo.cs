using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_game
{

	/*
	package wasteland.items;

	using Wasteland.calculator.BulletPenetration;
	using Wasteland.map.GameObjectPos;
	*/
	[System.Serializable]
	public class ProjectileAmmo : BaseItem
	{

	
	public double mass;
	public double diameter;
	public double length;
	public double initV;

	public bool used = false;

	public double currentV;


	//public Ammo nato7_62 = new Ammo(1, "NATO7.62, M80 FMJ", .01, 1, .1, 7.62, 850);


	public ProjectileAmmo(GameObjectPos gameObjectPos, String objectName, double mass, double diameter, double initV) 
			: base(gameObjectPos, objectName, 0)
		{
		


		this.mass = mass;
		this.diameter = diameter;
		this.initV = initV;
		this.currentV = initV;
	}



	public ProjectileAmmo(GameObjectPos gameObjectPos, String objectName, double mass, double diameter, double length,
			double initV) : base(gameObjectPos, objectName, 0)
		{
		
		this.mass = mass;
		this.diameter = diameter;
		this.length = length;
		this.initV = initV;
		this.used = used;
		this.currentV = currentV;
	}



	/**
	 * @return the mass
	 */
	public double getMass()
	{
		return mass;
	}

	/**
	 * @param mass the mass to set
	 */
	public void setMass(double mass)
	{
		this.mass = mass;
	}

	/**
	 * @return the diameter
	 */
	public double getDiameter()
	{
		return diameter;
	}

	/**
	 * @param diameter the diameter to set
	 */
	public void setDiameter(double diameter)
	{
		this.diameter = diameter;
	}

	/**
	 * @return the initV
	 */
	public double getInitV()
	{
		return initV;
	}

	/**
	 * @param initV the initV to set
	 */
	public void setInitV(double initV)
	{
		this.initV = initV;
	}

	/**
	 * @return the used
	 */
	public bool isUsed()
	{
		return used;
	}

	/**
	 * @param used the used to set
	 */
	public void setUsed(bool used)
	{
		this.used = used;
	}





	/**
	 * @return the length
	 */
	public double getLength()
	{
		return length;
	}

	/**
	 * @param length the length to set
	 */
	public void setLength(double length)
	{
		this.length = length;
	}

	/**
	 * @return the currentV
	 */
	public double getCurrentV()
	{
		return currentV;
	}

	/**
	 * @param currentV the currentV to set
	 */
	public void setCurrentV(double currentV)
	{
		this.currentV = currentV;
	}

	public void impactHitbox()
	{


	}


	//change later to be more realistic
	public double finalKeneticEnergy(double distance)
	{
		BulletPenetration bp = new BulletPenetration(this, distance);

		return bp.getFinalKE();
	}

	public double getDamamage(double distance)
	{
		return finalKeneticEnergy(distance) / 10;
	}




}



}
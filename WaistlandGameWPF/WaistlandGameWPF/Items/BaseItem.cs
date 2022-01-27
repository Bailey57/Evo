using System;


namespace Wasteland_game
{

	/*
	package wasteland.items;

	import java.io.Serializable;

	using Wasteland.GameObject;
	using Wasteland.map.GameObjectPos;
	*/
	[System.Serializable]
	public class BaseItem : GameObject
	{

	/**
	 * 
	 */
	//private static final long serialVersionUID = 1L;

	public double itemValue;

	// public Material material;

	// Damage type
	// blunt, pierce, slash, chemical, radiation (might scrap radiation)
	public double bluntDamage;
	public double slash;
	public double pierce;

	public double attackRange;

	public bool isMelee;

	public bool inInventory = false;

	public double quality;

	public double condition;

	//might remove
	public double MAX_CONDITION = 100;

	/*
	 * 1: Armor Plate 2: Apple 3:
	 * 
	 */

	public BaseItem(GameObjectPos gameObjectPos, String objectName, double attackRange) 
			: base(gameObjectPos, objectName)
		{
		
		this.attackRange = attackRange;

	}

	public BaseItem(GameObjectPos gameObjectPos, String objectName, double attackRange, double quality,
			double condition) : base(gameObjectPos, objectName)

	{
		this.attackRange = attackRange;
		this.quality = quality;
		this.condition = condition;

	}

	//pretty much out of 100
	public void setDamages(double bluntDamage, double slash, double pierce)
	{
		this.bluntDamage = bluntDamage;
		this.slash = bluntDamage;
		this.pierce = pierce;
	}

	/**
	 * @return the bluntDamage
	 */
	public double getBluntDamage()
	{
		return bluntDamage;
	}

	/**
	 * @param bluntDamage the bluntDamage to set
	 */
	public void setBluntDamage(double bluntDamage)
	{
		this.bluntDamage = bluntDamage;
	}

	/**
	 * @return the slash
	 */
	public double getSlash()
	{
		return slash;
	}

	/**
	 * @param slash the slash to set
	 */
	public void setSlash(double slash)
	{
		this.slash = slash;
	}

	/**
	 * @return the pierce
	 */
	public double getPierce()
	{
		return pierce;
	}

	/**
	 * @param pierce the pierce to set
	 */
	public void setPierce(double pierce)
	{
		this.pierce = pierce;
	}

	/**
	 * @return the attackRange
	 */
	public double getAttackRange()
	{
		return attackRange;
	}

	/**
	 * @param attackRange the attackRange to set
	 */
	public void setAttackRange(double attackRange)
	{
		this.attackRange = attackRange;
	}

	/**
	 * @return the isMelee
	 */
	public bool isMeleeBool()
	{
		return isMelee;
	}

	/**
	 * @param isMelee the isMelee to set
	 */
	public void setMelee(bool isMelee)
	{
		this.isMelee = isMelee;
	}

	public double getItemValue()
	{
		return itemValue;
	}

	public void setItemValue(double itemValue)
	{
		this.itemValue = itemValue;
	}

	/**
	 * @return the inInventory
	 */
	public bool isInInventory()
	{
		return inInventory;
	}

	/**
	 * @param inInventory the inInventory to set
	 */
	public void setInInventory(bool inInventory)
	{
		this.inInventory = inInventory;
	}

	/**
	 * @return the quality
	 */
	public double getQuality()
	{
		return quality;
	}

	/**
	 * @param quality the quality to set
	 */
	public void setQuality(double quality)
	{
		this.quality = quality;
	}

	/**
	 * @return the condition
	 */
	public double getCondition()
	{
		return condition;
	}

	/**
	 * @param condition the condition to set
	 */
	public void setCondition(double condition)
	{
		this.condition = condition;
	}

	public double getHighestDamageType()
	{

		if (bluntDamage >= slash && bluntDamage >= pierce)
		{
			return bluntDamage;

		}
		else if (slash >= bluntDamage && slash >= pierce)
		{
			return slash;

		}
		else if (pierce >= bluntDamage && pierce >= slash)
		{
			return pierce;
		}
		else
		{
			return bluntDamage;
		}

	}

}

}
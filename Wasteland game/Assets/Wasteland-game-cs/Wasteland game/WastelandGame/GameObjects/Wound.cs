using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_game
{
	//package wasteland.entity;
	[System.Serializable]
	public class Wound {
	
	private String name;
	private double depth;
	private double length;
	private double width;
	
	private double bleedRate_ml_per_sec; //humans have 5700
	
	private String info;
	
	
	
	
	/**
	 * 
	 * @param name
	 * @param depth
	 * @param length
	 * @param width
	 * @param info
	 */
	public Wound(String name, double depth, double length, double width, String info) {
		this.name = name;
		this.depth = depth;
		this.length = length;
		this.width = width;
		this.getAndSetBleedRate();
		this.info = info;
	}

	/**
	 * @return the name
	 */
	public String getName() {
		return name;
	}

	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		this.name = name;
	}

	/**
	 * @return the depth
	 */
	public double getDepth() {
		return depth;
	}

	/**
	 * @param depth the depth to set
	 */
	public void setDepth(double depth) {
		this.depth = depth;
	}

	/**
	 * @return the length
	 */
	public double getLength() {
		return length;
	}

	/**
	 * @param length the length to set
	 */
	public void setLength(double length) {
		this.length = length;
	}

	/**
	 * @return the width
	 */
	public double getWidth() {
		return width;
	}

	/**
	 * @param width the width to set
	 */
	public void setWidth(double width) {
		this.width = width;
	}

	/**
	 * @return the bleedRate_ml_per_sec
	 */
	public double getBleedRate_ml_per_sec() {
		return bleedRate_ml_per_sec;
	}

	/**
	 * @param bleedRate_ml_per_sec the bleedRate_ml_per_sec to set
	 */
	public void setBleedRate_ml_per_sec(double bleedRate_ml_per_sec) {
		this.bleedRate_ml_per_sec = bleedRate_ml_per_sec;
	}

	/**
	 * @return the info
	 */
	public String getInfo() {
		return info;
	}

	/**
	 * @param info the info to set
	 */
	public void setInfo(String info) {
		this.info = info;
	}
	
	/**
	 * 
	 * @return woundArea
	 */
	public double getWoundArea() {
		double woundArea = this.getLength() * this.getDepth() * this.getLength();
		return woundArea;
	}
	
	/**
	 * in ml per second
	 * @return bleedRate
	 *  
	 */
	public double getAndSetBleedRate(){
		bleedRate_ml_per_sec = getWoundArea() / 10000;
		return bleedRate_ml_per_sec;
	}
	
	
	
	public double clotBleeding(){
		bleedRate_ml_per_sec = bleedRate_ml_per_sec * .1;
		return bleedRate_ml_per_sec;
	}
	
	public double unClotBleeding(){
		getAndSetBleedRate();
		return bleedRate_ml_per_sec;
	}
	

	

}

}

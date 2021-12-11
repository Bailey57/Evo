/*
package wasteland.calculator;

import java.util.Random;
*/
public class RandomNumbers {
	
	
	public RandomNumbers() {
		
	}
	
	
	/**
	 * Note: Move to calculator class
	 * 
	 * @param max
	 * @param min
	 * @return
	 */
	public int rollRandInt(int max, int min) {
		int rngNum = 0;
		rngNum = (int) (Math.random() * (max - min + 1) + min);
		
		return rngNum;
	}
	
	public double rollRandDouble(double max, double min) {
		double rngNum = 0;
		Random rand = new Random(); 
		rngNum = min + (max - min) * rand.nextDouble();
		
		return rngNum;
	}
	
	
	public static void main(String[] args) {
		RandomNumbers rand = new RandomNumbers();
		
		Console.Writeline(rand.rollRandDouble(20, -20));
	}

}

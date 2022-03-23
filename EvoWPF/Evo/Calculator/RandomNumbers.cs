using System;


/*
package wasteland.calculator;

import java.util.Random;
*/
namespace Evo
{
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
		Random random = new Random();
			if (min > max) {
				rngNum = random.Next(max, min);
			} else
			{
				rngNum = random.Next(min, max);
			}
		
		
		return rngNum;
	}
	
	public double rollRandDouble(double max, double min) {
		double rngNum = 0;
		Random rand = new Random(); 
		rngNum = min + (max - min) * rand.NextDouble();
		
		return rngNum;
	}
	
	
	public static void main(String[] args) {
		RandomNumbers rand = new RandomNumbers();
		
		Console.WriteLine(rand.rollRandDouble(20, -20));
	}

}
}
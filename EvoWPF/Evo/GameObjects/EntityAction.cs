using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaistlandGameWPF
{
	//package wasteland.entity;
	
	public class EntityAction {
	
	

	
	
	//public void bandageSelfWound() {		
	//}
	
	public void bandageWound(Animal wounded, BodyPart bodyPart, Wound wound) {
		
		for (int i = 0; i < wounded.bodyParts.GetLength(0); i++) {
			if (wounded.bodyParts[i] == bodyPart) {
				wounded.bodyParts[i].removeWound(wound);
			}
			
		}		
	}
	
	
	
	
	
	//public bool putOnWearable() {
		//return false;
	//}
	
	
	
	
	
	

}

}

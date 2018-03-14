using UnityEngine;
using System.Collections;

public class Detect : MonoBehaviour {
    
	public KeyCode k = KeyCode.K;
	
   // void OnTriggerEnter(Collider other) {
		
		void OnTriggerStay(Collider other)
{
	 if(other.gameObject.tag == "Enemy")
	{
		print("Still colliding with trigger object " + other.name);
			
			if (Input.GetKeyUp(k))
			{Destroy(other.gameObject);}
	}
    
}
       
		     

}
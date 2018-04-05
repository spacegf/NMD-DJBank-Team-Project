using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	
	 void Start() {
		 
	 }
   
 void OnTriggerEnter(Collider other)
{
	
	
	if(other.gameObject.tag == "Enemy"){	
	Destroy(other.gameObject);
		}
		if(other.gameObject.tag == "Terrain"){	
	Destroy(gameObject);
		}
    
		}
	}

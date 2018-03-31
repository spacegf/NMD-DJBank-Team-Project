using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
   
 void OnTriggerEnter(Collider other)
{
	if(other.gameObject.tag == "Enemy"){	
	Destroy(other.gameObject);
		}
    //print("Collision detected with trigger object " + other.name);
	else if(other.gameObject.tag != "Spaw"){	
	if(other.gameObject.tag != "Blast"){
	if(other.gameObject.tag != "Terrain"){
		if(other.gameObject.tag != "Shot"){
		print("Deleted " + name);
	Destroy(gameObject);
		}
	}
}
}
}
}
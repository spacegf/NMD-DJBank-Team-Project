using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
   
 void OnTriggerEnter(Collider other)
{
	if(other.gameObject.tag == "Enemy"){	
	Destroy(other.gameObject);
		}
    print("Collision detected with trigger object " + other.name);
	if(other.gameObject.tag != "spaw"){	
	if(other.gameObject.tag != "Blast"){	
	print("Deleted " + other.name);
	Destroy(gameObject);
}
}
}
}
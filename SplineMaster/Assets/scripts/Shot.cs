using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	
	private Detect detect;
	
	 void Start() {
		 GameObject Blast = GameObject.FindWithTag ("Blast");
        if (Blast != null)
        {
            detect = Blast.GetComponent <Detect>();
        }
	 }
   
 void OnTriggerEnter(Collider other)
{
	
	
	if(other.gameObject.tag == "Enemy"){	
	detect.AddScore(10);
	Destroy(other.gameObject);
		}
		if(other.gameObject.tag == "Terrain"){	
	Destroy(gameObject);
		}
    
		}
	}

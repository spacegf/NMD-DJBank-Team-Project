using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	
	private Detect detect;
	
	void Start ()
    {
		GameObject Blast = GameObject.FindWithTag ("Blast");
        if (Blast != null)
        {
            detect = Blast.GetComponent <Detect>();
        }
	}

void OnTriggerEnter(Collider other)
{
	if(other.gameObject.tag == "Enemy"){
	Destroy(other.gameObject);
		}
	if(other.gameObject.tag == "Coin"){
	detect.AddScore(10);
	Destroy(other.gameObject);
	}
		if(other.gameObject.tag != "Spaw"){
	if(other.gameObject.tag != "Blast"){
    //print("Collision detected with trigger object " + other.name);
	}
		}
	if(other.gameObject.tag == "Terrain"){

	//Destroy(other.gameObject);
		}
	
}
}

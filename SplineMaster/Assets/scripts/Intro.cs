using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	public KeyCode e = KeyCode.E;
	public GameObject Screen1;
	public GameObject Screen2;
	
	void Update()
    {
		if (Input.GetKeyUp(e)){
					Screen1.SetActive(false);
					Screen2.SetActive(true);
			}
	}
	
    
}
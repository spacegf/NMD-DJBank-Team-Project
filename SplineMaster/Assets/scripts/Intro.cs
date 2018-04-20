using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
	public KeyCode e = KeyCode.E;
	public KeyCode t = KeyCode.T;
	public GameObject Screen1;
	public GameObject Screen2;
	
	void Update()
    {
		if (Input.GetKeyUp(e)){
					Screen1.SetActive(false);
					Screen2.SetActive(true);
			}
			if (Input.GetKeyUp(t)){
					Screen1.SetActive(true);
					Screen2.SetActive(false);
					SceneManager.LoadScene ("track2");
			}
	}
	
    
}
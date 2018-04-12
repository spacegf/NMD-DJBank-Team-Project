using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Detect : MonoBehaviour {
    
	public Text scoreText;
    private int score;
	
	public KeyCode k = KeyCode.K;
	
	//public Transform shot;
	//public Transform target;
    //public float speed;
	public GameObject Shot;
    public Transform shotSpawn;
	
	
    void Start ()
    {
		score = 0;
        UpdateScore ();
	}
	
	
	 void Update()
    {
	 var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
     var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
if (Input.GetKeyUp(k)){
				Fire();
					
			}
        transform.Rotate(0, 0, 0);
        transform.Translate(0, 0, z);

	
	}
	
	void Fire()
    {
        
        var shot = (GameObject)Instantiate(
            Shot,
            shotSpawn.position,
            shotSpawn.rotation);

        
        shot.GetComponent<Rigidbody>().velocity = shot.transform.forward * -120;

       
        Destroy(shot, 2.0f);        
    }
	
		void OnTriggerStay(Collider other){
	 if(other.gameObject.tag == "Enemy"){
		//print("Still colliding with trigger object " + other.name);
			
			if (Input.GetKeyUp(k)){
				Fire();
					
			}
	}
}
         public void AddScore(int gain)
    {
        score += gain;
        UpdateScore ();
    }
	void UpdateScore()
    {
		print("Score: " + score);
		scoreText.GetComponent<Text>().text = "Score: " + score;
        scoreText.text = "Score: " + score;
    }
		     

}
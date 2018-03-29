using UnityEngine;
using System.Collections;

public class Detect : MonoBehaviour {
    
	public KeyCode k = KeyCode.K;
	
	//public Transform shot;
	//public Transform target;
    //public float speed;
	public GameObject Shot;
    public Transform shotSpawn;
	
	 void Update()
    {
	 var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
     var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

	
	}
	
	void Fire()
    {
        
        var shot = (GameObject)Instantiate(
            Shot,
            shotSpawn.position,
            shotSpawn.rotation);

        
        shot.GetComponent<Rigidbody>().velocity = shot.transform.forward * 80;

       
        Destroy(shot, 2.0f);        
    }
	
		void OnTriggerStay(Collider other){
	 if(other.gameObject.tag == "Enemy"){
		//print("Still colliding with trigger object " + other.name);
			
			if (Input.GetKeyUp(k)){
				//float step = speed * Time.deltaTime;
				//transform.position = Vector3.MoveTowards(shot.transform.position, target.position, step);
				Fire();
					//Destroy(other.gameObject);
			}
	}
}
       
		     

}
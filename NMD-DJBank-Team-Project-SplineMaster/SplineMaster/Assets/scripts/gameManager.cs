using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    Vector3 dir;
    public float speed;

    void Start () {
		
	}
	
	void FixedUpdate () {
        dir = transform.localPosition;
        //dir.y = transform.position.y;
        dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);

        
    }
}

using UnityEngine;
using System.Collections;

public class OffsetRoutine : MonoBehaviour {

    public float gravity, jumpForce, offsetSpeed, forwardSpeed = 4.0f;
    public Transform[] trackPath;

    //public Rigidbody spaceCraft;

    private float smoothing = 1.0f;
    
    void Start()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);
    }
	
	void Update () {
        bool isGrounded;

        //iTween.PutOnPath(gameObject, trackPath, 0);

        if (Physics.Raycast(transform.position, -transform.up, 1))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
        if (Input.GetKeyDown("space") && (isGrounded))
        {
            GetComponent<Rigidbody>().AddRelativeForce(transform.up * jumpForce, ForceMode.Impulse);
        }
	}
}

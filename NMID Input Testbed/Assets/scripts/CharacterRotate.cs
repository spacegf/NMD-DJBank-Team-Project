using UnityEngine;
using System.Collections;

public class CharacterRotate : MonoBehaviour {

    public float mouseSensitivity = 0.0f;
    public Vector3 mouseDelta = Vector3.zero;
    private Vector3 prevMouseDelta = Vector3.zero;

    void Update()
    {
        mouseDelta = (Input.mousePosition - prevMouseDelta) * mouseSensitivity;
        prevMouseDelta = Input.mousePosition;
        float rotZ = mouseDelta.x * Mathf.Deg2Rad;
        transform.Rotate(Vector3.forward, -rotZ);
    }
}

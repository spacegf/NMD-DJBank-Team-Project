using UnityEngine;
using System.Collections;

public class mouseRotate : MonoBehaviour
{

    [SerializeField] private float rotateSpeed;

    void Update()
    {
        transform.Rotate(Vector3.left, rotateSpeed * Input.GetAxis("Mouse ScrollWheel"));
    }
}
using UnityEngine;
using System.Collections;

public class EnvSpin : MonoBehaviour
{

    public float speed = 0.0f;

    void Update()
    {
        transform.Rotate(Vector3.back, speed * Time.deltaTime);
    }
}

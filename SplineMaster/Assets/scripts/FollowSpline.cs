using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//move along spline when not in runtime

//script mostly adapted from Unite 2015 presentation by Joachim Holmer

[RequireComponent(typeof(Spline))]//links it to the Spline Extrusion plugin
public class FollowSpline : MonoBehaviour {

    public GameObject follower;
    public Spline spline;
    public float DurationInSecond;
    
    private float rate = 0;//rate based on increasing by deltatime to control percentage along spline

    private void OnEnable()
    {    
        //align follower to the spline
        follower.transform.localRotation = Quaternion.identity;
        follower.transform.localPosition = Vector3.up;
        follower.transform.localScale = Vector3.one;

        //assign spline component
        spline = GetComponent<Spline>();
    }

    void Update()
    {
        //when follower reaches the end of the spline, return to start
        if (rate > spline.nodes.Count - 1)
        {
            rate -= spline.nodes.Count - 1;
        }

        //calculate velocity between nodes along the spline
        rate += Time.deltaTime / DurationInSecond;

        //align camera rig to spline at a location based on percentage, then get the heading of the camera rig by calculating the tangent along the bezier curve
        follower.transform.localPosition = spline.GetLocationAlongSpline(rate);
        follower.transform.localRotation = CubicBezierCurve.GetRotationFromTangent(spline.GetTangentAlongSpline(rate));
    }
}

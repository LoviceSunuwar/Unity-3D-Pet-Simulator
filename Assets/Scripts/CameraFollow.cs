using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // How far to keep the camera positioned
    public float distance;
    // How high the camera is to be
    public float height;
    // Do you want it to follow instantly or sometime later, kind of like a cmaeraman
    public float smoothness;
    // A target to follow, we are using transfomr because transfomr is something that has a postion XYZ
    public Transform target;

    // So notice we are not using public here, so this means that this will not be availbale in the unity engine.
    Vector3 velocity;

    // fixedupdate will always runs on a fixed framerate
    // we can use this when we operate on physical objects i.e rigid body, fixed gravity,or physics
    // we also have late object which runs after the objects moved
    // Here we will be using lateupdate os that when the pet moves, the camera will follow afterwards making it look like a cameraman following the pet
    void LateUpdate()
    {
        Vector3 pos = Vector3.zero;
        pos.x = target.position.x; // this will always center the character in the middle to the camera
        pos.y = target.position.y + height; // This is the height position of te cat, and height which is the posiotion of the camera
        pos.z = target.position.z - distance; // how far or how close the camera will follow

        //vector3.smoothdamp takes in parameters such as vector3 current, vector 3 target, ref vector3 current velocity
        // float, smoothtime,
        // we are not using speed , because there is a speed default in the smoothdamp
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness);

    }


    
}

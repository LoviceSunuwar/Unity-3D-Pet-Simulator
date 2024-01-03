/* Scripted by Omabu - omabuarts@gmail.com */
using UnityEngine;
using System.Collections.Generic;

public class RotateOnScroll : MonoBehaviour
{
    public float rotationSpeed = 2000f;

    void Update()
    {
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheelInput != 0f)
        {
            float rotationAmount = scrollWheelInput * rotationSpeed * Time.deltaTime * 10;
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }
}

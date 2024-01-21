using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Creating a Touch Type Variable which is a unity provided class, That allows the user interaction based on toucj
    private Touch playerTouch;
    public float playerspeed;
    public float posXmin;
    public float posXmax;

 

    // Update is called once per frame
    void Update()
    {
        // This is the number of places where the user touches the screen,
        // So here, We are looking if the user has atleast one finger on the screen we will start the movement of the cube.
        if (Input.touchCount > 0)
        {
            playerTouch = Input.GetTouch(0); // We will get the first touch of the user. 0 indicates first.

            // we are testing if the user moves the finger
            if (playerTouch.phase == TouchPhase.Moved) // Phase is the different possible states.
            {
                // If the phase moved has happened we will move the player following the movement of the finger,
                //transform.position allows you to accesss the position of the cuber, It is in the transform on the inspector when you select a game object.
                // now we create new Vector3. Vector3 is the X Y Z axis values.
                // Delta position gives us the position of the last touched pixel
                transform.position = new Vector3(
                    transform.position.x + playerTouch.deltaPosition.x * playerspeed,
                    transform.position.y,
                    transform.position.z
                    );
            }
        }

        // Keeping the cube in the path on the x axis

        if(transform.position.x < posXmin)
        {
            transform.position = new Vector3(
                     posXmin,
                     transform.position.y,
                     transform.position.z
                     );
        }

        if (transform.position.x > posXmax)
        {
            transform.position = new Vector3(
                     posXmax,
                     transform.position.y,
                     transform.position.z
                     );
        }
    }
}

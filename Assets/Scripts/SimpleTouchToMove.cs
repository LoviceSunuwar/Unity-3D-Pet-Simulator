using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTouchToMove : MonoBehaviour
{
    Touch touch;
    // To know where the player finger is to move the character in the game

    // Now, even though our game is 3D, We know that the button or the UI represented is in 2D hence we are using vector 2D

    Vector2 initPos;
    Vector2 direction;

    public CharacterController petController; // This is a unity component that provides us the access to control the character, moving the character or climbing on a 45 degree slope but more than that is impossible.

    Vector3 moveDirection; // Even though we have created moving buttons as Vector2, but our character that is in game is in a 3D world, so we will be using Vector3

    public float petSpeed = 5.0f; // This is a movement speed, while we are giving it default but we can change it in the Unity IDE

    bool canMove = false; // I only want the pet to move when the user is touching the screen, which means that the character can only move when the player is touching the screen.

    public float gravity = -9.8f; // We are providing a basic gravity, since our 3D world pet has the ability to jump ( Y Axis )


    void Update()
    {
        if (Input.touchCount > 0 ) // Chcek if there is a input. 
        {
            canMove = true;

            // Calculation of the movement of character.


        } else
        {
            canMove = false;
            moveDirection = Vector3.zero; // So, that there are no movement
        }
    }
}

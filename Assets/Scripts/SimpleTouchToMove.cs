using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTouchToMove : MonoBehaviour
{

    //public GameManager foxyGM;
    Touch touch;
    // To know where the player finger is to move the character in the game

    // Now, even though our game is 3D, We know that the button or the UI represented is in 2D hence we are using vector 2D

    Vector2 initPos;
    Vector2 direction;

    public CharacterController petController; // This is a unity component that provides us the access to control the character, moving the character or climbing on a 45 degree slope but more than that is impossible.

    Vector3 moveDirection; // Even though we have created moving buttons as Vector2, but our character that is in game is in a 3D world, so we will be using Vector3

    public float petSpeed = 5.0f; // This is a movement speed, while we are giving it default but we can change it in the Unity IDE

    bool canMove = false; // I only want the pet to move when the user is touching the screen, which means that the character can only move when the player is touching the screen.

    public float gravity = 9.8f; // We are providing a basic gravity, since our 3D world pet has the ability to jump ( Y Axis )

    public float jumpForce = 3.0f;

    public float stopForce = 2f;

    public Animator petAnimator;

    public GameObject jumpeffect;

    public GameManager gameManager;


    private void Awake()
    {
        float bonusSpeed = 0.1f * PlayerPrefs.GetInt("speedLevel", 1);
        petSpeed = petSpeed + bonusSpeed;
    }


    void Update()
    {
        if (!gameManager.isGameEnded && gameManager.isGameStarted)
        {
            if (Input.touchCount > 0 ) // Chcek if there is a input. 
        {
            canMove = true;

            // Calculation of the movement of character.

            touch = Input.GetTouch(0); // This is the first finger touched by the user
            if(touch.phase == TouchPhase.Began)
            {
                initPos = touch.position;
            }
            // Checking if the finger has moved in the screen

            if (touch.phase == TouchPhase.Moved)
            {
                direction = touch.deltaPosition; // The finger position oon the screen
            }

            // The pet shall move only w
            // hen it is only in the ground

            if(petController.isGrounded)
            {
                // Calculation of direction of movement.
                moveDirection = new Vector3(
                    // Here, touch.position.x axis gives us the position of the x axis that the player is touching at present
                    // while initPos is the x axis where the player had thier finger on the start 
                    touch.position.x - initPos.x, // X
                    0, // Y
                    touch.position.y - initPos.y // Z -> we are using Z axis as Y becuase the touch only has 2 cordinated X and Y.
                    // So we are passing the Y axis of Vector2 as Z axis on Vector3

                    );

                // Calculation of the rotation
                // to look at the direction the player is moving the pet

                // Quaternion is a variable that allows to store the inofrmation of rotation
                // Look roation allows the forward vector to look at the direction of th movement.
                // This is a tenary operation where ? shows the "if" and ":" Shows the else part
                print(moveDirection);
                Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation; // This is if else statement 

                // applying the rotation
                transform.rotation = targetRotation;
                // Normalized makes the vector one unit,
                // in order to have a constant run speed on the game 
                moveDirection = moveDirection.normalized * petSpeed;
            }

        } else
        {
            canMove = false;
            //moveDirection = Vector3.zero; // So, that there are no movement// Commenting this because the character cannot jump since after the user stops touching the screen then the vector3 is set to zero hence unable to jump.

            moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, Time.deltaTime * stopForce); // Lerp allows us to transit between a state A and State B)

        }

        // Animation integration

        petAnimator.SetBool("canWalk", canMove); // Here, we are accesing the Animtor on unity, Using setBool which takes in 2 poaramenters, first is the name of the parameter and second is what we want to assign to the parameter
        // here canWalk is a parameter, we created on the animator and we are assinging the canMove bool that we hhave so that the pet moves when the player moves animtion


        // Jump integration

        // -> while gettouch is a way to get input of the user, while mouse click is also a touch input since unity understands that it is a touch interface.

        if(Input.GetMouseButtonUp(0) && petController.isGrounded)
            // Here input.getmousebuttonup is when the user releases the cick and (0) definign the which side of the mouse it is.
            // While getmousebuttondown would be clicking on the mouse, for example you could make it shoot.
        {
            Instantiate(jumpeffect, transform.position, Quaternion.identity);
            moveDirection.y += jumpForce;
            // This is just a effect to jump
            //moveDirection += transform.forward;
        }


        // Calculation of gravity


        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Character controller move takes in the direction wher we want to move
       
            petController.Move(moveDirection * Time.deltaTime); // Character movement is to be applied only if the game is started
            
        }
    }
}

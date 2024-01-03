using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Obstacles : MonoBehaviour
{

    public float speed = 15.0f;
    public TextMeshProUGUI text; // This allows us to access the text created on text mess pro
    public GameObject winParticles;
    public Transform winParticlePos;
    public GameObject loseParticles;

    // Start is called before the first frame update
    void Start()
    {

        try
        {
            winParticlePos = GameObject.Find("AvoidedConf").transform;
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        text = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>(); // Gameobject.find serarches for the game object from it's name.
        // we need to have a closure saying that after finding the scoretext get the component which is to be textmeshproUGUI

        
        //The object of type 'Transform' has been destroyed but you are still trying to access it.
    }

    // Update is called once per frame
    void Update()
    {
        // Translate function takes direction which is vector3
        // Time.deltaTime will allow us to calibrate the speed, depending upon the hardware it is running.
        // SO when we multiply by deltatime it will be same no matter the hardware
        transform.Translate(Vector3.back * Time.deltaTime * speed); // By using back the cube will move towawrds the player object
    }

    private void OnCollisionEnter(Collision collision)
        // This is a reserve function in Unity and it fires when the collision is detected
        // it returns the collision <- The object that we collided with
    {
        if (collision.gameObject.name == "Player")
        {
            Instantiate(loseParticles, collision.gameObject.transform.position, Quaternion.identity);
            iTween.PunchScale(collision.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 1.0f);
            Destroy(collision.gameObject, 0.4f); // we are looking for collision in gameobject that is named Player and when a collision occurs,
            // we will destroy the given game object in this case, it is the player
            Destroy(gameObject.GetComponent<Collider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
            Invoke("ReloadLevel", 2);
            
        }

        if (collision.gameObject.name == "Out")
        {
            Instantiate(winParticles, winParticlePos.position, Quaternion.identity);
            int newScore = int.Parse(text.text) + 1;// we are parsing the int value to the text
            text.text = newScore.ToString(); // Making the current score the newscore
            Destroy(gameObject); // Now here, we are not destroying the collided gameobject but rather the game object which will be the obstacle not the Out box
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // We are asking the scene manager to load a newscene, so asks for the name of the scene
                                                                    // but we are getting the active scene the current scene.
    }
}

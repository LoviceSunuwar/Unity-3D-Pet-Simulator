using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Burst.CompilerServices;

public class FoxHitter : MonoBehaviour
{
    public GameObject foxScore;

    public TextMeshPro foxScore3D;

    public GameObject[] hitParticles;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Hittable"))
        {
            print("The fox hit = " + hit.gameObject.name);
            hit.gameObject.tag = "Hitted";
            Rigidbody obj_rb = hit.gameObject.GetComponent<Rigidbody>(); // we recovering the component of what the object we touched. the items in the apartment.
            // so that we have the access to the rigidbody properties of the tagged name hitted or hittable or what we interac with.
            HittableObjects ho = hit.gameObject.GetComponent<HittableObjects>();
            HitEffect(obj_rb, hit);
            Score3DEffect(ho);
            GetCoins(ho);


        }
    }

    public void HitEffect(Rigidbody obj_rb, ControllerColliderHit hit)
    {
        // Effect produced when colided
        obj_rb.isKinematic = false;
        obj_rb.AddExplosionForce(50, transform.position + Vector3.down, 10); // its used when a war or fps game when u throw bomb and the objects will propel from the position.
        Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], hit.gameObject.transform.position, Quaternion.identity);
        iTween.PunchScale(foxScore, new Vector3(1.25f, 1.25f, 1.25f), 0.3f);

    }

    public void Score3DEffect(HittableObjects ho)
    {
        int newScore = int.Parse(foxScore.GetComponent<TextMeshProUGUI>().text) + ho.points;
        foxScore.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
        foxScore3D.text = "+" + ho.points;
        Invoke("ResetText3D", 0.5f);
    }

    public void ResetText3D()
    {
        foxScore3D.text = "";
    }

    public void GetCoins(HittableObjects ho)
    {
        int actualCoins = PlayerPrefs.GetInt("nbCoins", 0);
        if(actualCoins + ho.coins > 9999999)
        {
            PlayerPrefs.SetInt("nbCoins", 9999999);
        } else
        {
            PlayerPrefs.SetInt("nbCoins", actualCoins + ho.coins);
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightsaber : MonoBehaviour
{
    public bool lightsaberON;

    //To access SoundManager
    public bool saberHit;
    public bool saberClash;

    //Time after sabers hitting each other
    float clashTime = 0.17f;

    public GameObject saberHum;
    public GameObject saberClose;

    Vector3 saberOpenClose;
    float socValue = 0.04f;

    public Slider rotate;
    public Slider position;

    public AudioSource AS;
    public AudioClip hit;

    void Start()
    {
        lightsaberON = true;
        saberHum.SetActive(true);

        saberOpenClose = new Vector3(0, socValue, 0);
    }

    void Update()
    {
        if(lightsaberON == true)
        {
            saberHum.SetActive(true);
            saberClose.transform.localScale += saberOpenClose;

            if (saberClose.transform.localScale.y >= 1.0f)
            {
                saberClose.transform.localScale = new Vector3(1, 1, 1);
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
        if (lightsaberON == false)
        {
            saberHum.SetActive(false);
            saberClose.transform.localScale -= saberOpenClose;

            if(saberClose.transform.localScale.y <= 0.0f)
            {
                saberClose.transform.localScale = new Vector3(1, 0, 1);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }

        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -rotate.value);

        this.gameObject.transform.position = new Vector3(position.value, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

        if(saberHit == true)
        {
            clashTime -= Time.deltaTime;
            if(clashTime <= 0f)
            {
                clashTime = 0f;
                saberClash = true;
            }
        }
    }

    public void SaberOn()
    {
        lightsaberON = !lightsaberON;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Saber" && lightsaberON == true)
        {
            AS.PlayOneShot(hit);
            saberHit = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        saberHit = false;
        saberClash = false;
        clashTime = 0.17f;
    }
}

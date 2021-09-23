using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip saberOnJedi, saberOnSith, saberOffJedi, saberOffSith, saberClash, saberSwing;
    static AudioSource AS;
    bool SithBool, JediBool;

    public Lightsaber jedi, sith;
    [SerializeField] static SoundManager instance;

    void Start()
    {
        AS = GetComponent<AudioSource>();
        JediBool = true;
        SithBool = true;
    }

    void Update()
    {
        if (jedi.saberClash == true && sith.saberClash == true && JediBool == true && SithBool == true)
        {
            AS.PlayOneShot(saberClash);
        }
    }

    public void OnOff(string Name)
    {
        if (Name == "Jedi")
        {
            JediBool = !JediBool;

            if (JediBool == true)
            {
                AS.PlayOneShot(saberOnJedi);
            }
            else
            {
                AS.PlayOneShot(saberOffJedi);
            }
        }
        else if (Name == "Sith")
        {
            SithBool = !SithBool;

            if (SithBool == true)
            {
                AS.PlayOneShot(saberOnSith);
            }
            else
            {
                AS.PlayOneShot(saberOffSith);
            }
        }
    }

    public void SaberSwing()
    {
        if(JediBool == true || SithBool == true)
        {
            AS.PlayDelayed(0.02f);
        }
    }
}

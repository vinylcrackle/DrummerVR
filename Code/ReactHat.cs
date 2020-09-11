using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactHat : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource sound;
    float colVel = 0.5f;
    float max = 0;

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Stick")
        {
            colVel = col.relativeVelocity.magnitude;
            if (colVel > max)
                max = colVel;
            colVel = colVel / max;
            //if (colVel < 0.3)
            //  colVel = 0.3f;
            Debug.Log(colVel);
            sound.volume = Mathf.Abs(colVel);
            PlaySound();
        }
    }

    void PlaySound()
    {
        GameObject soundP = new GameObject("SoundPlayer");
        soundP.AddComponent<AudioSource>();
        soundP.AddComponent<PlayStatus>();
        AudioSource current = soundP.GetComponent<AudioSource>();
        current.playOnAwake = false;
        current.clip = clip;
        current.Play();
        soundP.transform.parent = this.transform;
    }
}

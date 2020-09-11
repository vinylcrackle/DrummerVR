using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiHatScore : MonoBehaviour {
    public bool note = false;
    public bool startmusic = false;
    bool passed = false;
    bool counted = false;
    string chk = "0";
    string name;
    public int HatsScore,HatsMissed;
    public GameObject GoodHitFX;
    public GameObject WrongHitFX;
    GameObject Link;
    public float HatsSoundLevel = 1;
    int fxCount = 1;
	
	
    void Start () {
        HatsScore = 0;
        HatsMissed = 0;
        name = chk;
        
    }
	
	void Update () {
        GameObject handler = GameObject.Find("HiHat");
        StickDetect SD = handler.GetComponent<StickDetect>();
        if (SD.touch && note && !counted)
        {
            SD.touch = false;
            counted = true;
            HatsScore += 1;
            Destroy(Link);
            Instantiate(GoodHitFX, transform.position, transform.rotation);
            HatsSoundLevel += 0.3f;
            if (HatsSoundLevel >= 1)
                HatsSoundLevel = 1;
            fxCount = 0;
        }
        else if(SD.touch&&!note)
        {
            if (fxCount == 0)
            {
                Instantiate(WrongHitFX, transform.position, transform.rotation);
                fxCount = 1;
            }
        }

	}
	
    void Fixedupdate()
    {
        if (note)
            startmusic = true;
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "HAT")
        {
            startmusic = true;
            //if (!passed)
            //{
            counted = false;
            note = true;
            passed = true;
            Link = trigger.gameObject;
            name = gameObject.name;
            //}
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "HAT")
        {
            note = false;
            passed = false;
            HatsMissed += 1;
            Debug.Log("Hats Missed = " + HatsMissed);
            HatsSoundLevel -= 0.3f;
            if (HatsSoundLevel <= 0.2f)
                HatsSoundLevel = 0.2f;
        }
    }

    }

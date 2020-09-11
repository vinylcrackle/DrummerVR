using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatsnotes : MonoBehaviour {

    public GameObject x2;
    Vector3 starttransform;
    Vector3 endtransform;
    float distance;
    bool printed = false;
    float elapsed = 0;
    float speed = 4.0f;
    private float starttime;
    public double duration;
    float t = 0;
    bool hatin = false;
    bool destroyed = false;
    bool ReachedEnd = false;
    string a; //STORE THE NAME OF THE GAMEOBJECT THIS SCRIPT IS ATTACHED TO

    void Start()
    {
        a = gameObject.transform.name; //get the name of the gameobject this script is attached to
        a = a.Substring(0, a.Length - 7);  //Remove the "(Clone)" part from the name string
        int tick = System.Int16.Parse(a);   //convert the name to Int to use it as index FOR NOTETIMINGS
        x2 = GameObject.Find("HatsEnd"); //Access the gameObject EndPos which represents the end position
        GameObject handler = GameObject.Find("SpawnPos"); //Access the gameObject SpawnPos which contains the script that has the notetimings array
        hatsanalyze HatsAna = handler.GetComponent<hatsanalyze>(); //REFERENCE the movewithtime script
        duration = HatsAna.notetimings[tick]; //Access notetimings variable from movewithtime script
        starttransform = transform.position;
        endtransform = x2.transform.position;
        distance = Vector3.Distance(starttransform, endtransform);
    }

    void FixedUpdate()
    {

    }

    void Update()
    {
        GameObject resetManager = GameObject.Find("SM"); //Check if controller has hit the snare drum
        toRockR sceneload = resetManager.GetComponent<toRockR>();
        if (sceneload.DestroyHats)
        {

            Destroy(gameObject);
        }
        GameObject handler = GameObject.Find("StickR"); //Access the gameObject SpawnPos which contains the script that has the notetimings array
        SyncMaster SM = handler.GetComponent<SyncMaster>(); //REFERENCE the movewithtime script
        if (SM.AllSystemsGo)
        {

            if (!ReachedEnd)
            {

                t += Time.deltaTime / (float)duration;
                transform.position = Vector3.Lerp(starttransform, endtransform, t);
            }
            // Destroy(gameObject);
            if (gameObject.transform.position == endtransform)
            {
                SM.MusicFlag = true;
                GameObject handler3 = GameObject.Find("EndPos"); //Check if controller has hit the snare drum
                ScoreManSnare SMS = handler3.GetComponent<ScoreManSnare>();
                //SMS.note = false;
                //SMS.passed = false;
                ReachedEnd = true;
                //Destroy(gameObject);
            }
            if (ReachedEnd && !destroyed)
            {
                GameObject handler2 = GameObject.Find("DestroyPlane"); //Check if controller has hit the snare drum
                transform.position = Vector3.MoveTowards(gameObject.transform.position, handler2.transform.position, 0.3f * Time.deltaTime);
                //Debug.Log("Move IT");
            }
        }

       /* ////////OLD
        t += Time.deltaTime / (float)duration;
            float distancecovered = (Time.time - starttime) * speed;
            float perc = distancecovered / distance;
            transform.position = Vector3.Lerp(starttransform, endtransform, t);
            if (gameObject.transform.position == endtransform)
            {
                SM.MusicFlag = true;
               // Destroy(gameObject);
            }/////////OLDDD*/
        }
    }

/*    private void OnTriggerEnter(Collider other)
    {
        GameObject handler = GameObject.Find("SpawnPos"); //Access the gameObject SpawnPos which contains the script that has the notetimings array
        DetectHats detect = handler.GetComponent<DetectHats>(); //REFERENCE the movewithtime script
        hatin = true;
        if (Input.GetKey(KeyCode.H) && hatin) //Replace KeyCode with collider from VR
        {
            Debug.Log("Hat Hit");
            hatin = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject handler = GameObject.Find("SpawnPos"); //Access the gameObject SpawnPos which contains the script that has the notetimings array
        DetectHats detect = handler.GetComponent<DetectHats>(); //REFERENCE the movewithtime script
        detect.hats = false;
    }*/
//}

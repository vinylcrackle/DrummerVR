using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatsAnalyze : MonoBehaviour {

    public string txtFile = "hats";
    public double[] note_start; //Note Start Timings
    public double[] note_end;   //Nore End Timings
    public double[] notetimings;    //Note Occurance Timings
    public double[] par;    //Parsed Data From TXT File
    int notecount = 0;  //How many note occurances there will be, read from txt file.
    public GameObject x1; //Start Pos
    public GameObject x2; //End Pos
    [SerializeField]
    public GameObject cube;
    AudioSource audiodata;
    AudioSource audiodata2;
    GameObject[] cu; //array that contains the gameobjects created in spawn function, these gameobjects represent the notes
    public int destroyed = 0; //Store how many notes have been spawned and destroyed
    public bool reset = false; //Tell the notes script to count how many are destroyed
    public int lastindex = 0;  //keep track of where the spawn stopped
    int spawned = 0;    //count how many spawned
    int totspawned = 0;
    bool dontSpawn = true; 
    
    void Start()
    {
        audiodata = GetComponent<AudioSource>();
        audiodata2 = GetComponent<AudioSource>();
        ///// EXTRACT TIMINGS FROM TXT FILE
        TextAsset txtAsset = (TextAsset)Resources.Load(txtFile);
        var TestText = txtAsset.text;
        var codeq = txtAsset.text.Split("\n"[0]);
        
        int size = codeq.Length;
        
        par = new double[codeq.Length];
    
        for (int i = 0; i < codeq.Length; i++)
        {
            par[i] = System.Convert.ToDouble(codeq[i]); //Had to store then check the values.
        }
        for (int i = 0; i < codeq.Length; i++)
        {
            //print(par[i]);
            if (par[i] == 4) //4 indicates the begining of a MIDI Note
            {
                notecount++;    //Counting how many notes there is
            }
        }
        cu = new GameObject[notecount];
        note_start = new double[notecount];
        note_end = new double[notecount];
        int note = 0;
        int note2 = 0;
        for (int i = 0; i < codeq.Length; i++)
        {
            //print(par[i]);
            if (par[i] == 4)    //4 indicates the begining of a MIDI Note
            {
                note_start[note] = par[i + 1];
                note++;
            }
            else if (par[i] == 3) //3 indicates the End of a MIDI Note
            {
                note_end[note2] = par[i + 1];
                note2++;
            }
        }
        
        notetimings = new double[notecount];
        for (int i = 0; i < notecount; i++)
        {

            for (int k = 0; k <= i; k++)
            {
                notetimings[i] += note_start[k];
            }

            for (int k = 0; k <= i - 1; k++)
            {
                notetimings[i] += note_end[k];
            }

        }
        ////////END OF NOTE TIMING EXTRACTION///////////////////////////////////


        Spawn(); //Create cubes equal to the number of notes there is

    }

    // Update is called once per frame
    void Update()
    {
        GameObject resetManager = GameObject.Find("SM"); //Check if controller has hit the snare drum
        toRockR sceneload = resetManager.GetComponent<toRockR>();
        if (sceneload.DestroyHats)
        {
                if (!GameObject.FindWithTag("HAT"))
                {
                    sceneload.DestroyHats = false;
                    dontSpawn = false;
                   // break;

                }
        }

        if (sceneload.loadHats && !dontSpawn)
        {
            Debug.Log("Spawned Hats again");
            Spawn();
            sceneload.loadHats = false;
            dontSpawn = false;
        }
    }
  

    private void Spawn()
    {
        for (int i = 0; i < notecount; i++)
        {
            cube.name = System.Convert.ToString(i);
            cu[i] = Instantiate(cube, x1.transform.position, x1.transform.rotation);
            cu[i].AddComponent<hatsnotes>(); //attach "cube" script to the game object
        }
        GameObject handler = GameObject.Find("StickR"); //Access the gameObject SpawnPos which contains the script that has the notetimings array
        SyncMaster SM = handler.GetComponent<SyncMaster>(); //REFERENCE the movewithtime script
        SM.status[3] = true;
    }

    private void SpawnInit()
    {

        for (int i = 0; i < 50; i++)
        {
            cube.name = System.Convert.ToString(i);
            cu[i] = Instantiate(cube, x1.transform.position, x1.transform.rotation);
            cu[i].AddComponent<hatsnotes>(); //attach "cube" script to the game object
            spawned += 1;
            lastindex = i;
            totspawned += 1;
        }
        reset = true;
        destroyed = 0;
    }


}

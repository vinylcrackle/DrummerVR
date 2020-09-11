using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncMaster : MonoBehaviour
{
    //private static SyncMaster _SyncInstance;

    int stickCount = 0;
    public bool PlayerReady = false;
    public bool AllSystemsGo = false;
    bool ScriptsAreReady = false;
    bool Played = false;
    public bool[] status = new bool[4];    //Check Status On Each of the Scripts
    public bool MusicFlag = false;
    //Audio Players
    public AudioSource[] Players;
    AudioSource SnarePlayer;
    AudioSource GTR;
    AudioSource HatsPlayer;
    AudioSource KickPlayer;
    AudioSource CrashPlayer;
    bool PlayedGTR = false;
    public bool PlayBackStatus = true;
    int PlayersStopped=0;
    private void Awake()
    {
       /* Players = GetComponents<AudioSource>();
        SnarePlayer = Players[0];
        GTR = Players[1];
        HatsPlayer = Players[2];
        KickPlayer = Players[3];*/
    }
    void Start()
    {
        Players = GetComponents<AudioSource>();
        SnarePlayer = Players[1];
        GTR = Players[0];
        HatsPlayer = Players[3];
        KickPlayer = Players[2];
        CrashPlayer = Players[4];
        for (int i = 0; i < 4; i++)
            status[i] = false;
        stickCount = 0;
    }
    private void FixedUpdate()
    {

    }

    void Update()
    {
        Debug.Log("STICK " + stickCount);
        if (stickCount == 3)
        {
            PlayerReady = true;
            AllSystemsGo = true;
        }
       /* if (PlayerReady)
            CheckScripts();
        if (ScriptsAreReady)
            AllSystemsGo = true;*/
        if (AllSystemsGo && !Played) //Method to Sync Music Playback with notes arrival
        {

                GTR.Play(0);
                SnarePlayer.Play(0);
                HatsPlayer.Play(0);
                KickPlayer.Play(0);
                CrashPlayer.Play(0);
                PlayedGTR = true;
                Played = true;
                
            //Played = true;
            /*GameObject Col = GameObject.Find("HatsEnd"); //Check if controller has hit the snare drum
            ScoreManager AS = Col.GetComponent<ScoreManager>();
            if (AS.startmusic)    //Check for the first time the a note collides with the snare drum and at that moment start playback of audio tracks.
            {

                //SnarePlayer.Play(0);
                //GTR.Play(0);
                Debug.Log("PLAYED");
                //HatsPlayer.Play(0);
                //KickPlayer.Play(0);
                //Played = true;
            }*/
        }
        if(Played)
     for(int i=0;i<5;i++)
        {
            if (!Players[i].isPlaying)
                PlayersStopped++;
        }
        if (PlayersStopped >=4)
            PlayBackStatus = false;
        Debug.Log(PlayBackStatus);
    }
    
    void LateUpdate()
    {
       
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Stick")
            stickCount += 1;
    }
    void CheckScripts()
    {
        if (status[2] == true)
            ScriptsAreReady = true;
        //return;
    }

    void SoundLevel()
    {
        GameObject Hat = GameObject.Find("HatsEnd"); //Get SoundLevel info. from Hats Score Manager
        ScoreManager SM = Hat.GetComponent<ScoreManager>(); //Link to ScoreManager Script which handles detection of Hats hits
        HatsPlayer.volume = SM.HatsSoundLevel;

        GameObject Snare = GameObject.Find("EndPos"); //Get SoundLevel info. from Hats Score Manager
        ScoreManSnare SMS = Snare.GetComponent<ScoreManSnare>(); //Link to ScoreManSnare Script which handles detection of Snare hits
        SnarePlayer.volume = SMS.SnareSoundLevel; //Access the variable that stores sound level info. and apply it to the corresponding player

        GameObject Kick = GameObject.Find("KickEnd"); //Get SoundLevel info. from Hats Score Manager
        KickScore KS = Kick.GetComponent<KickScore>(); //Link to KickScore Script which handles detection of Kick hits
        KickPlayer.volume = KS.KickSoundLevel; //Access the variable that stores sound level info. and apply it to the corresponding player
    }
}

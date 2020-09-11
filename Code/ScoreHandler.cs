using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour {
    public int ComboCounter,CurrentScore;
    public int MissedScore, CurrentScoreOld=0,MissedScoreOld = 0,HighestMissed=0;


    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        GameObject Hat = GameObject.Find("HatsEnd"); //Script Name ScoreManager , Variable name HatsScore
        GameObject Snare = GameObject.Find("EndPos"); //Script Name ScoreManSnare , Variable name SnareScore
        GameObject Kick = GameObject.Find("Bass"); //Script Name KickScore, Variable name KickScore
        GameObject Cymbal = GameObject.Find("CymbalDetect"); //Script Name CymbalScore
        ScoreManager HatsScore = Hat.GetComponent<ScoreManager>();
        ScoreManSnare SnareScore = Snare.GetComponent<ScoreManSnare>();
        KickScore KScore2 = Kick.GetComponent<KickScore>();
        CymbalScore CScore = Cymbal.GetComponent<CymbalScore>();
        CurrentScore = SnareScore.SnareScore + HatsScore.HatsScore + KScore2.KScore +CScore.CrashScore;
        MissedScore = SnareScore.Snaremissed + HatsScore.HatsMissed+KScore2.KickMissed+CScore.CrashMissed;
        if (MissedScore > HighestMissed)
            HighestMissed = MissedScore;
        Combo();
        MissedScoreOld = MissedScore;
        CurrentScoreOld = CurrentScore;
        //Debug.Log(CurrentScore);
    }

    void Combo()
    {
        if (MissedScore > MissedScoreOld) //Combo is lost
            ComboCounter = 0;
        else //Combo is alive
        {
            if(CurrentScoreOld!=CurrentScore) //This means there was a right hit
            {
                ComboCounter++;
            }
        }
    }
}

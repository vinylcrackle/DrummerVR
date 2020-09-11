using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour {
    private TextMeshProUGUI Text;
    int score, ComboScore,missed,MissedMax;
    string Noob = "NooB!!";
    string Step = "1,2 Step";
    string Groovy = "Groovy !!";
    string Guru = "Rythym Guru!!";
    // Use this for initialization
    void Start () {
        Text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update () {

        GameObject handler = GameObject.Find("ScoreHandler");
        ScoreHandler SH = handler.GetComponent<ScoreHandler>();
        score = SH.CurrentScore;
        missed = SH.MissedScore;
        MissedMax = SH.HighestMissed;
        ComboScore = SH.ComboCounter;
        Text.text = "Combo : " + ComboScore.ToString();
        if(gameObject.name=="ScoreText")
        {
            Text.text = "Score : " + score.ToString();
        }
        if (gameObject.name == "TotScore")
        {
            Text.text = "TotScore : " + score.ToString();
        }
        if (gameObject.name == "Missed")
        {
            Text.text = "You Missed : " + missed.ToString()+" Notes";
        }
        if (gameObject.name == "GrooveMeter")
        {
            if(MissedMax>5)
                Text.text = "GrooveMeter Says: " + Noob;
            else if (MissedMax>0&&MissedMax<=3)
                Text.text = "GrooveMeter Says: " + Step;
            else if (MissedMax > 0 && MissedMax <= 2)
                Text.text = "GrooveMeter Says: " + Groovy;
            else if (MissedMax >= 0 && MissedMax <= 1)
                Text.text = "GrooveMeter Says: " + Guru;
        }


    }

  
}

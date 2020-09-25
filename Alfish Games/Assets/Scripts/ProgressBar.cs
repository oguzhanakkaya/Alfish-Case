using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Text CurrentLevelText, NextLevelText;
    public Image CP1, CP2;
    public int NextLevel;
    public int CheckPoint;
    public string Sitution;
    public GameObject Gate1, Gate2;
    
    public  static ProgressBar Instance { get; private set; }
    
    void Start()
    {

        SetObject();
        SetLevelText();
        

    }

    
    void Update()
    {
        CheckLevelFinished();
        SetLevelText();
    }

    public void SetObject()
    {
        CP1 = GameObject.Find("CP1").GetComponent<Image>();
        CP2 = GameObject.Find("CP2").GetComponent<Image>();
        CurrentLevelText = GameObject.Find("CurrentLevelText").GetComponent<Text>();
        Gate1 = GameObject.Find("Gate1");
        Gate2 = GameObject.Find("Gate2");
    }

    public void SetLevelText()
    {
        CurrentLevelText.text = PlayerPrefs.GetInt("CurrentLevel",0).ToString();
        NextLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        NextLevel += 1;
        NextLevelText.text = NextLevel.ToString();
    }

    public void LevelPass()
    {
        var level = PlayerPrefs.GetInt("CurrentLevel", 0);
        level += 1;
        PlayerPrefs.SetInt("CurrentLevel",level);
        CP1.color = Color.white;
        CP2.color = Color.white;
        CheckPoint = 0;
    }


    public void CheckPointPass()
    {
        CheckPoint += 1;
        
        if (CheckPoint==1)
        {
            CP1.color = Color.red;
            Gate1.GetComponent<OpenGate>().enabled = true;
        }
        else if (CheckPoint==2)
        {
            CP2.color = Color.red;
            Gate2.GetComponent<OpenGate>().enabled = true;
        }
    }

    public void CheckLevelFinished()
    {
        if (CP1.color == Color.red && CP2.color == Color.red)
        {
            Sitution = "Finish";
        }
    }
}

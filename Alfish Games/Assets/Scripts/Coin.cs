using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text cointext;
    void Start()
    {
        cointext = GetComponent<Text>();
    }

    
    void Update()
    {
        cointext.text = PlayerPrefs.GetInt("Coin", 0).ToString();
    }
    
}

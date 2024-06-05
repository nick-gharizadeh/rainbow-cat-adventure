using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOverSceneManager : MonoBehaviour
{
    void Start()
    {
        int FinalScore = PlayerPrefs.GetInt("FinalScore", 0);
        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = FinalScore.ToString();
    }

    void Update()
    {
        
    }
}

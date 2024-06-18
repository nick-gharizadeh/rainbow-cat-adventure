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
        PlayAudioSource("game-over");
    }


    void PlayAudioSource(string audioClipName)
    {
        AudioSource audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Sounds/" + audioClipName);
        audioSource.Play();

    }
}

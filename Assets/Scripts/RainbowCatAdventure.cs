using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RainbowCatAdventure : MonoBehaviour
{
    List<string> colors = new List<string> { "black", "blue", "brown", "gray", "green", "orange", "pink", "purple", "red", "yellow" };
    List<string> randomColors = new List<string>();
    int score = 0;
    Hashtable directionWithCats = new Hashtable();
    string rightAnswerColor, rightAnswerDirection;
    private float timer = 5f;

    int lives = 3;

    void Start()
    {
        InitializeGame();
        SetOnClickListenerForImages();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            CheckUserAwnser("Up");

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            CheckUserAwnser("Down");

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            CheckUserAwnser("Left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            CheckUserAwnser("Right");
        }
    }




    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>().text = timer.ToString("0.00");
        if (timer <= 2f && timer > 1.95f )
        {
            GameObject.Find("ImageClock").GetComponent<Image>().enabled = true;
            GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>().enabled = true;
            PlayAudioSource("tictoc");
        }
        if (timer <= 0f)
        {
            lives--;
            InitializeGame();
            GameObject.Find("ImageClock").GetComponent<Image>().enabled = false;
            GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>().enabled = false;

        }
        switch (lives)
        {
            case 0:
                GameObject.Find("HeartImage1").GetComponent<Image>().enabled = false;
                PlayerPrefs.SetInt("FinalScore", score);
                SceneManager.LoadScene("GameOverScene");
                break;

            case 1:
                GameObject.Find("HeartImage2").GetComponent<Image>().enabled = false;
                break;

            case 2:
                GameObject.Find("HeartImage3").GetComponent<Image>().enabled = false;
                break;

        }
    }


    void InitializeGame()
    {
        timer = 5f;
        randomColors.Clear();
        directionWithCats.Clear();
        SetRandomCatImages();
        SetColorText();
        IndicateRightAnswer();
    }

    void CheckUserAwnser(string userAwnser)
    {
        if (rightAnswerDirection == userAwnser)
        {
            PlayAudioSource("cute-meow");
            UpdateScore();
            InitializeGame();
        }
        else
        {
            PlayAudioSource("angry-meow");
            lives--;
        }

    }

    void SetOnClickListenerForImages()
    {
        GameObject.Find("CatUp").GetComponent<Button>().onClick.AddListener(() => CheckUserAwnser("Up"));
        GameObject.Find("CatDown").GetComponent<Button>().onClick.AddListener(() => CheckUserAwnser("Down"));
        GameObject.Find("CatRight").GetComponent<Button>().onClick.AddListener(() => CheckUserAwnser("Right"));
        GameObject.Find("CatLeft").GetComponent<Button>().onClick.AddListener(() => CheckUserAwnser("Left"));

    }

    void UpdateScore()
    {
        score += 5;
        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
    }


    void SetColorText()
    {
        int randomNumber = GenerateRandomNumber(0, randomColors.Count);
        rightAnswerColor = randomColors[randomNumber];
        GameObject.Find("ColorText").GetComponent<TextMeshProUGUI>().text = rightAnswerColor.ToUpper();
    }




    void SetRandomCatImages()
    {
        while (randomColors.Count < 4)
        {
            int randomNumber = GenerateRandomNumber(0, colors.Count);
            if (!randomColors.Contains(colors[randomNumber]))
                randomColors.Add(colors[randomNumber]);

        }
        Sprite firstCat = Resources.Load<Sprite>("Sprites/" + randomColors[0] + "-cat");
        Sprite secondCat = Resources.Load<Sprite>("Sprites/" + randomColors[1] + "-cat");
        Sprite thirdCat = Resources.Load<Sprite>("Sprites/" + randomColors[2] + "-cat");
        Sprite fourthCat = Resources.Load<Sprite>("Sprites/" + randomColors[3] + "-cat");

        GameObject.Find("CatUp").GetComponent<Image>().sprite = firstCat;
        GameObject.Find("CatDown").GetComponent<Image>().sprite = secondCat;
        GameObject.Find("CatRight").GetComponent<Image>().sprite = thirdCat;
        GameObject.Find("CatLeft").GetComponent<Image>().sprite = fourthCat;

        directionWithCats.Add("Up", randomColors[0]);
        directionWithCats.Add("Down", randomColors[1]);
        directionWithCats.Add("Right", randomColors[2]);
        directionWithCats.Add("Left", randomColors[3]);


    }

    void IndicateRightAnswer()
    {
        foreach (DictionaryEntry enrty in directionWithCats)
        {
            if (enrty.Value.Equals(rightAnswerColor))
            {
                rightAnswerDirection = enrty.Key.ToString();
            }

        }
    }

    void PlayAudioSource(string audioClipName)
    {
        AudioSource audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Sounds/" + audioClipName);
        audioSource.Play();

    }

    int GenerateRandomNumber(int firstNumber, int lastNumber)
    {
        System.Random random = new System.Random();
        return random.Next(firstNumber, lastNumber);
    }

}

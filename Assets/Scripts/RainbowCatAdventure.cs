using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RainbowCatAdventure : MonoBehaviour
{
    List<string> colors= new List<string> { "black","blue","brown","gray","green","orange","pink","purple","red","yellow" };
    List<string> randomColors = new List<string>();
    Hashtable directionWithCats = new Hashtable();
    string rightAnswerColor , rightAnswerDirection ; 

    void Start()
    {
        SetRandomCatImages();
        SetColorText();
        IndicateRightAnswer();
    }

    void Update()
    {
        
        
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            if (rightAnswerDirection =="Up")
            {
                Console.WriteLine("HIIIIII");
            }

        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            if (rightAnswerDirection =="Down")
            {
                                Console.WriteLine("HIIIIII");

            }
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            if (rightAnswerDirection =="Left")
            {
                Console.WriteLine("HIIIIII");

            }
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            if (rightAnswerDirection =="Right")
            {
                Console.WriteLine("HIIIIII");

            }
            
        }
    }


    


    void SetColorText()
    {
        int randomNumber = GenerateRandomNumber(0, randomColors.Count);
        rightAnswerColor = randomColors[randomNumber];
        GameObject.Find("ColorText").GetComponent<TextMeshProUGUI>().text= rightAnswerColor.ToUpper() ;
    }




    void SetRandomCatImages()
    {
        while (randomColors.Count < 4)
        {
           int randomNumber = GenerateRandomNumber(0, colors.Count);
           if(!randomColors.Contains(colors[randomNumber]))
                randomColors.Add(colors[randomNumber]);

        }
        Sprite firstCat = Resources.Load<Sprite>("Sprites/"+randomColors[0]+"-cat");
        Sprite secondCat = Resources.Load<Sprite>("Sprites/"+randomColors[1]+"-cat");
        Sprite thirdCat = Resources.Load<Sprite>("Sprites/"+randomColors[2]+"-cat");
        Sprite fourthCat = Resources.Load<Sprite>("Sprites/"+randomColors[3]+"-cat");

        GameObject.Find("CatUp").GetComponent<Image>().sprite = firstCat;
        GameObject.Find("CatDown").GetComponent<Image>().sprite = secondCat;
        GameObject.Find("CatRight").GetComponent<Image>().sprite = thirdCat;
        GameObject.Find("CatLeft").GetComponent<Image>().sprite = fourthCat;

        directionWithCats.Add("Up", randomColors[0]);
        directionWithCats.Add("Down", randomColors[1]);
        directionWithCats.Add("Right", randomColors[2]);
        directionWithCats.Add("Left", randomColors[3]);


    }

    void IndicateRightAnswer(){
        foreach (DictionaryEntry enrty in directionWithCats){
            if(enrty.Value.Equals(rightAnswerColor)){
                rightAnswerDirection = enrty.Key.ToString() ; 
            }

        }
    }

    int GenerateRandomNumber(int firstNumber, int lastNumber)
    {
        System.Random  random = new System.Random ();
        return random.Next(firstNumber, lastNumber);
    }
  
}

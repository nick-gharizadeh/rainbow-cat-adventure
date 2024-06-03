using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowCatAdventure : MonoBehaviour
{
    void Start()
    {
        SetRandomCatImges();
    }



    void SetRandomCatImges()
    {
        List<string> cats = new List<string> { "black-cat","blue-cat","brown-cat","gray-cat","green-cat","orange-cat","pink-cat","purple-cat","red-cat","yellow-cat" };
        List<string> randomCats = new List<string>();
        System.Random random = new System.Random();
        for (int i = 1; i <= 4; i++)
        {
            int randomNumber = random.Next(1, cats.Count + 1);
            randomCats.Add(cats[randomNumber]);

        }
        Sprite firstCat = Resources.Load<Sprite>("Sprites/"+randomCats[0]);
        Sprite secondCat = Resources.Load<Sprite>("Sprites/"+randomCats[1]);
        Sprite thirdCat = Resources.Load<Sprite>("Sprites/"+randomCats[2]);
        Sprite fourthCat = Resources.Load<Sprite>("Sprites/"+randomCats[3]);

        GameObject.Find("CatUp").GetComponent<Image>().sprite = firstCat;
        GameObject.Find("CatDown").GetComponent<Image>().sprite = secondCat;
        GameObject.Find("CatRight").GetComponent<Image>().sprite = thirdCat;
        GameObject.Find("CatLeft").GetComponent<Image>().sprite = fourthCat;




    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalGuesser : MonoBehaviour
{
    public AudioClip[] animalSounds;
    public Sprite[] animalSprites;
    public Button playTaskButton;
    public Button[] answerButtons;
    private List<Sprite> uniqueSprites = new List<Sprite>();

    public AudioSource myFX;
    public AudioClip wrongFX;
    public AudioClip rightFX;

    private int correctAnswerIndex;
    private int correctButtonIndex;

    public int numberToWin;
    private int levelProgress;

    public GameObject winCanvas;

    private void Start()
    {
        InitializeTask();
    }

    public void PlaySoundTask()
    {
        myFX.clip = animalSounds[correctAnswerIndex];
        myFX.Play();
    }


    public void InitializeTask()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].image = null;
        }

        uniqueSprites.Clear();

        correctAnswerIndex = Random.Range(0, animalSounds.Length);
        correctButtonIndex = Random.Range(0, answerButtons.Length);

        answerButtons[correctButtonIndex].GetComponent<Image>().sprite = animalSprites[correctAnswerIndex];
        while (uniqueSprites.Count < answerButtons.Length) 
        { 
            Sprite randomSprite = animalSprites[Random.Range(0, animalSprites.Length)];
            if (randomSprite != animalSprites[correctAnswerIndex])
            {
                if (!uniqueSprites.Contains(randomSprite))
                {
                    uniqueSprites.Add(randomSprite);
                }
            }
        }

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i != correctButtonIndex)
            {
                if (uniqueSprites[i] != animalSprites[correctAnswerIndex])
                    answerButtons[i].GetComponent<Image>().sprite = uniqueSprites[i];
            }
        }

    }

    public void CheckWin(int buttonIndex)
    {
        if (buttonIndex == correctButtonIndex)
        {
            Debug.Log("Верно!");
            levelProgress++;
            if (levelProgress != numberToWin)
            {
                InitializeTask();
                myFX.clip = rightFX;
                myFX.Play();
            } else
            {
                Debug.Log("Уровень пройден");
                winCanvas.SetActive(true);
            }
            
        }
        else
        {
            Debug.Log("Неверно!");
            myFX.clip = wrongFX;
            myFX.Play();
        }
    }
}

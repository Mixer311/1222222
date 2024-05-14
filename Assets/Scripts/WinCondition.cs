using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class WinCondition : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public float timeToWin;
    public Image timerBar;
    private float timeleft;

    private void Start()
    {
        timerBar.enabled = true;
        timeleft = timeToWin;
    }
    void Update()
    {
        CheckForWin();
        if (timeleft > 0)
        {
            timeleft -= Time.deltaTime;
            timerBar.fillAmount = timeleft / timeToWin;
        }
        if (timeleft <= 0)
        {
            loseCanvas.SetActive(true);
        }
    }

    public void CheckForWin()
    {
        if(GameObject.FindGameObjectWithTag("Item") == null)
        {
            winCanvas.SetActive(true);
        }
    }
}

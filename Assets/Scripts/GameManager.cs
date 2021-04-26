﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;
   
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] TextMeshProUGUI totalScore;
    [SerializeField] GameObject endGame;
    [SerializeField] GameObject winGame;


    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: "+ score;

        //increase player's speed
        //playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    public void DecreaseScore()
    {
        score--;
        scoreText.text = "Score: " + score;
        
    }
   
   
    
    //This start before anything event start of game
    private void Awake()
    {
        inst = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
         
   
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.alive == false && Timer.timeValue == 0 && score >= 15)
        {
            endGame.SetActive(true);
            endGame.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            endGame.gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            winGame.SetActive(false);
            totalScore.text = "Your Score: " + score;
            scoreText.text = "";
            Invoke("Restart", 2);
        }
       else if(PlayerMovement.alive == false)
        {
            endGame.SetActive(true);
            winGame.SetActive(false);
            totalScore.text = "Your Score: " + score;
            scoreText.text = "";
            Invoke("Restart", 2);

        }
    }

    void Restart()
    {

        PlayerMovement.Restart();
    }

   
}

using System.Collections;
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
        if (score < 0)
        {
           
            PlayerMovement.alive = false;
            endGame.SetActive(true);
            totalScore.text = "Your Score: " + score;

            // restart the game
            GroundSpawner.spawn = false;
            //Invoke("MenuScene", 2);

            Invoke("Restart", 2);

        }
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
        if(PlayerMovement.alive == false)
        {
            endGame.SetActive(true);
            totalScore.text = "Your Score: " + score;
            scoreText.text = "";

        }
    }

    void Restart()
    {

        PlayerMovement.Restart();
    }

   
}

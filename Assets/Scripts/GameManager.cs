using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] Button restartButton;
    [SerializeField] Text endscore;
    [SerializeField] Text gameOver;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Text restart;

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
            playerMovement.Die();
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
        
        restartButton.gameObject.SetActive(false);
        endscore.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
      
   
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.alive == false)
        {
            scoreText.gameObject.SetActive(false);
            //restartButton.gameObject.SetActive(true);
            endscore.gameObject.SetActive(true);
            endscore.text = "Your Score: " + score;
            gameOver.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;

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
        
    }
}

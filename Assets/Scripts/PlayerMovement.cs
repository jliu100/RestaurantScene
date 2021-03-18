using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    
    public float speed = 5;
    [SerializeField] public Rigidbody rb;


    float horizontalInput;     //2a. Add horizontal move
    public float horizontalMultipler = 2;                       //2d: want player move horizontally twice as fast as it moves forward


    public float speedIncreasePerPoint = 0.1f;

    
    //1a. FixUpdate is build in function: runs fix interval known as fixedDeltaTime, default time is 50 times/second
    //moves five units every second rather than everytime the function runs
    private void FixedUpdate()
    {
        if (!alive) return;                //If player not alive skip the folowing functions                                                                       //transform refers to player in this file, cuz we put this script cs under player in unity game
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;    //1b. declare a variable type of vector 3, and we set that equal to 
                                                                                  // transform.forward: direction that player is facing

        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultipler;   //2c. add horizontal move, press a (or left arrow) to move left, press d (or right arrow) to move right
        rb.MovePosition(rb.position + forwardMove + horizontalMove);                                //1c. move player postion

    }

    
    private void Update()  
    {
        
        horizontalInput = Input.GetAxis("Horizontal");       //2d. get the horizontal input

        //If palyer's verticle position (not on tile) is less than negative 5, kill palyer
        if (transform.position.y < -5)
        {
            Die();     
        }
    }

    public void Die()
    {
        alive = false;
        // restart the game
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//kill palyer when collision between player and obstacles
public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //kill player
           
            PlayerMovement.alive = false;
            GroundSpawner.spawn = false;
            Destroy(gameObject);

            Invoke("Restart", 2);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Restart()
    {
        PlayerMovement.Restart();
    }
}

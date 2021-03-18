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
            playerMovement.Die();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerMovement.alive == false)
            return;

        if(other.gameObject.GetComponent<Obstacle>() != null)        //To fix some coin spawn inside the obstacles
        {
            Destroy(gameObject);
            return;
        }
        
        // Check object we collide with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Add the player's score

        bool correct = false;
   
        if (other.gameObject.transform.GetChild(2).gameObject.activeSelf && (transform.gameObject.name == "JuicePack_Mid__550_Tris_(Clone)" || transform.gameObject.name == "CerealBox_Mid__400_Tris_(Clone)"))
        {
            correct = true;
        }
        if (other.gameObject.transform.GetChild(3).gameObject.activeSelf && (transform.gameObject.name == "BeerBottle_Mid__620_Tris_(Clone)" || transform.gameObject.name == "Glass(Clone)"))
        {
            correct = true;
        }
        if (other.gameObject.transform.GetChild(4).gameObject.activeSelf && (transform.gameObject.name == "Rotten_cheese(Clone)" || transform.gameObject.name == "Rotten_Meat(Clone)" || transform.gameObject.name == "TomatoHead_169_Tris_(Clone)" || transform.gameObject.name == "Plastic Spoon(Clone)"))
        {
            correct = true;
        }
        if (other.gameObject.transform.GetChild(5).gameObject.activeSelf && (transform.gameObject.name == "KnifeKitchen(Clone)" || transform.gameObject.name == "Pan(Clone)"))
        {
            correct = true;
        }

        if (correct == false)
        {
            GameManager.inst.DecreaseScore();
        }
        else
        {
            GameManager.inst.IncreaseScore();
        }
        //GameManager.inst.IncreaseScore();

        // Destory the coin
        Destroy(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0,  rotateSpeed * Time.deltaTime,0);  // coin will always rotate 90 degrees every second regardless of framerate
       
    }
}

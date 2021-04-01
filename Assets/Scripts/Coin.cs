using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
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

        if(other.gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            Debug.Log("True 1");
        }
        if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
        {
            Debug.Log("True 2");
        }
        GameManager.inst.IncreaseScore();

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

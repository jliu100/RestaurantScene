using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public AudioClip bcgMusic;
    // Use this for initialization
    void Start()
    {
        Debug.Log(bcgMusic.ToString());

        AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
    }
}
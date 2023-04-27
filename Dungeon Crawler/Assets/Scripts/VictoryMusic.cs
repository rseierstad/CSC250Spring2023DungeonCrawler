using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMusic : MonoBehaviour
{
    private AudioSource m_MyAudioSource;
    private bool musicPlaying;

    private void Awake()
    {
        this.m_MyAudioSource = this.GetComponent<AudioSource>();
        this.musicPlaying = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MasterControlProgram.victory && this.musicPlaying == false)
        {
            this.m_MyAudioSource.Play();
            this.musicPlaying = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMusic : MonoBehaviour
{
    private AudioSource m_MyAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.m_MyAudioSource = this.GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(MasterControlProgram.victory)
        {
            this.m_MyAudioSource.Play();
        }
    }
}

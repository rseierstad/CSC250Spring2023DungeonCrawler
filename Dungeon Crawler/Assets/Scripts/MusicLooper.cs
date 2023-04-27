using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    private void Awake()
    {
        if(MasterControlProgram.musicLooper == null)
        {
            MasterControlProgram.musicLooper = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MasterControlProgram.victory)
        {
            Destroy(this.gameObject);
        }
    }
}
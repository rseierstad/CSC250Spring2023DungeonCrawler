using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit, southExit, eastExit, westExit;

    public bool northOn, southOn, eastOn, westOn;

    // Start is called before the first frame update
    void Start()
    {
        this.northExit.SetActive(northOn);
        this.southExit.SetActive(southOn);
        this.eastExit.SetActive(eastOn);
        this.westExit.SetActive(westOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

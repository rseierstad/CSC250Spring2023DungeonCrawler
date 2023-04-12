using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit, southExit, eastExit, westExit;
    private Room currentRoom;
    private bool northOn = false;
    private bool southOn = false;
    private bool eastOn = false;
    private bool westOn = false;

    // Start is called before the first frame update
    void Start()
    {
        MasterControlProgram.setupDungeon();

        this.setExits();

        this.northExit.SetActive(this.northOn);
        this.southExit.SetActive(this.southOn);
        this.eastExit.SetActive(this.eastOn);
        this.westExit.SetActive(this.westOn);
    }

    void setExits()
    {
        this.currentRoom = MasterControlProgram.p.getCurrentRoom();
        if(this.currentRoom.hasExit("north"))
        {
            this.northOn = true;
        }
        if(this.currentRoom.hasExit("south"))
        {
            this.southOn = true;
        }
        if(this.currentRoom.hasExit("east"))
        {
            this.eastOn = true;
        }
        if(this.currentRoom.hasExit("west"))
        {
            this.westOn = true;
        }
    }
}

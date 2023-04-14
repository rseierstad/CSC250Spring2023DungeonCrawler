using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit, southExit, eastExit, westExit;
    private Room currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        MasterControlProgram.setupDungeon();

        this.setExits();
    }

    void setExits()
    {
        currentRoom = MasterControlProgram.p.getCurrentRoom();
        if(!currentRoom.hasExit("north"))
        {
            this.northExit.SetActive(false);
        }
        if(!currentRoom.hasExit("south"))
        {
            this.southExit.SetActive(false);
        }
        if(!currentRoom.hasExit("east"))
        {
            this.eastExit.SetActive(false);
        }
        if(!currentRoom.hasExit("west"))
        {
            this.westExit.SetActive(false);
        }
    }
}

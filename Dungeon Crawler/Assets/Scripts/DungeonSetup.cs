using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit, southExit, eastExit, westExit;
    public GameObject northWall, southWall, eastWall, westWall;
    private Room currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        MasterControlProgram.setupDungeon();

        this.northWall.SetActive(false);
        this.southWall.SetActive(false);
        this.eastWall.SetActive(false);
        this.westWall.SetActive(false);

        this.setExits();
    }

    void setExits()
    {
        currentRoom = MasterControlProgram.p.getCurrentRoom();
        if(!currentRoom.hasExit("north"))
        {
            this.northExit.SetActive(false);
            this.northWall.SetActive(true);
        }
        if(!currentRoom.hasExit("south"))
        {
            this.southExit.SetActive(false);
            this.southWall.SetActive(true);
        }
        if(!currentRoom.hasExit("east"))
        {
            this.eastExit.SetActive(false);
            this.eastWall.SetActive(true);
        }
        if(!currentRoom.hasExit("west"))
        {
            this.westExit.SetActive(false);
            this.westWall.SetActive(true);
        }
    }
}

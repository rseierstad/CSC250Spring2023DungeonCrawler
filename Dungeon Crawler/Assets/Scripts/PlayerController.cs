using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public GameObject westStart, eastStart, northStart, southStart;
    public float movementSpeed = 40.0f;
    private bool isMoving;
    private Room currentRoom;
    private float fightRoller;
    public TextMeshProUGUI stats;

    // Start is called before the first frame update
    void Start()
    {
        this.fightRoller = Random.Range(1.0f,10.0f);

        this.rb = this.GetComponent<Rigidbody>();
        this.isMoving = false;

        if(!MasterControlProgram.whereDidIComeFrom.Equals("?"))
        {
            if(MasterControlProgram.whereDidIComeFrom.Equals("north"))
            {
                this.gameObject.transform.position = this.southStart.transform.position;
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
            }
            else if(MasterControlProgram.whereDidIComeFrom.Equals("south"))
            {
                this.gameObject.transform.position = this.northStart.transform.position;
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
            }
            else if(MasterControlProgram.whereDidIComeFrom.Equals("east"))
            {
                this.gameObject.transform.position = this.westStart.transform.position;
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
            }
            else if(MasterControlProgram.whereDidIComeFrom.Equals("west"))
            {
                this.gameObject.transform.position = this.eastStart.transform.position;
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
            }
        }

        currentRoom = MasterControlProgram.p.getCurrentRoom();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("north"))
            {
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                this.isMoving = true;
                loadFightScene();
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        { 
            if(currentRoom.hasExit("south"))
            {
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                this.isMoving = true;
                loadFightScene();
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("east"))
            {
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                this.isMoving = true;
                loadFightScene();
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("west"))
            {
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                this.isMoving = true;
                loadFightScene();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("reset"))
        {
            this.rb.velocity = Vector3.zero;
            this.rb.Sleep();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("exit") && MasterControlProgram.isExiting)
        {
            if(other.gameObject == this.northExit)
            {
                MasterControlProgram.whereDidIComeFrom = "north";
                currentRoom.takeExit(MasterControlProgram.p, "north");
            }
            else if(other.gameObject == this.southExit)
            {
                MasterControlProgram.whereDidIComeFrom = "south";
                currentRoom.takeExit(MasterControlProgram.p, "south");
            }
            else if(other.gameObject == this.eastExit)
            {
                MasterControlProgram.whereDidIComeFrom = "east";
                currentRoom.takeExit(MasterControlProgram.p, "east");
            }
            else if(other.gameObject == this.westExit)
            {
                MasterControlProgram.whereDidIComeFrom = "west";
                currentRoom.takeExit(MasterControlProgram.p, "west");
            }
            MasterControlProgram.isExiting = false;
            SceneManager.LoadScene("Dungeon Room");
        }

        else if(other.gameObject.CompareTag("exit") && !MasterControlProgram.isExiting)
        {
            MasterControlProgram.isExiting = true;
        }
    }

    private void loadFightScene()
    {
        if(this.fightRoller <= 3.0f)
        {
            SceneManager.LoadScene("Fight Scene");
        }
    }
}
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
    public GameObject resetButton;
    private bool isMoving;
    private Room currentRoom;
    public GameObject playerCostume;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.isMoving = false;

        if(!MasterControlProgram.whereDidIComeFrom.Equals("?"))
        {
            if(MasterControlProgram.whereDidIComeFrom.Equals("north"))
            {
                this.gameObject.transform.position = this.southStart.transform.position;
                this.playerCostume.transform.LookAt(this.northExit.transform);
                this.rb.AddForce(Vector3.forward * 200.0f);
                
            }
            else if(MasterControlProgram.whereDidIComeFrom.Equals("south"))
            {
                this.gameObject.transform.position = this.northStart.transform.position;
                this.playerCostume.transform.LookAt(this.southExit.transform);
                this.rb.AddForce(Vector3.back * 200.0f);
            }
            else if(MasterControlProgram.whereDidIComeFrom.Equals("east"))
            {
                this.gameObject.transform.position = this.westStart.transform.position;
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                this.rb.AddForce(Vector3.right * 200.0f);
            }
            else if(MasterControlProgram.whereDidIComeFrom.Equals("west"))
            {
                this.gameObject.transform.position = this.eastStart.transform.position;
                this.playerCostume.transform.LookAt(this.westExit.transform);
                this.rb.AddForce(Vector3.left * 200.0f);
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
                this.playerCostume.transform.LookAt(this.northExit.transform);    
                this.rb.AddForce(Vector3.forward * 200.0f);
                this.isMoving = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        { 
            if(currentRoom.hasExit("south"))
            {
                this.playerCostume.transform.LookAt(this.southExit.transform);
                this.rb.AddForce(Vector3.back * 200.0f);
                this.isMoving = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("east"))
            {
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                this.rb.AddForce(Vector3.right * 200.0f);
                this.isMoving = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("west"))
            {
                this.playerCostume.transform.LookAt(this.westExit.transform);
                this.rb.AddForce(Vector3.left * 200.0f);
                this.isMoving = true;
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
}
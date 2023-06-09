using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public GameObject resetButton;
    private bool isMoving;
    private Room currentRoom;
    public GameObject playerCostume;
    public GameObject westMonsterTrigger, eastMonsterTrigger, southMonsterTrigger, northMonsterTrigger;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.isMoving = false;

        if(!MasterControlProgram.whereDidIComeFrom.Equals("?"))
        {
            if(MasterControlProgram.whereDidIComeFrom.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.playerCostume.transform.LookAt(this.northExit.transform);
                MasterControlProgram.run = true;
                this.rb.AddForce(Vector3.forward * 300.0f);  
            }
            else if(MasterControlProgram.whereDidIComeFrom.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.playerCostume.transform.LookAt(this.southExit.transform);
                MasterControlProgram.run = true;
                this.rb.AddForce(Vector3.back * 300.0f);
            }
            else if(MasterControlProgram.whereDidIComeFrom.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                MasterControlProgram.run = true;
                this.rb.AddForce(Vector3.right * 300.0f);
            }
            else if(MasterControlProgram.whereDidIComeFrom.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.playerCostume.transform.LookAt(this.westExit.transform);
                MasterControlProgram.run = true;
                this.rb.AddForce(Vector3.left * 300.0f);
            }
            StartCoroutine(PlayerHeal());
        }

        if(!MasterControlProgram.victoryContinue.Equals("?"))
        {
            if(MasterControlProgram.victoryContinue.Equals("north"))
            {
                this.gameObject.transform.position = new Vector3(this.northMonsterTrigger.transform.position.x, 0, this.northMonsterTrigger.transform.position.z);
                this.playerCostume.transform.LookAt(this.northExit.transform);
                MasterControlProgram.run = true;
                this.rb.AddForce(Vector3.forward * 200.0f);             
            }
            else if(MasterControlProgram.victoryContinue.Equals("south"))
            {
                this.gameObject.transform.position = new Vector3(this.southMonsterTrigger.transform.position.x, 0, this.southMonsterTrigger.transform.position.z);
                this.playerCostume.transform.LookAt(this.southExit.transform);
                MasterControlProgram.run = true;
                this.rb.AddForce(Vector3.back * 200.0f);
            }
            else if(MasterControlProgram.victoryContinue.Equals("east"))
            {
                this.gameObject.transform.position = new Vector3(this.eastMonsterTrigger.transform.position.x, 0, this.eastMonsterTrigger.transform.position.z);
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                MasterControlProgram.run = true;
                this.rb.AddForce(Vector3.right * 200.0f);
            }
            else if(MasterControlProgram.victoryContinue.Equals("west"))
            {
                this.gameObject.transform.position = new Vector3(this.westMonsterTrigger.transform.position.x, 0, this.westMonsterTrigger.transform.position.z);
                this.playerCostume.transform.LookAt(this.westExit.transform);
                MasterControlProgram.run = true;
                this.rb.AddForce(Vector3.left * 200.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.currentRoom = MasterControlProgram.thePlayer.getCurrentRoom();

        if(Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("north"))
            {
                this.playerCostume.transform.LookAt(this.northExit.transform); 
                MasterControlProgram.whereDidIComeFrom = "north";
                this.rb.AddForce(Vector3.forward * 300.0f);
                this.isMoving = true;
                MasterControlProgram.victoryContinue = "north";
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        { 
            if(currentRoom.hasExit("south"))
            {
                this.playerCostume.transform.LookAt(this.southExit.transform);
                MasterControlProgram.whereDidIComeFrom = "south";
                this.rb.AddForce(Vector3.back * 300.0f);
                this.isMoving = true;
                MasterControlProgram.victoryContinue = "south";
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("east"))
            {
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                MasterControlProgram.whereDidIComeFrom = "east";
                this.rb.AddForce(Vector3.right * 300.0f);
                this.isMoving = true;
                MasterControlProgram.victoryContinue = "east";
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("west"))
            {
                this.playerCostume.transform.LookAt(this.westExit.transform);
                MasterControlProgram.whereDidIComeFrom = "west";
                this.rb.AddForce(Vector3.left * 300.0f);
                this.isMoving = true;
                MasterControlProgram.victoryContinue = "west";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("reset"))
        {
            this.rb.velocity = Vector3.zero;
            this.rb.Sleep();

            MasterControlProgram.whereDidIComeFrom = "?";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("exit") && MasterControlProgram.isExiting)
        {
            if(other.gameObject == this.northExit)
            {
                MasterControlProgram.victoryContinue = "?";
                currentRoom.takeExit(MasterControlProgram.thePlayer, "north");
            }
            else if(other.gameObject == this.southExit)
            {
                MasterControlProgram.victoryContinue = "?";
                currentRoom.takeExit(MasterControlProgram.thePlayer, "south");
            }
            else if(other.gameObject == this.eastExit)
            {
                MasterControlProgram.victoryContinue = "?";
                currentRoom.takeExit(MasterControlProgram.thePlayer, "east");
            }
            else if(other.gameObject == this.westExit)
            {
                MasterControlProgram.victoryContinue = "?";
                currentRoom.takeExit(MasterControlProgram.thePlayer, "west");
            }
            MasterControlProgram.isExiting = false;
            SceneManager.LoadScene("Dungeon Room");
        }

        else if(other.gameObject.CompareTag("exit") && !MasterControlProgram.isExiting)
        {
            MasterControlProgram.isExiting = true;
        }
    }

    IEnumerator PlayerHeal()
    {
        yield return new WaitForSeconds(3.0f);
        MasterControlProgram.thePlayer.healHP(1);
        StartCoroutine(PlayerHeal());
    }
}
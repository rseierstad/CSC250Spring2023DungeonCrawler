using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public Vector3 northEntrancePosition, southEntrancePosition, eastEntrancePosition, westEntrancePosition;
    public Vector3 playerStartPosition;
    public float movementSpeed = 40.0f;
    private bool isMoving;
    private bool reset;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.playerStartPosition = new Vector3(0, 0.5f, 0);
        this.isMoving = false;
        this.reset = true;

        this.northEntrancePosition = new Vector3(this.northExit.transform.position.x, 0.5f, this.northExit.transform.position.z - 1.15f);
        this.southEntrancePosition = new Vector3(this.southExit.transform.position.x, 0.5f, this.southExit.transform.position.z + 1.15f);
        this.eastEntrancePosition = new Vector3(this.eastExit.transform.position.x - 1.15f, 0.5f, this.eastExit.transform.position.z);
        this.westEntrancePosition = new Vector3(this.westExit.transform.position.x + 1.15f, 0.5f, this.westExit.transform.position.z);

        if(MasterControlProgram.whereDidIComeFrom.Equals("north"))
        {
            MasterControlProgram.whereDidIComeFrom = "?";
            this.rb.transform.position = this.southEntrancePosition;
            this.rb.AddForce(new Vector3(0,0,40f));
            this.isMoving = true;
            this.reset = false;
        }
        if(MasterControlProgram.whereDidIComeFrom.Equals("south"))
        {
            MasterControlProgram.whereDidIComeFrom = "?";
            this.rb.transform.position = this.northEntrancePosition;
            this.rb.AddForce(new Vector3(0,0,-40f));
            this.isMoving = true;
            this.reset = false;
        }
        if(MasterControlProgram.whereDidIComeFrom.Equals("east"))
        {
            MasterControlProgram.whereDidIComeFrom = "?";
            this.rb.transform.position = this.westEntrancePosition;
            this.rb.AddForce(new Vector3(40f,0,0));
            this.isMoving = true;
            this.reset = false;
        }
        if(MasterControlProgram.whereDidIComeFrom.Equals("west"))
        {
            MasterControlProgram.whereDidIComeFrom = "?";
            this.rb.transform.position = this.eastEntrancePosition;
            this.rb.AddForce(new Vector3(-40f,0,0));
            this.isMoving = true;
            this.reset = false;
        }

        //AddForce moves it weird
    }

    // Update is called once per frame
    void Update()
    {
        if(this.rb.transform.position == this.playerStartPosition)
        {
            this.rb.velocity = Vector3.zero;
            this.rb.angularVelocity = Vector3.zero;
        } //not working

        if(Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            this.rb.AddForce(this.northExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        { 
            this.rb.AddForce(this.southExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            this.rb.AddForce(this.westExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("exit"))
        {
            if(other.gameObject == this.northExit)
            {
                MasterControlProgram.whereDidIComeFrom = "north";
            }
            if(other.gameObject == this.southExit)
            {
                MasterControlProgram.whereDidIComeFrom = "south";
            }
            if(other.gameObject == this.eastExit)
            {
                MasterControlProgram.whereDidIComeFrom = "east";
            }
            if(other.gameObject == this.westExit)
            {
                MasterControlProgram.whereDidIComeFrom = "west";
            }

            SceneManager.LoadScene("Dungeon Room");
        }
    }
}
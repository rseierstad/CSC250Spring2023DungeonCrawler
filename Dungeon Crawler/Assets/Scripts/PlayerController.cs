using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public float movementSpeed = 40.0f;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        print(MasterControlProgram.count);
        this.isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
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
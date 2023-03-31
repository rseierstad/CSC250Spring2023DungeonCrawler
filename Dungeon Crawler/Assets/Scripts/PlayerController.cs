using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public float movementSpeed = 40.0f;
    private string movingTowards = "";

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        print(MasterControlProgram.count);
    }

    // Update is called once per frame
    void Update()
    {
        if(movingTowards.Equals(""))
        {
           if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                movingTowards = "north";
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                    movingTowards = "south";
            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                movingTowards = "east";
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                movingTowards = "west";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("exit"))
        {
            MasterControlProgram.count++;
            SceneManager.LoadScene("Dungeon Room");
        }
    }
}
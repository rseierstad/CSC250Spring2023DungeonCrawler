using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        int chanceToFight = Random.Range(1,100);

        if(chanceToFight <= 30)
        {
            SceneManager.LoadScene("Fight Scene");
        }
        else
        {
            print("No monsters found!");
        }
    }
}

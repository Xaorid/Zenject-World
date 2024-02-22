using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TESTLOAD : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            SceneManager.LoadScene("Arena");
        }
    }
}

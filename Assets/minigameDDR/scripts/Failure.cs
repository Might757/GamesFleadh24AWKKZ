using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Failure : MonoBehaviour
{

    public KeyCode key;

    public KeyCode key2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            SceneManager.LoadScene("Main Level");
        }
        else if(Input.GetKeyDown(key2))
        {
            SceneManager.LoadScene("backup");
        }
    }
}

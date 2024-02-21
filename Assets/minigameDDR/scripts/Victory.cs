using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    public KeyCode key;
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
    }


}

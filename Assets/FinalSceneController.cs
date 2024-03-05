using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public  void TryAgain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
    }
}

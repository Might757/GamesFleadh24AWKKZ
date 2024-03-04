using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject success;
    [SerializeField] private GameObject unsuccess;
    [SerializeField] private GameObject blackBg;
    [SerializeField] private infectedSO infectedSO;
    [SerializeField] private GameObject player;
    private NPCInteractable npc;
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        npc = FindAnyObjectByType<NPCInteractable>();

    }

    // Update is called once per frame
    void Update()
    {
        if (points == 200)
        {            
            success.SetActive(true);
            npc.isInfected = true;
            infectedSO.ScoreMultiplier += 0.1f;
            infectedSO.Score = infectedSO.Score + (1 * infectedSO.ScoreMultiplier);
            player.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.tag == "Person")
        {
            //Create a reference to the man
            GameObject person = collision.gameObject;

            //Destroy the man
            Destroy(person);
        }

         if(collision.collider.tag == "virus")
        {
            //Create a reference to the collectable
            GameObject virus = collision.gameObject;

            //Destroy the man
            Destroy(virus);

        }
    }
}



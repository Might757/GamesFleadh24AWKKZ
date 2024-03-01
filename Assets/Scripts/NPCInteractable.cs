using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private infectedSO infectedSO;
    [SerializeField] private string interactText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject containerUI;
    [SerializeField] private GameObject infectedBubble;
    private GameObject infectedScoreUI;
    [SerializeField] private GameObject ddr;
    [SerializeField] private GameObject maze;
    [SerializeField] private GameObject angryVirus;
    [SerializeField] private Material infectedSkin;
    [SerializeField] private bool isStrong = false;

    private int randomInt;
    private Vector3 minigamePosition;
    public bool isInfected = false;
    public bool minigameOn = false;

    void Start()
    {
        infectedScoreUI = GameObject.FindGameObjectWithTag("Score");
        minigamePosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.z , gameObject.transform.position.z); // 1000 on y
    }

    public void Interact()
    {
        npcInfect();

    }

    public string GetInteractText() 
    {
        if (isInfected == true)
        {
            interactText = "Already Infected!";
        }
        return interactText;
    }

    private void npcInfect()
    {
        // normal NPC, will add 1 to the score if isStrong = false // isStrong = true means it will add float number to the multiplier if minigame is passed (somehow)
        if (isInfected == false && isStrong == false)
        {
            infectedSO.Score = infectedSO.Score + (1 * infectedSO.ScoreMultiplier);
            isInfected = true;
        }
        else if (isInfected == false && isStrong == true && minigameOn == false)
        {
            randomInt = 2; //Random.Range(1,2);
            minigameOn = true;
            Debug.Log(randomInt);
            //play minigame, if player wins minigame, adds multiplier, if not, multiplier resets to 0.
            switch (randomInt)
            {
                case 1:
                    Instantiate(ddr, minigamePosition, transform.rotation);
                    break;
                case 2:
                    //Instantiate(maze, minigamePosition, transform.rotation);
                    Instantiate(maze, minigamePosition, transform.rotation);
                    break;
                case 3:

                    Instantiate(angryVirus, minigamePosition, transform.rotation);
                    break;
            }

            player.SetActive(false);
            infectedScoreUI.SetActive(false);
        }
        else if (isInfected == true)  
        {

            Debug.Log("Player is already infected! Your currently infected " + infectedSO.Score + "people!");
        }


    }

    void Update()
    {
        if (isInfected == true)
        {
            infectedBubble.SetActive(true);
        }
    }

}

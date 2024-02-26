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
    [SerializeField] private GameObject ddr;
    //[SerializeField] private GameObject maze;
    [SerializeField] private GameObject angryVirus;
    [SerializeField] private MeshRenderer currentSkin;
    [SerializeField] private Material infectedSkin;
    [SerializeField] private bool isStrong = false;

    private int randomInt;
    private Vector3 minigamePosition;
    public bool isInfected = false;
    public bool minigameOn = false;

    void Start()
    {
        minigamePosition = new Vector3(gameObject.transform.position.x, 1000, gameObject.transform.position.z);
    }

    public void Interact()
    {
        npcInfect();

    }

    public string GetInteractText() 
    {
        return interactText;
    }

    private void npcInfect()
    {
        // normal NPC, will add 1 to the score if isStrong = false // isStrong = true means it will add float number to the multiplier if minigame is passed (somehow)
        if (isInfected == false && isStrong == false)
        {
            currentSkin.material = infectedSkin;
            infectedSO.Score = infectedSO.Score + (1 * infectedSO.ScoreMultiplier);
            isInfected = true;
        }
        else if (isInfected == false && isStrong == true && minigameOn == false)
        {
            randomInt = 1;
            minigameOn = true;
            Debug.Log(randomInt);
            //play minigame, if player wins minigame, adds multiplier, if not, multiplier resets to 0.
            switch (randomInt)
            {
                case 1:
                    Debug.Log(ddr.transform.position);
                    Instantiate(ddr, minigamePosition, transform.rotation);
                    Debug.Log(ddr.transform.position);
                    break;
                case 2:
                    //Instantiate(maze, minigamePosition, transform.rotation);
                    Debug.Log("maze instantiated");
                    break;
                case 3:
                    Instantiate(angryVirus, minigamePosition, transform.rotation);
                    break;
            }

            player.SetActive(false);
          // new script to be done for the minigame and connect it with NPCInteracble class.
        }
        else if (isInfected == true)  
        {

            Debug.Log("Player is already infected! Your currently infected " + infectedSO.Score + "people!");
        }


    }

}

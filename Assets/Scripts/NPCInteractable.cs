using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private infectedSO infectedSO;
    [SerializeField] private string interactText;

    [SerializeField] private MeshRenderer currentSkin;
    [SerializeField] private Material infectedSkin;
    [SerializeField] private bool isStrong = false;

    public bool isInfected = false;

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
            infectedSO.Score += 1 * infectedSO.ScoreMultiplier;
        }
        else if (isInfected == true)  
        {
            Debug.Log("Player is already infected! Your currently infected " + infectedSO.Score + "people!");
        }

        //play minigame, if player wins minigame, adds multiplier, if not, multiplier resets to 0.
        // new script to be done for the minigame and connect it with NPCInteracble class.
    }

}

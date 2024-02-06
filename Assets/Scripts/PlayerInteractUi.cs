using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInteractUi : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;
    public TMP_FontAsset tmFont;
    public TMP_FontAsset infectFont;


    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null) 
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }
    private void Show(IInteractable interactable)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactable.GetInteractText();
        if (interactable.GetInteractText().Equals("Open/Close Door")) 
        {
            interactTextMeshProUGUI.font = tmFont;
        } 
        else 
        {
            interactTextMeshProUGUI.font = infectFont;
        }
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}

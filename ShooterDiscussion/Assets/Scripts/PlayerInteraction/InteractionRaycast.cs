using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionRaycast : MonoBehaviour
{
    public TMP_Text interactionText; // Displays hint on screen
    public LayerMask interactionLayer;
    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5.0f, interactionLayer))
        {
            Interactable interactableScript = hit.transform.GetComponent<Interactable>();
            interactionText.enabled = true;
            if (interactableScript != null)
            {
                if (Input.GetKeyDown(KeyCode.Q)) interactableScript.Interact();
            }
            else
            {
                interactionText.text = "[Error]";
            }

        }
        else
        {
            interactionText.enabled = false;
        }
    }
}

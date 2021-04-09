using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractionRaycast : MonoBehaviour
{
    public string InteractionHintText;
    public string InteractionHintTextButtonLocked = "This button is locked";

    private PlayerAbilities pa = null;

    public TMP_Text interactionText; // Displays hint on screen
    public LayerMask interactionLayer;

    private bool UIButtonWasLastSelected = false;
    EventSystem eventSystem;

    public Color originalSelectedUIButtonColor;
    public Color originalUnlockedButtonColor;

    public Color accessDeniedSelectedButtonColor;

    WSButtonPress lastButtonPressed = null;
    void Start()
    {
        pa = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilities>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5.0f, interactionLayer))
        {
            Interactable interactableScript = hit.transform.GetComponent<Interactable>();
            if (interactableScript != null)
            {
                bool enableInteractionTextCheck = true; // default to true, if problem or WSButton was clicked set to false
                interactionText.text = InteractionHintText;
                if (hit.transform.GetComponent<WSButtonPress>() != null)
                {
                    // This may cause a problem if buttons are directly next to each other
                    if (lastButtonPressed == null) lastButtonPressed = hit.transform.GetComponent<WSButtonPress>();

                    lastButtonPressed.mr.material.SetFloat("_OutlineWidth", 0.07f); // Sets the shader's property
                    interactionText.color = originalUnlockedButtonColor;

                    // If the button is inactive (locked)
                    if (lastButtonPressed.activeButton == false)
                    {
                        interactionText.text = "This button is locked";
                        interactionText.color = accessDeniedSelectedButtonColor;
                    }

                    if (lastButtonPressed.HasBeenClicked()) enableInteractionTextCheck = false; // WS button was clicked
                }

                if (enableInteractionTextCheck) interactionText.enabled = true;
                if (Input.GetKeyDown(KeyCode.Q)) interactableScript.Interact();
            }

            if (hit.transform.CompareTag("UIButton"))
            {
                Button btn = hit.transform.GetComponent<Button>();

                bool adminCheckPass = true;
                if (btn.transform.name.Contains("Admin"))
                {
                    ColorBlock newCB = btn.colors;

                    if (!pa.IsAdmin())
                    {
                        adminCheckPass = false;
                        newCB.selectedColor = accessDeniedSelectedButtonColor;
                    }
                    else newCB.selectedColor = originalSelectedUIButtonColor;

                    btn.colors = newCB;
                }
                btn.Select();
                UIButtonWasLastSelected = true;
                interactionText.enabled = true;

                if (Input.GetKeyDown(KeyCode.Q) && adminCheckPass)
                {
                    btn.onClick.Invoke();
                }

            }
        }
        else
        {
            if (lastButtonPressed)
            {
                lastButtonPressed.mr.material.SetFloat("_OutlineWidth", 0f);
                lastButtonPressed = null;
            }

            interactionText.enabled = false;
            if (UIButtonWasLastSelected == true)
            {
                UIButtonWasLastSelected = false;
                eventSystem.SetSelectedGameObject(null);
            }
        }
    }
}

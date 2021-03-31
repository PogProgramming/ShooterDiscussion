using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractionRaycast : MonoBehaviour
{
    private PlayerAbilities pa = null;

    public TMP_Text interactionText; // Displays hint on screen
    public LayerMask interactionLayer;

    private bool UIButtonWasLastSelected = false;
    EventSystem eventSystem;

    ColorBlock originalColorBlock;
    public Color originalSelectedUIButtonColor;
    public Color accessDeniedSelectedUIButtonColor;
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
                interactionText.enabled = true;
                if (Input.GetKeyDown(KeyCode.Q)) interactableScript.Interact();
            }

            if (hit.transform.tag == "UIButton")
            {
                Button btn = hit.transform.GetComponent<Button>();

                bool adminCheckPass = true;
                if (btn.transform.name.Contains("Admin"))
                {
                    ColorBlock newCB = btn.colors;

                    if (!pa.IsAdmin())
                    {
                        adminCheckPass = false;
                        newCB.selectedColor = accessDeniedSelectedUIButtonColor;
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
            interactionText.enabled = false;
            if (UIButtonWasLastSelected == true)
            {
                UIButtonWasLastSelected = false;
                eventSystem.SetSelectedGameObject(null);
            }
        }
    }
}

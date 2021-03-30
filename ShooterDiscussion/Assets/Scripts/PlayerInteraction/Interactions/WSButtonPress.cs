using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WorldSpace button press
public class WSButtonPress : MonoBehaviour
{
    Interactable intCall;
    Vector3 startPos;
    public Vector3 clickedPos;

    public float buttonClickSpeed = 2.0f;

    bool clicked = false;
    bool clickable = true;

    public bool isGettingCallbackToBeReady = false;
    public bool readyToBeClicked = true;

    private MeshRenderer mr;
    public Material clickableMaterial;
    public Material unclickableMaterial;
    void Start()
    {
        startPos = transform.position;
        if (clickedPos == null) gameObject.SetActive(false);

        mr = GetComponent<MeshRenderer>();
    }

    public void ButtonClick(Interactable intCall)
    {
        if (!clickable) return;

        clicked = true;
        clickable = false;

        if (!this.intCall) this.intCall = intCall;
        this.intCall.canBeInteracted = clickable; // Tells interactable component not to invoke UnityEvents

        mr.material = unclickableMaterial;
    }

    void Update()
    {
        if (!clickable)
        {
            if (clicked)
            {
                transform.position = Vector3.Lerp(transform.position, clickedPos,
                                                  buttonClickSpeed * Time.deltaTime);

                // Add custom wait for response here to know to come back out
                if (Vector3.Distance(transform.position, clickedPos) < 0.01f)
                {
                    if (readyToBeClicked && isGettingCallbackToBeReady || readyToBeClicked && !isGettingCallbackToBeReady)
                        clicked = false;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, startPos,
                                      buttonClickSpeed * Time.deltaTime * 3);

                if (Vector3.Distance(transform.position, startPos) < 0.01f)
                {
                    clickable = true;
                    this.intCall.canBeInteracted = clickable; // Tells interactable component that it's finished and ready to invoke UnityEvents
                    mr.material = clickableMaterial;
                }
            }
        }
    }
}

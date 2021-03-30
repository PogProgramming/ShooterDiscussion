using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDoor : MonoBehaviour
{
    WSButtonPress button = null;

    public enum DoorState
    {
        Open,
        Closed
    }

    // Use LocalPositions if parented
    private Vector3 closedPos;
    public Vector3 openPos;

    bool doorEngaged = false;
    DoorState currentState = DoorState.Closed;
    private Vector3 targetPos;

    public float lerpSpeed = 5.0f;

    bool parented;

    public void Interact(WSButtonPress btn)
    {
        if (doorEngaged) return;

        if (currentState == DoorState.Open) SetDoorState(DoorState.Closed);
        else if (currentState == DoorState.Closed) SetDoorState(DoorState.Open);

        if (btn != null)
        {
            button = btn;
            button.isGettingCallbackToBeReady = true;
            button.readyToBeClicked = false;
        }
    }

    void Start()
    {
        closedPos = transform.position;
        currentState = DoorState.Closed;
        targetPos = closedPos;

        if (transform.parent != null)
            parented = true;

        Interact(null); // Updates current values in prep
    }

    void Update()
    {
        if (doorEngaged)
        {
            if (parented)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, lerpSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.localPosition, targetPos) < 0.01f)
                {
                    doorEngaged = false;

                    if (button != null)
                        button.readyToBeClicked = true;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPos) < 0.01f)
                {
                    doorEngaged = false;

                    if (button != null)
                        button.readyToBeClicked = true;
                }
            }
        }
    }

    void SetDoorState(DoorState state)
    {
        if (doorEngaged == false)
        {
            currentState = state;
            if (state == DoorState.Closed)
            {
                targetPos = openPos;
            }
            else if (state == DoorState.Open)
            {
                targetPos = closedPos;
            }

            doorEngaged = true;
        }
    }
}

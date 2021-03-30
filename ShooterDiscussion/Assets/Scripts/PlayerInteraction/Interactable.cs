using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool canBeInteracted = true;

    [SerializeField] private UnityEvent Interaction;
    public void Interact()
    {
        if (canBeInteracted)
            Interaction.Invoke();
    }
}

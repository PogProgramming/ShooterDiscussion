using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindAndLockAllButtons : MonoBehaviour
{
    bool unlocked = false;
    private GameObject[] buttonPresses;

    void Start()
    {
        buttonPresses = GameObject.FindGameObjectsWithTag("Button");
    }

    public void ToggleLock()
    {
        unlocked = !unlocked; // if existingly true, set to false
        foreach (GameObject btn in buttonPresses)
        {
            btn.GetComponent<WSButtonPress>().SetIsClickable(unlocked);
            btn.GetComponent<Interactable>().canBeInteracted = unlocked;
            Debug.Log(unlocked);
        }
    }

    void Update()
    {
    }
}

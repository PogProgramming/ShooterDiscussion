using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonColorToggleChange : MonoBehaviour
{
    public bool active = true;
    Button thisButton = null;

    public Color EnabledColour;
    public Color DisabledColour;

    private void Start()
    {
        thisButton = transform.GetComponent<Button>();
    }

    public void ToggleColour()
    {
        if (active)
        {
            ColorBlock newCB = thisButton.colors;
            newCB.pressedColor = EnabledColour;
            thisButton.colors = newCB;
        }
        else
        {
            ColorBlock newCB = thisButton.colors;
            newCB.pressedColor = DisabledColour;
            thisButton.colors = newCB;
        }

        active = !active;
    }
}

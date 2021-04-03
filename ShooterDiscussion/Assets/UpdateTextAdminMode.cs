using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTextAdminMode : MonoBehaviour
{
    public PlayerAbilities pa;
    public TMP_Text text;

    public Color enabledColor;
    public Color disabledColor;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pa.IsAdmin())
        {
            text.text = "Enabled";
            text.color = enabledColor;
        }
        else
        {
            text.text = "Disabled";
            text.color = disabledColor;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTextActiveEnemies : MonoBehaviour
{
    public TMP_Text textToUpdate = null;
    public Transform enemyHolder = null;
    void Start()
    {
        textToUpdate = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textToUpdate.text = enemyHolder.childCount.ToString();
    }
}

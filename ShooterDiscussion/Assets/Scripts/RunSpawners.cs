﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSpawners : MonoBehaviour
{
    public Transform entityHolder = null;
    public void SpawnEnemies()
    {
        BroadcastMessage("SpawnEnemy", entityHolder);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    PlayerMovement playerController;
    Camera cam = null;
    public LayerMask enemyLayer;

    public struct Arsenal
    {
        public Gun gun;
        public Animator gunAnimator;
    }

    public List<Arsenal> gunArsenals;

    public float originalCameraFOV = 75.7f;
    public float zoomedCameraFOV = 40.0f;
    public float zoomSpeed = 1;

    public Image normalCrosshair;
    public Image hitCrosshair;

    void Start()
    {
        playerController = GetComponent<PlayerMovement>();
        cam = Camera.main;
    }

    void Update()
    {
        
    }
}

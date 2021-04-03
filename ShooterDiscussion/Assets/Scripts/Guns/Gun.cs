using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "", order = 0)]
public class Gun : ScriptableObject
{
    public enum GunType
    {
        Pistol,
        Rocket,
        PDW
    }

    public GameObject gun;
    public GameObject shootableObject; // e.g bullet
    public Animator gunAnimator;
    public GunType gunType;
    public float damage;
    public float gunBulletSpeed = 150;
    public float cooldown;

    public Gun() { }

    public Gun(GameObject gunObject, GameObject bullet, Animator ani, GunType type, float _damage, float _cooldown)
    {
        gun = gunObject;
        shootableObject = bullet;
        gunAnimator = ani;
        gunType = type;
        damage = _damage;
        cooldown = _cooldown;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] private GameObject projectile, gun;
    
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}

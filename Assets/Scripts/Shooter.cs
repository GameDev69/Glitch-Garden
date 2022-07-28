using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] private GameObject projectile, gun;
    private AttackerSpawner _myLaneSpawner;
    private Animator _animator;
    private readonly int _isAttacking = Animator.StringToHash("isAttacking");

    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            // Debug.Log("Он на моей линии");
            _animator.SetBool(_isAttacking, true);
        }
        else
        {
            // Debug.Log("Жду...");
            _animator.SetBool(_isAttacking, false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) 
                 <= 0.2f);
            // Debug.Log(spawner.name);
            // Debug.Log(Mathf.Abs(spawner.transform.position.y - transform.position.y) 
            //           <= 0.2f);
            // Debug.Log(spawner.transform.position.y);
            // Debug.Log(transform.position.y);
            if (isCloseEnough)
            {
                _myLaneSpawner = spawner;
                // Debug.Log("Done!");
            }
        }
    }
    
    private bool IsAttackerInLane()
        {
            if (_myLaneSpawner.transform.childCount <= 0 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}

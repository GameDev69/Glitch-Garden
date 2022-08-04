using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] private GameObject projectile, gun;
    private AttackerSpawner _myLaneSpawner;
    private Animator _animator;
    private GameObject _projectileParent;
    private const string ProjectileParentName = "Projectiles";
    private readonly int _isAttacking = Animator.StringToHash("isAttacking");

    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
        CreateProjectileParent();
    }
    
    private void CreateProjectileParent() // Создаём родителя для defender
    {
        _projectileParent = GameObject.Find(ProjectileParentName);
        if (!_projectileParent)
        {
            _projectileParent = new GameObject(ProjectileParentName);
        }  
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            _animator.SetBool(_isAttacking, true);
        }
        else
        {
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
            if (isCloseEnough)
            {
                _myLaneSpawner = spawner;
            }
        }
    }
    
    private bool IsAttackerInLane()
    {
        if (!_myLaneSpawner || _myLaneSpawner.transform.childCount <= 0)
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
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = _projectileParent.transform;
    }
}

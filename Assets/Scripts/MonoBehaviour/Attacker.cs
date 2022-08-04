using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float _currentSpeed;
    private GameObject _currentTarget;
    private readonly int _isAttacking = Animator.StringToHash("isAttacking");

    private void Awake()
    {
        
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController == null) return;
        levelController.AttackerKilled();
    }

    void Update()
    {
        transform.Translate(Vector2.left * (_currentSpeed * Time.deltaTime));
        UodateAnimationState();
        
    }

     private void UodateAnimationState()
     {
         if (!_currentTarget)
         {
             GetComponent<Animator>().SetBool(_isAttacking, false);
         }
     }

     public void SetMovementSpeed(float speed)
     {
         _currentSpeed = speed;
     }

     public void Attack(GameObject target)
     {
         Animator animator = GetComponent<Animator>();
         animator.SetBool(_isAttacking, true);
         _currentTarget = target;
     }

     public void StrikeCurrentTarget(float damage)
     {
         if (!_currentTarget) return;
         Health health = _currentTarget.GetComponent<Health>();
         if (health)
         {
             health.DealDamage(damage);
         }
     }
     
}

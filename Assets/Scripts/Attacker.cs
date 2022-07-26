using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    
    private float _currentSpeed = 1f;
    private GameObject _currentTarget;
    private readonly int _isAttacking = Animator.StringToHash("isAttacking");
    
     void Update()
    {
        transform.Translate(Vector2.left * (_currentSpeed * Time.deltaTime));
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
}

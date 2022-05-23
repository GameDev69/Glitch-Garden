using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    
    private float _currentSpeed = 1f;
    
     void Update()
    {
        transform.Translate(Vector2.left * (_currentSpeed * Time.deltaTime));
    }

     public void SetMovementSpeed(float speed)
     {
         _currentSpeed = speed;
     }
}
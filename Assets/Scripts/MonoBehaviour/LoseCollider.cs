using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LivesDisplay _livesDisplay;
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        _livesDisplay = FindObjectOfType<LivesDisplay>().GetComponent<LivesDisplay>();
        _livesDisplay.DecreaseHealth(1);
        Destroy(otherCollider.gameObject);
    }
}

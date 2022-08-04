using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private ScriptableObject variableData;
    private float _health;
    private GameObject _deathVFX;
    private void Start()
    {
        CheckingTypeOfScriptableObject();
    }

    private void CheckingTypeOfScriptableObject()
    {
        if (GetComponent<Attacker>())
        {
            var attackers = (Attackers) variableData;
            _health = attackers.HealthPoints;
            _deathVFX = attackers.DeathVFX;
        }
        else if (GetComponent<Defender>())
        {
            var defenders = (Defenders) variableData;
            _health = defenders.HealthPoints;
        }
    }

    public void DealDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            TriggerDeathVFX(_deathVFX);
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX(GameObject deathVFX)
    {
        if (!deathVFX) return;
        var deathVFXObject =  Instantiate(deathVFX, transform.position + new Vector3(-0.5f, -0.5f, 0), transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}

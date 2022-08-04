using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private AttackerSpawners attackerSpawners;
    
    private float _minSpawnDelay;
    private float _maxSpawnDelay;
    private Attacker[] _attackerPrefabArray;
    private bool _spawn = true;
    
    IEnumerator Start()
    {
        NewVariablesDeclaration();
        while (_spawn)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void NewVariablesDeclaration()
    {
        _minSpawnDelay = attackerSpawners.MINSpawnDelay;
        _maxSpawnDelay = attackerSpawners.MAXSpawnDelay;
        _attackerPrefabArray = attackerSpawners.AttackerPrefabArray;
    }

    public void StopSpawning()
    {
        _spawn = false;
    }

    private void SpawnAttacker()
    {
        if(_attackerPrefabArray.Length == 0) return;
        int attackerIndex = Random.Range(0, _attackerPrefabArray.Length);
        Spawn(_attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker selectedAttacker)
    {
        Attacker newAttacker = Instantiate
            (selectedAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}

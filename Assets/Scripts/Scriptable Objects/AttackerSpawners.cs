using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawner")]
public class AttackerSpawners : ScriptableObject
{
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float maxSpawnDelay;
    [SerializeField] private Attacker[] attackerPrefabArray;

    public float MINSpawnDelay => minSpawnDelay;
    public float MAXSpawnDelay => maxSpawnDelay;
    public Attacker[] AttackerPrefabArray => attackerPrefabArray;
}

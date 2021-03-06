﻿using UnityEngine;

public class SeedsSpawner : MonoBehaviour {

    [RangeAttribute(0, 100)]
    public int chanceToSpawnSeed;

    public GameObject seedPrefab;
    public Transform seedsParent;

    private void OnEnable() {
        TrollController.OnTrollIsDead += checkIfSpawnSeed;
    }

    private void OnDisable() {
        TrollController.OnTrollIsDead -= checkIfSpawnSeed;
    }

    private void checkIfSpawnSeed(GameObject troll) {
        TrollController trollController = troll.GetComponent<TrollController>();
        if (trollController.canSpanSeed)
            if (Random.Range(0, 101) <= chanceToSpawnSeed) {
                spawnSeed(troll.transform.position);
            }
    }

    private void spawnSeed(Vector3 position) {
        seedPrefab.transform.Rotate(Vector3.right * Random.Range(0, 360));
        Instantiate(seedPrefab, new Vector3(position.x, seedPrefab.transform.position.y, position.z), seedPrefab.transform.rotation, seedsParent);
    }

}
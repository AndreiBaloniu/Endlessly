using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   public float initialSpawnRate = 0.5f; // Viteza de spawn initiala
   public float normalSpawnRate = 1f; // Viteza normala de spawn
   public float fastSpawnRate = 1.5f; // Viteza rapida de spawn
   public float slowSpawnRate = 0.25f; // Viteza lenta de spawn
   public GameObject hexagonPrefab;
   private float nextTimeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        nextTimeToSpawn = Time.time + 1f / initialSpawnRate; // Seteaza prima data de spawn
    }

    // Update is called once per frame
    void Update()
    {
        // Calculeaza viteza de spawn in functie de scor
        float spawnRate = normalSpawnRate;
        int score = ScoreManager.Instance.score;
        if (score >= 500 && score < 750) {
            spawnRate = fastSpawnRate;
        } else if (score >= 750 && score < 1000) {
            spawnRate = normalSpawnRate;
        } else if (score >= 1000 && score < 1350) {
            spawnRate = slowSpawnRate;
        } else if (score >= 1350 && score < 1800) {
            spawnRate = fastSpawnRate;
        } else if (score >= 1800) {
            spawnRate = normalSpawnRate+slowSpawnRate;
        }

        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRate;
        }
    }
}

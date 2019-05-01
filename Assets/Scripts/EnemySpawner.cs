using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemyBoss;

    private void Start()
    {
        Instantiate(enemy1, new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f)), Quaternion.identity);
        Instantiate(enemy2, new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f)), Quaternion.identity);
    }

    public void BossSpawn()
    {
        Instantiate(enemyBoss, new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f)), Quaternion.identity);
        Invoke("BossDespawn", 20f);
    }

    private void BossDespawn()
    {
        Destroy(GameObject.FindGameObjectWithTag("Boss"));
    }
}

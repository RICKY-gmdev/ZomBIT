using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    void Start()
    {
        InvokeRepeating("SpawnZombie", 0f, spawnInterval);
    }

    void SpawnZombie()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject zombie = Instantiate(zombiePrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        zombie.GetComponent<EnemyAI>().enabled = false; // Disable AI until it lands
        StartCoroutine(EnableZombieAI(zombie));
    }

    IEnumerator EnableZombieAI(GameObject zombie)
    {
        yield return new WaitForSeconds(0.5f); // Allow time to land
        zombie.GetComponent<EnemyAI>().enabled = true;
    }
}
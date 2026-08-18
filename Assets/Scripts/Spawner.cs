using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject enemyPrefab;
    public float spawnCooldown = 2f;
    private float spawnTimer = 0f;
    public float spawnDistance = 7f;
    public int maxEnemies = 10;

    private GameObject[] enemies;
    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnCooldown)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }
    void SpawnEnemy()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        randomDirection *= spawnDistance;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (player != null)
        {
            if (enemies.Length < maxEnemies)
            {
                Instantiate(enemyPrefab, player.position + (Vector3)randomDirection, Quaternion.identity);
            }
        }
        
        
    }
}

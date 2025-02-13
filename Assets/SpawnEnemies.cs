using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    //Initialize Variables
    [SerializeField] GameObject levelOneEnemy;
    [SerializeField] GameObject levelTwoEnemy;
    [SerializeField] GameObject levelThreeEnemy;

    float spawnTime;
    int currentLevel = 0;

    //Start spawning enemies for current level
    public void StartSpawning(int level)
    {
       if (level != currentLevel)
        {
            currentLevel = level;
            StopSpawning();

            if (level == 1)
            {
                spawnTime = 2.0f;
                InvokeRepeating("SpawnLevelOneEnemy", 0f, spawnTime);
            }
            else if (level == 2)
            {
                spawnTime = 1f;
                InvokeRepeating("SpawnLevelTwoEnemy", 0f, spawnTime);
                CancelInvoke("SpawnLevelOneEnemy");
            }
            else if (level == 3)
            {
                spawnTime = 0.5f;
                InvokeRepeating("SpawnLevelThreeEnemy", 0f, spawnTime);
                CancelInvoke("SpawnLevelTwoEnemy");
            }
        }
    }
    //Keeps objects in bounds
    public void KeepInBounds()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.position = new Vector2(clampedX, transform.position.y);
    }

    //Stop spawning method
    public void StopSpawning()
    {
        CancelInvoke("SpawnLevelOneEnemy");
        CancelInvoke("SpawnLevelTwoEnemy");
        CancelInvoke("SpawnLevelThreeEnemy");
    }

    public void SpawnLevelOneEnemy()
    {
        KeepInBounds();
        int randomX = Random.Range(-8, 8);
        Vector2 enemyPosition = new Vector2(randomX, 8);
        spawnTime = 15.0f;
        Instantiate(levelOneEnemy, enemyPosition, Quaternion.identity);
        Debug.Log("Spawning working");
    }

    // Spawn Level Two Enemy
    public void SpawnLevelTwoEnemy()
    {
        KeepInBounds();
        int randomX = Random.Range(-8, 8);
        Vector2 enemyPosition = new Vector2(randomX, 8);
        spawnTime = 10.0f;
        Instantiate(levelTwoEnemy, enemyPosition, Quaternion.identity);
    }

    // Spawn Level Three Enemy
    public void SpawnLevelThreeEnemy()
    {
        KeepInBounds();
        int randomX = Random.Range(-8, 8);
        Vector2 enemyPosition = new Vector2(randomX, 8);
        spawnTime = 5.0f;
        Instantiate(levelThreeEnemy, enemyPosition, Quaternion.identity);
    }
}

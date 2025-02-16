using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TestClass testClass;
    [SerializeField] private ZombieSpawner zombieSpawner;
    [SerializeField] private EnemyDetector enemyDetector;
    [SerializeField] private BulletSpawner bulletSpawner;
    private void OnEnable() 
    {
        testClass.OnZombieSpawned += zombieSpawner.SpawnZombie;
        enemyDetector.OnEnemyDetected += bulletSpawner.SpawnBullet;
    }

    private void OnDisable()
    {
        testClass.OnZombieSpawned -= zombieSpawner.SpawnZombie;
        enemyDetector.OnEnemyDetected -= bulletSpawner.SpawnBullet;
    }
    
    
}
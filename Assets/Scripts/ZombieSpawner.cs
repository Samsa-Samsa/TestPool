using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Zombie zombiePrefab;
    [SerializeField] private int amount = 10;
    [SerializeField] private Transform target;
    [SerializeField] private float spawnRadius = 5f;
    [SerializeField] private Transform parent;
    private Pool<Zombie> _zombiePool;

    private void Awake()
    {
        _zombiePool = new Pool<Zombie>(zombiePrefab, amount, parent);
    }

    public void SpawnZombie()
    {
        var zombie = _zombiePool.GetFromPool();
        if (!zombie) return;
        var spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
        zombie.transform.position = new Vector3(spawnPos.x, spawnPos.y, 0) + transform.position;
        zombie.Target = target;
        zombie.OnZombieDestroyed -= ReturnZombie; 
        zombie.OnZombieDestroyed += ReturnZombie;
      
    }

    private void ReturnZombie(Zombie zombie)
    {
        _zombiePool.ReturnToPool(zombie);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Zombie zombiePrefab;
    [SerializeField] private int amount;
    [SerializeField] private Transform target;
    [SerializeField] private float spawnRadius;
    private Pool<Zombie> _zombiePool;
    private Zombie _zombie;
    
    private void Awake () =>  _zombiePool = 
        new Pool<Zombie>(zombiePrefab, amount, transform);
    public void SpawnZombie()
    {
        _zombie = _zombiePool.GetFromPool();
        //ეს რენდომ ავიღე
        var randomAngle = Random.Range(0f, 2f * Mathf.PI);
        var x = Mathf.Cos(randomAngle) * spawnRadius;
        var y = Mathf.Sin(randomAngle) * spawnRadius;
        _zombie.transform.position = new Vector3(x, y, 0) + transform.position;
        _zombie.Target = target;
        _zombie.OnZombieDestroyed -= ReturnZombie;
        _zombie.OnZombieDestroyed += ReturnZombie;
    }
    
    private void ReturnZombie(Zombie zombie) =>
        _zombiePool.ReturnToPool(zombie);
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawWireSphere(transform.position, spawnRadius); 
    }
}

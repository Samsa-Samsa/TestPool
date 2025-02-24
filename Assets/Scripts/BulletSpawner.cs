using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int amount;
    private Pool<Bullet> _pool;
    
    

    private void Awake()
    {
        _pool = new Pool<Bullet>(bulletPrefab, amount,transform);
    }

    public void SpawnBullet(Transform position)
    {
        var bullet = _pool.GetFromPool();
        
        
        bullet.Target = position;
        bullet.OnHit -= DeleteBullet;
        bullet.OnHit += DeleteBullet;
    }

    private void DeleteBullet(Bullet bullet)
    {
        _pool.ReturnToPool(bullet);
    }
              
}
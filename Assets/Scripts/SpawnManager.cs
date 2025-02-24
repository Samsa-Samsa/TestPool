using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  private Spawner<Bullet> _bulletSpawner;
  private Spawner<Zombie> _zombieSpawner;
  [SerializeField] private Bullet bulletPrefab;
  [SerializeField] private Zombie zombiePrefab;
  [SerializeField] private int amount;
  [SerializeField] private int zombieAmount;

  private void Awake()
  {
     _bulletSpawner = new Spawner<Bullet>(bulletPrefab,amount,transform);
     _zombieSpawner = new Spawner<Zombie>(zombiePrefab,amount,transform);
  }
  
  private void SpawnBullet()
  {
     var bullet =  _bulletSpawner.Spawn(transform.position, transform.rotation);
   
     
  }

  private void SpawnZombie()
  {
     var zombie =  _zombieSpawner.Spawn(transform.position, transform.rotation);
    
      
  }

  


}
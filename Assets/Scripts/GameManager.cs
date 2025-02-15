using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TestClass testClass;
    [SerializeField] private ZombieSpawner zombieSpawner;
    private void OnEnable() => testClass.OnZombieSpawned += zombieSpawner.SpawnZombie;
    private void OnDisable() =>   testClass.OnZombieSpawned -= zombieSpawner.SpawnZombie;
    
}
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int amount;
    [SerializeField] private Transform prefab;
    private Spawner<Transform> _spawner;
    
    private void Awake()
    {
        _spawner = new Spawner<Transform>(prefab, amount,transform);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            SpawnEnemy(transform.position,transform.rotation);
       
    }

    private void SpawnEnemy(Vector3 position, Quaternion rotation)
    {
        var obj = _spawner.Spawn(position, rotation);
    }

    private void DespawnEnemy(Transform obj)
    {
        _spawner.Despawn(obj);
    }
}
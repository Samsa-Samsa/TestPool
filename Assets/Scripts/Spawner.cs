
using UnityEngine;
public class Spawner<T> where T : Component
{
    private readonly Pool<T> _pool;

    public Spawner(T prefab, int amount, Transform parent)
    {
        _pool = new Pool<T>(prefab, amount,parent);
    }

    
    public T Spawn(Vector3 position, Quaternion rotation)
    {
        var obj = _pool.GetFromPool();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }
    public void Despawn(T obj)
    {
        _pool.ReturnToPool(obj);
    }
    
}
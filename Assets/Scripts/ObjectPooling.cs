using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : Component
{
    private readonly Queue<T> _objects;
    private readonly T _prefab;
    private readonly Transform _parent;

    public Pool(T prefab, int size, Transform parent)
    {
        _objects = new Queue<T>(size);
        _prefab = prefab;
        _parent = parent;

        for (var i = 0; i < size; i++)
            AddObjectToPool();
    }
    
    //ვქმნი ობიექტს, ვთიშავ და ვამატებ საცავში.
    private void AddObjectToPool()
    {
        
        var obj = Object.Instantiate(_prefab, _parent);
        obj.gameObject.SetActive(false);
        _objects.Enqueue(obj);
    }

   
    public T GetFromPool()
    {
        var obj = _objects.Count > 0 ? _objects.Dequeue() : // ამომაქვს საცავიდან
            Object.Instantiate(_prefab, _parent); // თუ არ მაქვს საცავში ახალს ვქმნი

        ResetObject(obj); // ვაბრუნებ საწყის პოზიციაზე
        obj.gameObject.SetActive(true); // ვრთავ ობჯექტს
        return obj;
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false); // ვთშავ ობჯექტს
        _objects.Enqueue(obj); // ვაბრუნებ საცავში
    }

    private void ResetObject(T obj)
    {
        obj.transform.SetParent(_parent); // ვაბრუნებ მშობელთან
        obj.transform.localPosition = Vector3.zero; // პოზიციას ვუნულებ 
        obj.transform.localRotation = Quaternion.identity; // როტაციას ვუნულებ 
    }
}
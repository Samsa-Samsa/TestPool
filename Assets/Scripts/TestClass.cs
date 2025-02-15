using System;
using UnityEngine;

public class TestClass : MonoBehaviour
{
    [SerializeField] private ZombieSpawner zombieSpawner;
    public event Action OnZombieSpawned;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            OnZombieSpawned?.Invoke();
            
    }
}
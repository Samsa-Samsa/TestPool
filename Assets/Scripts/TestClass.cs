using System;
using UnityEngine;
using UnityEngine.UI;

public class TestClass : MonoBehaviour
{
    [SerializeField] private ZombieSpawner zombieSpawner;
    [SerializeField] private Button spawnButton;
    public event Action OnZombieSpawned;

    private void Awake()
    {
        spawnButton.onClick.AddListener(() => OnZombieSpawned?.Invoke());
    }
    
}
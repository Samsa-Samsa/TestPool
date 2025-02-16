using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private List<Collider2D> enemyContainer = new();
    public event Action<Transform> OnEnemyDetected;
    private Transform _lastDetectedEnemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((enemyMask & (1 << other.gameObject.layer)) > 0)
        {
           if(!enemyContainer.Contains(other))
               enemyContainer.Add(other);
        }
        
        FindClosestEnemy();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(enemyContainer.Contains(other))
            enemyContainer.Remove(other);
        if(enemyContainer.Count > 0)
            FindClosestEnemy();
    }

    private void FindClosestEnemy()
    {
        if (enemyContainer.Count == 0) return;
        Collider2D closestEnemy = null;
        var closestDistance = Mathf.Infinity;
        foreach (var enemy in enemyContainer)
        {
            var distance = Vector3.Distance(transform.position,enemy.transform.position);
            if (!(distance < closestDistance)) continue;
            closestDistance = distance;
            closestEnemy = enemy;
        }
        
        if (closestEnemy == null || closestEnemy.transform == _lastDetectedEnemy) return;

        _lastDetectedEnemy = closestEnemy.transform;
        OnEnemyDetected?.Invoke(closestEnemy.transform);
       
        
    }
}
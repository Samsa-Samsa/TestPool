using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum ZombieType
{
    Fast,
    Slow
}
public class Zombie : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isMoving = true;
    [SerializeField] private ZombieType zombieType;
    public event Action<Zombie> OnZombieDestroyed;
    public Transform Target { get; set; }
   

    private void OnEnable()
    {
        isMoving = true;
        zombieType = Random.value > 0.5f ? ZombieType.Slow : ZombieType.Fast;
        switch (zombieType)
        {
            case ZombieType.Slow:
                spriteRenderer.color = Color.yellow;
                speed = 1;
                break;
            case ZombieType.Fast:
                spriteRenderer.color = Color.red;
                speed = 2;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Update()
    {
        if (!isMoving) return; 
        var distance = Vector3.Distance(transform.position, Target.position);
        if (distance <= stoppingDistance)
        {
            OnZombieDestroyed?.Invoke(this); 
            isMoving = false;
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, Target.position,
            speed * Time.deltaTime);
    }
}
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
    [SerializeField] private ZombieType zombieType;
    [SerializeField] private LayerMask bulletLayer;
    public event Action<Zombie> OnZombieDestroyed;
    public Transform Target { get; set; }
   

    private void OnEnable()
    {
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
        transform.position = Vector3.MoveTowards(transform.position, Target.position,
            speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bulletLayer == (bulletLayer | (1 << other.gameObject.layer)))
        {
            OnZombieDestroyed?.Invoke(this); 
        }
    }
}
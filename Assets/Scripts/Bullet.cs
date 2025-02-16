using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask bulletLayer;
    public event Action<Bullet> OnHit;
    
    public Transform Target { get => target; set => target = value; }

    private void Update()
    {
        if(Target == null)return;
        transform.position = Vector3.MoveTowards(transform.position,
            Target.transform.position, 10f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bulletLayer == (bulletLayer | (1 << other.gameObject.layer)))
        {
            OnHit?.Invoke(this);
        }
    }
}
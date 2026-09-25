using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Transform targetDestination;
    [SerializeField] float speed;

    Rigidbody rgdbd;

    private void Awake()
    {
        rgdbd = GetComponent<Rigidbody>();
       
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd.linearVelocity = direction * speed;    
    }

}

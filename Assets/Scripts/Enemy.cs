using UnityEngine;

public class Enemy : MonoBehaviour
{
    Health damage;
    [SerializeField] Transform targetDestination;
    [SerializeField] float speed;
    public GameObject hitPoints;

    Rigidbody rgdbd;

    void Start()
    {
        damage = hitPoints.GetComponent<Health>();
    }
    private void Awake()
    {
        rgdbd = GetComponent<Rigidbody>();
       
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd.linearVelocity = direction * speed;    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damage.TakeDamage(1);
        }
    }

}

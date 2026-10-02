using UnityEngine;

public class Enemy : MonoBehaviour
{
    Health damage;
    [SerializeField] float speed;
    [SerializeField] private GameObject prefab;
    public GameObject hitPoints;

    Rigidbody rgdbd;

   
    void Start()
    {
        damage = hitPoints.GetComponent<Health>();
    }
    private void Awake()
    {
        rgdbd = GetComponent<Rigidbody>();
        //find targetDestination gameboject by name "PLayer"
        targetDestination = GameObject.Find("Player").GetComponent<Transform>();

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

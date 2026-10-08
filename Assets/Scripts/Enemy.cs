using UnityEngine;

public class Enemy : MonoBehaviour
{
    Health damage;
    [SerializeField] float speed;
    [SerializeField] private GameObject prefab;
    [SerializeField] int experience_reward = 400;
    private GameObject hitPoints;

    Rigidbody rgdbd;
    private Transform targetDestination;

    void Start()
    {
        damage = hitPoints.GetComponent<Health>();

    }
    private void Awake()
    {
        rgdbd = GetComponent<Rigidbody>();
        //find targetDestination gameboject by name "PLayer"
        targetDestination = GameObject.Find("Player").GetComponent<Transform>();
        hitPoints = GameObject.FindGameObjectWithTag("Player");

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
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            targetDestination.GetComponent<Level>().AddExperience(experience_reward);
        }
    }

}

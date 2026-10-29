using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    Vector3 direction;
    [SerializeField] float speed;
    Vector3 movementVector;
    public AudioSource src;
    public AudioClip shootSound;

    public float bulletForce = 10f;
    GameplayManagerScript gameplayManagerScript;

    public float fireRate = 10f;

    private float nextFireTime = 0f;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);
        
        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x = -1;
            transform.localScale = scale;
        }
    }

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
            src.clip = shootSound;
            src.Play();
        }



    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }

}

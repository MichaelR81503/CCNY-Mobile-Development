using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    Vector3 direction;
    [SerializeField] float speed;
    Vector3 movementVector;
    public float lastHorizontalVector;
    public float lastVerticalVector;

    public float bulletForce = 20f;
    GameplayManagerScript gameplayManagerScript;

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
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }



    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().SetDirection(gameplayManagerScript.lastHorizontalVector, 0f);
    }

}

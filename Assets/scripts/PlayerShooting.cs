using UnityEngine;

public class PlayerShooting : MonoBehaviour
{   public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletVelocity = 20f;
    public float firerate = 0.5f;
    private float nextFireTime = 0f;
    
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / firerate;
            shoot();
        }
    }

    void shoot()
    {
      GameObject bullet = Instantiate(bulletPrefab,shootPoint.position,shootPoint.rotation);
      bullet.GetComponent<Rigidbody>().linearVelocity = shootPoint.forward * bulletVelocity;
      Destroy(bullet,2f);
    }
}

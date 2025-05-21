using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zombie"))
        {
            GameManager.instance.IncreaseScore();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

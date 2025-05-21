using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    void Start()
    {
        StartCoroutine(StartChasing());
    }

    IEnumerator StartChasing()
    {
        yield return new WaitForSeconds(0.5f);
        enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.LookAt(player);
    }
}
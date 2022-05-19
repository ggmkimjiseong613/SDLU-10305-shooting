using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove3 : MonoBehaviour
{
    Vector3 dir;
    public float speed;
    public GameObject hitFactory;
    void Start()
    {
        float random = Random.Range(-5,5 );
        GameObject player = GameObject.Find("Player");
        dir = new Vector3(player.transform.position.x +random,player.transform.position.y+random,0) - transform.position;
        dir.Normalize();
    }
    public void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void LateUpdate()
    {
        if (transform.position.y < -8.8)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
            Instantiate(hitFactory).transform.position = transform.position;
        }
    }
}

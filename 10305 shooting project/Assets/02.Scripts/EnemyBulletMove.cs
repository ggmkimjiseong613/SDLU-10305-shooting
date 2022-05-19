using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    
    public GameObject hitFactory;
    public float speed;
    Vector3 dir;
    public void Start()
    {
        dir = Vector3.down;
        GameObject player = GameObject.Find("Player");
        dir = player.transform.position - transform.position;
        dir.Normalize();
    }
    void Update()
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

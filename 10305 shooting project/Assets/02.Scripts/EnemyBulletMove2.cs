using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove2 : MonoBehaviour
{
    public GameObject hitFactory;
    public float speed;
    Vector3 dir;
    

    void Update()
    {
        dir = Vector3.down;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{



    public void LateUpdate()
    {
        if (transform.position.y <= -8.8 || transform.position.y >= 4.8)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("BossEnemy"))
        {
            Destroy(gameObject);
        }
    }
}

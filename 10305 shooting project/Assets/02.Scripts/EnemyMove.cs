using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float hp;
    public GameObject explosionFactory;
    public Sprite[] sprite;
    SpriteRenderer spriteRenderer;
    public float currentTime;
    Vector3 dir;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    public void Move()
    {
        dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
    }

    void Update()
    {
        Move();
        Destroy();
        currentTime += Time.deltaTime;
        
    }
    public void Destroy()
    {
        
        if(hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionFactory).transform.position = transform.position;
            GameObject smObject = GameObject.Find("ScoreManger");
            ScoreManger sm = smObject.GetComponent<ScoreManger>();
            sm.currentScore++;
            if(sm.currentScore > sm.bestScore)
            {
                sm.bestScore = sm.currentScore;
                PlayerPrefs.SetInt("Best Score", sm.bestScore);
            }
            sm.currentScoreUI.text = "현재점수 : " + sm.currentScore;
            sm.bestScoreUI.text = "최고점수 : " + sm.bestScore;
            

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 1;
                spriteRenderer.sprite = sprite[1];
                Invoke("ReturnSprite", 0.05f);
        }
        if (collision.gameObject.CompareTag("player"))
        {
            hp -= 100;
        }
    }
    public void LateUpdate()
    {
        if(transform.position.y < -8.8)
        {
            Destroy(gameObject);
        }
    }
    public void ReturnSprite()
    {
        spriteRenderer.sprite = sprite[0];
    }
}

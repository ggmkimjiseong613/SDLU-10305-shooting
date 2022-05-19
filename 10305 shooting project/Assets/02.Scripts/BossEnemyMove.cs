using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BossEnemyMove : MonoBehaviour
{
    public GameObject randomBossBullet;
    public Transform canvas;
    public GameObject BossHpValue;
    public Slider BossHpSlider;
    public GameObject hitFactory;
    public GameObject enemyChasingBullet;
    public GameObject enemyBullet;
    public float curretTime;
    public float delayTime;
    public float speed;
    public float BossMaxHP = 120;
    public float BossCurrentHp = 120;
    public Vector3 dir;
    public float skillTime;
    private int i = 0;
    public float effectCurrentTime;
    public void Start()
    {
        
        BossHpSlider.value = (float)BossCurrentHp / (float)BossMaxHP;

        
    }
    void Update()
    {
        
        
        if(BossCurrentHp <= 0)
        {
            SceneManager.LoadScene("GameClear");
        }
        effectCurrentTime += Time.deltaTime;
        skillTime += Time.deltaTime;
        curretTime += Time.deltaTime;
        GameObject smObject = GameObject.Find("ScoreManger");
        ScoreManger sm = smObject.GetComponent<ScoreManger>();
        if(sm.currentScore > 19)
        {
            
            if (BossCurrentHp > 120 )
            {
                skill1();
            }
            else if(BossCurrentHp > 90)
            {
                skill2();
            }
            else
            {
                delayTime = 0.15f;
                skill3();
            }
            dir = Vector3.down;
            transform.position += dir * speed * Time.deltaTime;
            if(transform.position.y < 3)
            {
                while( i < 1)
                {
                    speed = 0;

                    Vector3 dir = new Vector3(391, 983, 0);
                    BossHpValue.transform.position = dir;

                    i++;
                }
            }
            
        }
        
       

    }
    public void skill1()
    {
        if (curretTime > delayTime)
        {
            Instantiate(enemyChasingBullet).transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
            Instantiate(enemyChasingBullet).transform.position = transform.position;
            curretTime = 0;
        }
        
    }
   public void skill2()
    {
        if (curretTime > delayTime)
        {
            float right = 1.5f;
            float left = 1.5f;
            Instantiate(enemyBullet).transform.position = transform.position;
            for (int k = 0; k < 6; k++)
            {
               Instantiate(enemyBullet).transform.position = transform.position + Vector3.right * right;
                right += 1.5f;
            }
            for(int l = 0; l < 6; l++)
            {
                Instantiate(enemyBullet).transform.position = transform.position + Vector3.left * left;
                left += 1.5f;
            }
            curretTime = 0;
        }
    }
    public void skill3()
    {
        if (curretTime > delayTime)
        {
            Instantiate(randomBossBullet).transform.position = transform.position;
            curretTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BossCurrentHp -= 1;
            if (effectCurrentTime > 0.1f)
            {
                Instantiate(hitFactory).transform.position = transform.position;
                effectCurrentTime = 0;
            }
            BossHpSlider.value = (float)BossCurrentHp / (float)BossMaxHP;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public float speed;
    Animator anim;
    public StageData stageData;
    public GameObject bullet1;
    public GameObject bullet2;
    public float maxShootingDelay;
    public float currentShootingDelay;
    public Slider playerHP;
    public float maxHp = 100;
    public float curHp = 100;
    public AudioSource audiosource;



    public void Awake()
    {
        anim = GetComponent<Animator>();
        playerHP.value = (float)curHp / (float)maxHp;
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
        Fire();
        Reload();
        if(curHp <= 0)
        {
            SceneManager.LoadScene("GameOver");

        }
    }
    public void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
            Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0).normalized;
        transform.position += dir * speed * Time.deltaTime;
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("Input", (int)h);
        }
    }
    public void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            if (currentShootingDelay > maxShootingDelay)
            {
                audiosource.Play();             
                GameObject bulletR = Instantiate(bullet1, transform.position + Vector3.right*0.35f, transform.rotation);
                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                GameObject bulletM = Instantiate(bullet2, transform.position, transform.rotation);
                Rigidbody2D rigidM = bulletM.GetComponent<Rigidbody2D>();
                GameObject bulletL = Instantiate(bullet1, transform.position + Vector3.left * 0.35f, transform.rotation);
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                rigidL.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                rigidM.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                rigidR.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                currentShootingDelay = 0;
            }
        }

    }
    public void Reload()
    {
        currentShootingDelay += Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            curHp -= 10;
            playerHP.value = (float)curHp / (float)maxHp;
        }
        else if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            curHp -= 10;
            playerHP.value = (float)curHp / (float)maxHp;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    protected float sinceAttack = 0f;

    protected int hp;
    protected Animator animator;
    protected Slider healthBar;
    protected Text healthLabel;

    [Header("Stats")]
    [SerializeField] protected int maxHp;
    [SerializeField] protected float speed;
    [SerializeField] protected float shotDelay;

    [Header("Prefabs")]
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected GameObject deathFx;

    void RefreshUI()
    {
        healthLabel.text = hp + "/" + maxHp;
        healthBar.value = hp;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<Slider>();
        healthLabel = GetComponentInChildren<Text>();
        hp = maxHp;
        healthBar.maxValue = maxHp;
        RefreshUI();
        speed /= 50;
        Init();
    }

    protected virtual void Init()
    {

    }

    protected virtual void ShotFire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    protected virtual void Move()
    {

    }


    void FixedUpdate()
    {
        // ¹¥“ÄÅÐ¶¨
        sinceAttack += Time.deltaTime;
        if (sinceAttack > shotDelay)
        {
            animator.SetTrigger("Attack");
            ShotFire();
            sinceAttack = 0f;
        }

        Move();
    }

    void TakeDamage(int damage)
    {
        hp -= damage;
        RefreshUI();
        if (hp <= 0)
        {
            UEventDispatcher.dispatchEvent(MyEvent.LEVEL_CLEAR, null);
            Instantiate(deathFx, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            BaseBullet config = collision.gameObject.GetComponent<BaseBullet>();
            if (config.life > config.timeToOn)
            {
                Destroy(collision.gameObject);
                TakeDamage(collision.gameObject.GetComponent<BaseBullet>().damageBoss);
            }
        }
    }
}

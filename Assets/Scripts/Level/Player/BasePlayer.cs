using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    protected int inputX, inputY;
    protected Vector2 direction;
    protected Rigidbody2D rb2d;
    protected Animator animator;
    protected GameObject shield;
    protected ShieldGuard shieldGuard;

    [Header("Stats")]
    [SerializeField] protected float speed;

    [Header("Prefabs")]
    [SerializeField] protected GameObject deathFx;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shield = GameObject.FindGameObjectWithTag("Shield");
        if (shield != null)
            shieldGuard = shield.GetComponent<ShieldGuard>();
    }

    protected virtual void Move()
    {
        rb2d.velocity = direction * speed;
    }


    void Update()
    {
        if (!Global.isPause)
        {
            if (Global.isKeyMouse)
            {
                if (Input.GetKey(KeyCode.W))
                    inputY = 1;
                else if (Input.GetKey(KeyCode.S))
                    inputY = -1;
                else
                    inputY = 0;

                if (Input.GetKey(KeyCode.A))
                    inputX = -1;
                else if (Input.GetKey(KeyCode.D))
                    inputX = 1;
                else
                    inputX = 0;
                direction = new Vector2(inputX, inputY).normalized;
            }
            else if (Global.isController)
            {
                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");
                if (x < 0)
                    inputX = -1;
                else if (x > 0)
                    inputX = 1;
                else
                    inputX = 0;
                if (y < 0)
                    inputY = -1;
                else if (y > 0)
                    inputY = 1;
                else
                    inputY = 0;
                direction = new Vector2(x, y).normalized;
            }

            Move();

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (Global.friendlyBullet && collision.gameObject.GetComponent<BaseBullet>().friendly)
                return;
            if (!Global.godMode)
            {
                Destroy(collision.gameObject);
                if (!Global.ezMode)
                {
                    UEventDispatcher.dispatchEvent(MyEvent.PLAYER_DEATH, null);
                    Instantiate(deathFx, transform.position, transform.rotation);
                    Destroy(this.gameObject);
                    Destroy(shield);
                }
                else if (shieldGuard.GetHP() > 0)
                {
                    shieldGuard.TakeDamage(collision.gameObject.GetComponent<BaseBullet>().damageShield);
                }
                else
                {
                    UEventDispatcher.dispatchEvent(MyEvent.PLAYER_DEATH, null);
                    Instantiate(deathFx, transform.position, transform.rotation);
                    Destroy(this.gameObject);
                    Destroy(shield);
                }
            }
        }
        else if (collision.CompareTag("Enemy") && !Global.godMode)
        {
            UEventDispatcher.dispatchEvent(MyEvent.PLAYER_DEATH, null);
            Instantiate(deathFx, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(shield);
        }

    }
}

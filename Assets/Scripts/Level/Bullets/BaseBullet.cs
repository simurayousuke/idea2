using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    internal bool friendly = false;
    int reflectedCount = 0;
    internal float life = 0f;


    internal Rigidbody2D rb2d;
    protected GameObject player;
    internal TrailRenderer tr;

    [Header("Stats")]
    [SerializeField] internal int damageBoss;
    [SerializeField] internal int damageShield;
    [SerializeField] internal bool canGuard;
    [SerializeField] protected float speed;
    [SerializeField] internal float timeToOn;
    [SerializeField] protected int maxReflectCount;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        tr = GetComponentInChildren<TrailRenderer>();
    }

    void Start()
    {
        if (player == null)
        {
            rb2d.velocity = Vector2.down * speed;
            return;
        }
        InitVelocity();
        transform.up = rb2d.velocity;
    }

    void Update()
    {
        life += Time.deltaTime;
    }

    protected virtual void InitVelocity()
    {
        Vector2 direction = player.transform.position - transform.position;
        rb2d.velocity = direction.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bound"))
        {
            if (++reflectedCount > maxReflectCount)
                Destroy(this.gameObject);
        }
    }
}

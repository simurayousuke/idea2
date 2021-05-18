using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldGuard : MonoBehaviour
{
    float sinceLastGuard = 0f;
    bool canGuard = true;
    float sinceGuard = 0f;
    internal bool isGuarding = false;
    int hp;
    bool hasShield = true;
    float untilRevive;

    SpriteRenderer sr;
    BoxCollider2D box;


    [SerializeField] int maxHp;
    [SerializeField] float guardTime;
    [SerializeField] float cooldown;
    [SerializeField] float reviveTime;

    [SerializeField] Color readyColor;
    [SerializeField] Color guardingColor;
    [SerializeField] Color cooldownColor;
    [SerializeField] Color trailStartColor;
    [SerializeField] Color trailEndColor;

    [SerializeField] GameObject left;
    [SerializeField] GameObject right;
    [SerializeField] Slider hpBar;
    Text hpLabel;

    void RefreshUI()
    {
        if (hp > 0)
        {
            hpBar.value = hp;
            hpLabel.text = hp + "/" + maxHp;
        }
        else
        {
            hpBar.value = (1 - untilRevive / reviveTime) * maxHp;
            hpLabel.text = Math.Round(untilRevive, 1) + "s";
        }
    }

    public int GetHP()
    {
        return hp;
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        hpLabel = hpBar.GetComponentInChildren<Text>();
        hp = maxHp;
        hpBar.maxValue = maxHp;
        untilRevive = reviveTime;
        if (Global.ezMode)
        {
            cooldown = 0.3f;
            guardTime = 0.7f;
        }
    }

    void Update()
    {
        if (!hasShield)
        {
            untilRevive -= Time.deltaTime;
            if (untilRevive < 0)
            {
                hasShield = true;
                untilRevive = reviveTime;
                sr.enabled = true;
                box.enabled = true;
                hp = maxHp;
            }
        }
        if (!canGuard)
        {
            sinceLastGuard += Time.deltaTime;
            float rgb = Mathf.Lerp(128, 0, sinceLastGuard / cooldown) / 255;
            sr.color = new Color(rgb, rgb, rgb);
            if (sinceLastGuard > cooldown)
            {
                canGuard = true;
                sinceLastGuard = 0f;
                sr.color = readyColor;
            }
        }
        if (isGuarding)
        {
            sinceGuard += Time.deltaTime;
            if (sinceGuard > guardTime)
            {
                isGuarding = false;
                canGuard = false;
                sinceGuard = 0f;
                sr.color = cooldownColor;
            }
        }
        if (Global.isKeyMouse)
        {
            if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && canGuard && !isGuarding)
            {
                isGuarding = true;
                sr.color = guardingColor;
            }
        }
        else if (Global.isController)
        {
            if ((Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("joystick button 5")) && canGuard && !isGuarding)
            {
                isGuarding = true;
                sr.color = guardingColor;
            }
        }
        RefreshUI();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            sr.enabled = false;
            box.enabled = false;
            hasShield = false;
            canGuard = true;
            isGuarding = false;
            sr.color = readyColor;
            sinceLastGuard = 0f;
            sinceGuard = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            BaseBullet config = collision.gameObject.GetComponent<BaseBullet>();
            if (Global.friendlyBullet && config.friendly)
                return;
            if (isGuarding && config.canGuard)
            {
                Vector2 normal = CoordinateUtil.GetNormalLine(left.transform.position, right.transform.position);
                float speed = config.rb2d.velocity.magnitude;
                config.rb2d.velocity = Vector2.Reflect(config.rb2d.velocity, normal).normalized * speed;
                collision.transform.up = config.rb2d.velocity;

                if (null != config.tr)
                {
                    config.tr.startColor = trailStartColor;
                    config.tr.endColor = trailEndColor;
                    config.friendly = true;
                }
            }
            else
            {
                TakeDamage(config.damageShield);
                Destroy(collision.gameObject);
            }
        }
    }
}

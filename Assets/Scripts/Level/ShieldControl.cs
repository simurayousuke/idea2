using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour
{
    Vector2 curDirection=Vector2.up;
    Vector2 tarDirection;

    GameObject player;
    ShieldGuard guard;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        guard = GetComponent<ShieldGuard>();
    }


    void Update()
    {

        if (Global.isKeyMouse)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tarDirection = (mousePos - (Vector2)player.transform.position).normalized;
            if (!guard.isGuarding)
                curDirection = tarDirection;

            transform.up = curDirection;
            transform.position = (Vector2)player.transform.position + curDirection * 3f;
        }
        else if (Global.isController)
        {
            float pitch = Input.GetAxisRaw("Pitch");
            float roll = Input.GetAxisRaw("Roll");
            Vector2 dir = new Vector2(pitch, roll);
            if (dir.sqrMagnitude > 0)
                tarDirection = dir;
            if (!guard.isGuarding)
                curDirection = tarDirection;
            transform.up = curDirection;
            transform.position = (Vector2)player.transform.position + curDirection.normalized * 3f;
        }
    }
}

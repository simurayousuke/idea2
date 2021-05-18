using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : BasePlayer
{

    protected override void Move()
    {
        rb2d.velocity = direction * speed;

        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        if (inputX < 0)
            rotation = new Quaternion(0, 180, 0, 0);
        transform.rotation = rotation;
        animator.SetInteger("inputX", inputX);
        animator.SetInteger("inputY", inputY);

    }
}

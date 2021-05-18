using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBullet : BaseBullet
{
    protected override void InitVelocity()
    {
        Vector2 direction = player.transform.position - transform.position;
        if (direction.x > 0)
            direction.x = 1;
        else
            direction.x = -1;
        direction.y = -1;
        rb2d.velocity = direction.normalized * speed;
    }

}

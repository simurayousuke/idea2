using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyControl : BaseEnemy
{
    int directionX = 1;

    protected override void ShotFire()
    {
        Vector2 pos = transform.position;
        //pos.y -= 6;
        Instantiate(bullet, pos, transform.rotation);
    }

    protected override void Move()
    {
        // ˮƽ�Ƅӷ����ж�
        Vector2 curPos = transform.position;
        //curPos.x -= 13.5f;
        if (curPos.x < -30)
            directionX = 1;
        else if (curPos.x > 30)
            directionX = -1;
        // �ΤΈ������ض�
        Vector2 tarPos = curPos;
        tarPos.x += directionX * speed;
        tarPos.y = directionX * 3 * Mathf.Cos(tarPos.x * Mathf.PI / 20) + 6;
        //tarPos.x += 13.5f;
        // �Ƅ�
        transform.Translate(tarPos - curPos);
    }

}

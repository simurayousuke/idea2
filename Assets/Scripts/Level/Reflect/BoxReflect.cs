using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReflect : MonoBehaviour
{
    float _left, _right, _top, _bottom;
    BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        Vector2 _center = transform.InverseTransformPoint(box.bounds.center);
        Vector2 halfSize = box.bounds.size / 2;
        _left = _center.x - halfSize.x;
        _right = _center.x + halfSize.x;
        _top = _center.y + halfSize.y;
        _bottom = _center.y - halfSize.y;
    }

    void Reflect(Collider2D collision)
    {
        Vector2 closest = box.bounds.ClosestPoint(collision.transform.position);
        Vector2 _closest = transform.InverseTransformPoint(closest);
        Vector2 _normal = Vector2.zero;
        if (_closest.x == _left)
            _normal = Vector2.left;
        else if (_closest.x == _right)
            _normal = Vector2.right;
        else if (_closest.y == _top)
            _normal = Vector2.up;
        else if (_closest.y == _bottom)
            _normal = Vector2.down;
        Vector2 normal = transform.TransformDirection(_normal);
        Rigidbody2D rb2d = collision.GetComponentInParent<Rigidbody2D>();
        rb2d.velocity = Vector2.Reflect(rb2d.velocity, normal);
        collision.transform.up = rb2d.velocity;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Reflect(collision);
        }
    }
}

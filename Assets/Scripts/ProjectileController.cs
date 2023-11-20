using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Angles;

public class ProjectileController : MonoBehaviour
{
    public float move_speed = 10f;
    public float angle = 0f;

    Vector2 movement;
    [SerializeField] Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        CalculteMovement();
        Rotate();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer != 3)
        {
            Destroy(gameObject);
        }
    }

    void Rotate()
    {
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void CalculteMovement()
    {
        Vector3 aux = GetVectorFromAngle(angle);
        movement.x = aux.x;
        movement.y = aux.y;
        movement = movement.normalized;
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * move_speed * Time.fixedDeltaTime);
    }
}

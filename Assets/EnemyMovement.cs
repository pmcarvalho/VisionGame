using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float move_speed = 5f;
    Vector2 movement;
    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculteMovement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void CalculteMovement()
    {
        movement.x = move_speed;
        movement.y = 0f;
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * move_speed * Time.fixedDeltaTime);
    }
}

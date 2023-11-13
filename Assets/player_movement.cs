using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public FieldOfView fieldOfView;
    public float move_speed = 5f;
    float speed_modifier = 1f; 
    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
        fieldOfView.SetOrigin(transform.position);
    }

    void ProcessInputs()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * move_speed * speed_modifier * Time.fixedDeltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static Angles;

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
        TurnToMouse();
        fieldOfView.SetOrigin(transform.position);
    }

    void ProcessInputs()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if(fieldOfView.fov == 45f)
            {
                fieldOfView.fov = 30f;
                fieldOfView.viewDistance = 10f;
            }
            else if(fieldOfView.fov == 30f)
            {
                fieldOfView.fov = 45f;
                fieldOfView.viewDistance = 5f;
            }
        }
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * move_speed * speed_modifier * Time.fixedDeltaTime);
    }

    void TurnToMouse()
    {
        var angle = GetAngleFromVectorFloat(Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        fieldOfView.startingAngle = angle;
    }
}

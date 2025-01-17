﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed = 15;
    public Rigidbody2D rb;
    private Vector2 MoveDirection;
    private bool Dashing;
    public float timeRemaining = 0.1f;
    public bool timerIsRunning = false;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        if (Input.GetButtonDown("Jump"))
        {
            MoveSpeed = 50;

            timerIsRunning = true;
            timeRemaining = 0.1f;

            Debug.Log(timeRemaining);
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                MoveSpeed = 15;
            }
        }


    }


    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        //Debug.Log("Current Speed :"+MoveSpeed);
        rb.velocity = new Vector3(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
        
    }
    
}

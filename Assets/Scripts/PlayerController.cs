using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed at which the object moves
    public float dashDistance = 7f;  // Distance at which the object dash
    public float dashDuration = 0.2f;  // How long object will dash
    public float dashCooldown = 2f; // How long dash cooldown will be
    private Rigidbody rb;

    public bool canDash = true;
    public bool isDashing = false;
    public bool isCooldown = false;

    void Start()
    {
        // Get the reference to the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Get input from the arrow keys or WASD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        
        rb.velocity = movement * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            // Start dashing coroutine in the desired direction
            StartCoroutine(Dash(movement));
        }

        
    }
    
    IEnumerator Dash(Vector3 direction)
    {
        isDashing = true;
        canDash = false;

        // Calculate the destination position based on the dash distance and direction
        Vector3 destination = transform.position + direction * dashDistance;

        // Move the player to the destination position over the dash duration
        float elapsedTime = 0f;
        while (elapsedTime < dashDuration)
        {
            rb.MovePosition(Vector3.Lerp(transform.position, destination, elapsedTime / dashDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
                
        yield return new WaitForSeconds(dashCooldown);
    
        isDashing = false;
        canDash = true;
    }
}

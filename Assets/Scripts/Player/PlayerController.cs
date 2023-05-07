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
        MovementInput();
    }

    private void MovementInput()
    {
        // Get input from the arrow keys or WASD
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        bool shiftButtonDown = Input.GetKeyDown(KeyCode.LeftShift);

        // Calculate the movement direction
        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0f);
        
        if (moveHorizontal != 0f && moveVertical != 0f)
        {
            direction *= 0.7f;
        }

        // if there is movement either move or roll
        if (direction != Vector3.zero)
        {
            if (!shiftButtonDown)
            {
                rb.velocity = direction * moveSpeed;
            }

            else if (shiftButtonDown && canDash)
            {
                StartCoroutine(Dashing(direction));
            }
        }

        else
        {
            rb.velocity = Vector3.zero;
        }

        // if (Input.GetKeyDown(KeyCode.Space) && canDash)
        // {
        //     // Start dashing coroutine in the desired direction
        //     StartCoroutine(Dash(movement));
        // }
        
    }
    
    IEnumerator Dashing(Vector3 direction)
    {
        // minDistance used to decide when to exit coroutine loop
        float minDistance = 0.2f;

        isDashing = true;
        canDash = false;

        // Calculate the destination position based on the dash distance and direction
        Vector3 destination = transform.position + direction * dashDistance;

        // Move the player to the destination position over the dash duration
        while (Vector3.Distance(transform.position, destination) > minDistance)
        {
            Vector3 unitVector = Vector3.Normalize(destination - transform.position);

            rb.MovePosition(rb.position + (unitVector * moveSpeed * Time.fixedDeltaTime));

            yield return null;
        }

        yield return new WaitForSeconds(dashCooldown);
    
        isDashing = false;
        canDash = true;
    }
}

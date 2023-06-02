using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TopDownMovement : MonoBehaviour
{
    public GameObject boxToGenerate;
    [SerializeField] private float daño;
    [SerializeField] private float vida;
    private float horizontalInput;
    public bala proyectilprefab;
        public Transform LanuchOffset;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private Animator Animator;
    private Rigidbody2D rb2D;

    private float yInfLimit = -16.9f;
    private float ySupLimit = 16.0f;
    private float xLeftLimit = -28.41f;
    private float xRightLimit = 11.43f;
    public static float dir = 0;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Invoke("crearzombie", 2f);
    }

    private void crearzombie()
    {
        Instantiate(boxToGenerate);
        
        //Instantiate(boxToGenerate);
        //Destroy(go, 1); //Destroy after 5 seconds.
        //Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            TomarDaño(daño);
           
        }

    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f)
        {
            dir = 1;
        }
         if (horizontalInput < -0.01f)
        {
            dir = 2;
        }
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;    
        
    }

    private void FixedUpdate()
    {
        ChangeBodyDirection();
        SetAnimatorValue();
        MovePlayer();
    }

    private void ChangeBodyDirection() 
    {

        float scaleX = transform.localScale.x;
        if ((direction.x < 0.0f && scaleX > 0.0f) || (direction.x > 0.0f && scaleX < 0.0f))
        {

            transform.localScale = new Vector3(
                    -1 * scaleX,
                    transform.localScale.y,
                    transform.localScale.z
            );
        }

    }

    private void SetAnimatorValue()
    {
        Animator.SetBool("Running", direction.x != 0 || direction.y != 0);
    }

    private void MovePlayer() 
    {
        LimitMovement();
        rb2D.MovePosition(rb2D.position + direction * speed * Time.fixedDeltaTime);
    }

    private void LimitMovement() 
    {
        if (rb2D.position.x < xLeftLimit && rb2D.position.y < yInfLimit)
        {
            rb2D.position = new Vector2(xLeftLimit, yInfLimit);
        }
        else if (rb2D.position.x > xRightLimit && rb2D.position.y < yInfLimit)
        {
            rb2D.position = new Vector2(xRightLimit, yInfLimit);
        }
        else if (rb2D.position.x < xLeftLimit && rb2D.position.y > ySupLimit)
        {
            rb2D.position = new Vector2(xLeftLimit, ySupLimit);
        }
        else if (rb2D.position.x > xRightLimit && rb2D.position.y > ySupLimit)
        {
            rb2D.position = new Vector2(xRightLimit, ySupLimit);
        }
        else if (rb2D.position.x < xLeftLimit && VerticalMoveIsValid())
        {
            rb2D.position = new Vector2(xLeftLimit, rb2D.position.y);
        }
        else if (rb2D.position.x > xRightLimit && VerticalMoveIsValid())
        {
            rb2D.position = new Vector2(xRightLimit, rb2D.position.y);
        }
        else if (rb2D.position.y < yInfLimit && HorizontalMoveIsValid())
        {
            rb2D.position = new Vector2(rb2D.position.x, yInfLimit);
        }
        else if (transform.position.y > ySupLimit && HorizontalMoveIsValid())
        {
            rb2D.position = new Vector2(rb2D.position.x, ySupLimit);
        }
    }

    private Boolean VerticalMoveIsValid()
    {
        return transform.position.y >= yInfLimit && transform.position.y <= ySupLimit;
    }

    private Boolean HorizontalMoveIsValid()
    {
        return transform.position.x >= xLeftLimit && transform.position.x <= xRightLimit;
    }

}

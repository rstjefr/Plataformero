using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb2D;

    private float move;


    //variables de salto
    public float FuerzaSalto = 4f;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        if(move != 0)
        {
                       transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }

        //condicional de salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, FuerzaSalto);
        }
    }

    //Detectar si el jugador esta tocando el suelo
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}

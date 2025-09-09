using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rigd; 
    public float speed; //colocar velocidade no boneco

    public float jumpForce = 7f;
    public bool isground; //verificar se ta no chão

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        anim = GetComponent<Animator>();
        rigd = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move ()
    {
        float teclas = Input.GetAxis("Horizontal");
        rigd.linearVelocity = new Vector2(teclas * speed, rigd.linearVelocity.y); 

        if (teclas > 0 && isground == true) 
        {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetInteger("transition", 1);
        }
        if (teclas < 0 && isground == true) 
        {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetInteger("transition", 1);
        }

        if (teclas == 0 && isground == true) 
        
            anim.SetInteger("transition", 0);
        }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isground == true)
        {
            rigd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetInteger("transition", 2);
            isground = false;
        }
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tagGround")
        {
            isground = true;
            Debug.Log("esta no chão");
        }
    }
}

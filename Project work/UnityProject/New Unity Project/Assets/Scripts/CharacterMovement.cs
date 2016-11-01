using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

    public float speed, jumpPower;
    private Vector2 velocity;

    public LayerMask lyrGround;
    public Transform feet;

    public KeyCode keyLeft, keyLeftAlt;
    public KeyCode keyRight, keyRightAlt;
    public KeyCode keyJump, keyJumpAlt;
   
    public bool grounded;

    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = GetComponent<Transform>().localScale;
    }

    private void handleInput()
    {
        if (Input.GetKey(keyLeft) || Input.GetKey(keyLeftAlt))
        {
            velocity.x = -speed;
            GetComponent<Animator>().SetBool("Walking", true);
            GetComponent<Transform>().localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z);
        }
        else if (Input.GetKey(keyRight) || Input.GetKey(keyRightAlt))
        {
            velocity.x = speed;
            GetComponent<Animator>().SetBool("Walking", true);
            GetComponent<Transform>().localScale = new Vector3(defaultScale.x, defaultScale.y, defaultScale.z);

        }
        else
        {
            velocity.x = 0;
            GetComponent<Animator>().SetBool("Walking", false);
        }

        if ((Input.GetKeyDown(keyJump) || Input.GetKeyDown(keyJumpAlt)) && grounded)
        {
            velocity.y = jumpPower;
        }
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, 0.5f, lyrGround);

        handleInput();

        velocity *= Time.deltaTime;

        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, GetComponent<Rigidbody2D>().velocity.y + velocity.y);

        velocity = Vector2.zero;
    }

}
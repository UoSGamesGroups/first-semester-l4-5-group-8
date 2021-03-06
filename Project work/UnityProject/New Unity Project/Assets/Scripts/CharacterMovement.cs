﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{

	public KeyCode keyLeft, keyRight, keyJump, keyDown, keySpace;

    public int SceneID;

    public float speed, jumpPower, climbSpeed;

    public bool grounded, climbing, jumping, interact;

    private Vector3 defaultScale;
    private Vector2 velocity;

    public LayerMask layerGround;
    public Transform feet;

    private void Start()
    {
        defaultScale = GetComponent<Transform>().localScale;
	}

    private void UserInput()
	{
		if (Input.GetKey (keyLeft)) {
			velocity.x = -speed;
			GetComponent<Animator> ().SetBool ("Walking", true);
			GetComponent<Transform> ().localScale = new Vector3 (-defaultScale.x, defaultScale.y, defaultScale.z);
		} else if (Input.GetKey (keyRight)) {
			velocity.x = speed;
			GetComponent<Animator> ().SetBool ("Walking", true);
			GetComponent<Transform> ().localScale = new Vector3 (defaultScale.x, defaultScale.y, defaultScale.z);

		} else {
			velocity.x = 0;
			GetComponent<Animator> ().SetBool ("Walking", false);
		}
			
        if(climbing)
        {
            if (Input.GetKey(keyJump))
            {
                velocity.y = climbSpeed;
            }
            else if(Input.GetKey(keyDown))
            {
                velocity.y = -climbSpeed;
            }
            else
            {
                velocity.y = 0;
            }

        }
        else
        {
            if ((Input.GetKeyDown(keyJump)) && grounded)
            {
                velocity.y = jumpPower;
            }
        }
			
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, 0.5f, layerGround);
        GetComponent<Animator>().SetBool("Jump", !grounded);

        UserInput();

        velocity *= Time.deltaTime;

        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, GetComponent<Rigidbody2D>().velocity.y + velocity.y);

        velocity = Vector2.zero;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ladder"){

            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            climbing = true;
        }

        if (collision.gameObject.tag == "Boulder" || collision.gameObject.tag == "Spikes") {
            Death();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ladder"){

            GetComponent<Rigidbody2D>().gravityScale = 15;
            climbing = false;
        }
    }

    public void Death() {
        SceneManager.LoadScene(SceneID);
    }

}
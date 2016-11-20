using UnityEngine;
using System.Collections;

public class Door_Open : MonoBehaviour {

	public SpriteRenderer SR;
	public BoxCollider2D BC;
	public KeyCode keySpace;

	// Use this for initialization
	void Start () {

		SR = gameObject.GetComponent<SpriteRenderer> ();
		BC = gameObject.GetComponent<BoxCollider2D> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (Input.GetKey(keySpace))
			{
				SR.enabled = false;
				BC.enabled = false;
			}
		}
	}

	public void OpenDoor()
	{
		GameObject.FindGameObjectsWithTag ("Lever");
		{
			if ("Lever" == null)
			{
				SR.enabled = false;
				BC.enabled = false;
			}
		}
	}
}


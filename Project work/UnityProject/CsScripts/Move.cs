using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public float speed = 1.0F;
	public float jump = 1.0F;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		float move = Input.GetAxis ("Horizontal");

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x--;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Vector3 position = this.transform.position;
			position.y++;
			this.transform.position = position;
		}
	}
}
﻿using UnityEngine;
using System.Collections;

public class Disappear3 : MonoBehaviour {

	public SpriteRenderer sr;
	public KeyCode keySpace;
	public BoxCollider2D bc;

	// Use this for initialization
	void Start ()
	{
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update ()
	{

	}
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			sr.enabled = false;
			Changer ();
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			sr.enabled = true;
		}
	}

	public void Changer()
	{
		if (sr.enabled == false)
		{
			StartCoroutine (Change ());
		}
	}
	IEnumerator Change()
	{
		{
			yield return new WaitForSeconds(3);
			sr.enabled = true;
		}
	}
}
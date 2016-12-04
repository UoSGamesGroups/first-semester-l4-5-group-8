using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {

	public SpriteRenderer sr;
	public KeyCode keySpace;
	public BoxCollider2D bc;

    public int index;

    public LeverPuzzleController controller;
    
    public bool CanShow;
    private bool inTrigger;

	// Use this for initialization
	void Start ()
	{
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update ()
	{
        if ( Input.GetKeyUp(keySpace) && inTrigger)
        {
            ToggleLight();
            controller.LeverPressed(index);
        }
	}

    public void ToggleLight()
    {
        sr.enabled = !sr.enabled;
    }

    public void ShowLight()
    {
        sr.enabled = false;
    }

    public void HideLight()
    {
        sr.enabled = true;
    }

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" && !controller.ShowingLights)
		{
            inTrigger = true;
        }
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" && !controller.ShowingLights) {
            inTrigger = false;
            HideLight();
        }
	}
}
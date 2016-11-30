using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {

	public SpriteRenderer sr;
	public KeyCode keySpace;
	public BoxCollider2D bc;
	public GameObject lever, lever1, lever2, lever3, open;

    public int index;

    public LeverPuzzleController controller;
    
    public bool CanShow;
    private bool inTrigger;

	// Use this for initialization
	void Start ()
	{
		sr = gameObject.GetComponent<SpriteRenderer> ();
		lever = GameObject.Find ("Lever");
		lever1 = GameObject.Find ("Lever1");
		lever2 = GameObject.Find ("Lever2");
		lever3 = GameObject.Find ("Lever3");
		open = GameObject.Find ("Door");
	}

	// Update is called once per frame
	void Update ()
	{

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

	public void OnTriggerEnter2D(Collider2D bc)
	{
		if (bc.gameObject.tag == "Player" && !controller.ShowingLights)
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

	public void OnTriggerStay2D(Collider2D bc)
	{
		if (bc.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown (keySpace)) {
				gameObject.SetActive (false);
				Destroy (open);

			}
		}
	}
}
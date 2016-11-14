using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
        }

    }
}

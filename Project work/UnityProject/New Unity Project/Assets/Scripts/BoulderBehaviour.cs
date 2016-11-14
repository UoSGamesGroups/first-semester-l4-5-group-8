using UnityEngine;
using System.Collections;

public class BoulderBehaviour : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.tag == "Player"){
            GetComponent<Rigidbody2D>().gravityScale = 2;
        }

    }
}

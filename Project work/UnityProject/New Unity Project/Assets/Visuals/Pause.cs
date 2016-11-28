using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

public Transform canvas;

    void update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else {
                canvas.gameObject.SetActive(false);
            }
        }
    }

}

using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public GameObject canvas;

    private bool isPaused;

    public void togglePauseState()
    {
        isPaused = !isPaused;
        canvas.SetActive(isPaused);
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeverPuzzleController : MonoBehaviour {

    public Disappear[] Levers;
    public int[] PatternTimes;
    public float WaitTime;

    public bool ShowingLights;
    public bool Completed;

    public List<int> Presses;

    public Door_Open Door;

    public void LeverPressed(int index)
    {
        if(Completed)
            return;

        Presses.Add(index);

        int current = Presses.Count - 1;

        if ( Presses[current] != PatternTimes[current])
        {
            // do the reset
            Presses.Clear();

            StartCoroutine(ResetLights());
        }

        if ( current + 1 == PatternTimes.Length)
        {
            // challenge completed
            Presses.Clear();

            Door.OpenDoor();

            Completed = true;
        }
    }

    public IEnumerator ResetLights()
    {
        ShowingLights = true;

        for(int i = 0; i < Levers.Length; i++)
        {
            Levers[i].ShowLight();
        }

        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < Levers.Length; i++)
        {
            Levers[i].HideLight();
        }

        yield return new WaitForSeconds(0.2f);

        for(int i = 0; i < Levers.Length; i++)
        {
            Levers[i].ShowLight();
        }

        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < Levers.Length; i++)
        {
            Levers[i].HideLight();
        }

        ShowingLights = false;
    }

    public IEnumerator ShowChallengeLights()
    {
        for(int i = 0; i < PatternTimes.Length; i++)
        {
            Levers[PatternTimes[i]].ShowLight();

            yield return new WaitForSeconds(WaitTime);

            Levers[PatternTimes[i]].HideLight();
        }

        ShowingLights = false;        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(ShowingLights)
            return;

        ShowingLights = true;

        StartCoroutine(ShowChallengeLights());
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

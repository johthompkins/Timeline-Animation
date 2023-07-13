using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InputManager : MonoBehaviour
{
    public PlayableDirector timeline1, timeline2, timeline3; // Ref to timeline Playable directors in scene
    public GameObject stackedNum;
    public GameObject menuText;

    private bool isTimeline1Playing = false,
                 isTimeline2Playing = false,
                 isTimeline3Playing = false;


    void Start()
    {
        timeline1 = timeline1.GetComponent<PlayableDirector>();
        timeline1.stopped += OnTimeline1Stopped;

        timeline2 = timeline2.GetComponent<PlayableDirector>();
        timeline2.stopped += OnTimeline2Stopped;

        timeline3 = timeline3.GetComponent<PlayableDirector>();
        timeline3.stopped += OnTimeline3Stopped;

    }

    void Update()
    {
        if(!isTimeline1Playing && !isTimeline2Playing && !isTimeline3Playing)
        {
            foreach (Transform child in stackedNum.GetComponentInChildren<Transform>())
            {
                child.gameObject.SetActive(true);
            }

            foreach (Transform child in menuText.GetComponentInChildren<Transform>())
            {
                child.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayTimeline1();
            }
        }
        

    }
    public void PlayTimeline1()
    {
        foreach (Transform child in stackedNum.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }

        foreach (Transform child in menuText.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }

        timeline1.Play();
        isTimeline1Playing = true;
    }

    private void OnTimeline1Stopped(PlayableDirector director)
    {
        if (director == timeline1)
        {
            timeline2.Play();
            isTimeline2Playing = true;
            isTimeline1Playing = false;
        }
    }

    private void OnTimeline2Stopped(PlayableDirector director)
    {
        if (director == timeline2)
        {
            timeline3.Play();
            isTimeline3Playing = true;
            isTimeline2Playing = false;
        }
    }

    private void OnTimeline3Stopped(PlayableDirector director)
    {
        if (director == timeline3)
        {
            isTimeline3Playing = false;
        }
    }
}

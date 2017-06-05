using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class CustomTrackHandler : MonoBehaviour, ITrackableEventHandler
{

    public string name;

    void Start()
    {
        if (GetComponent<TrackableBehaviour>())
        {
            GetComponent<TrackableBehaviour>()  .RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    void OnTrackingFound()
    {
        GameObject.FindObjectOfType<GameController>().StartGame(name);
    }

    void OnTrackingLost()
    {

    }

}

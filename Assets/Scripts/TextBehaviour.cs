using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBehaviour : MonoBehaviour {
    Vector3 direction;
    public float speed;
    public bool isCorrect;
	// Use this for initialization
	void Start () {
        direction = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0);
        speed = Random.Range(0.1f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform);
        transform.RotateAround(Camera.main.transform.up, direction, speed);
	}

    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<GameController>().UpdateScore(isCorrect);
        Destroy(transform.gameObject);
    }
}

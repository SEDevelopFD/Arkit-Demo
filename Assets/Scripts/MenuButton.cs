using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {
    private Text text;
    [SerializeField]
    private float interval;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponentInChildren<Text>();
        RectTransform canvas = transform.parent.GetComponent<RectTransform>();
        float canvasWidth = canvas.rect.width;
        float canvasHeight = canvas.rect.height;
        RectTransform button = gameObject.GetComponent<RectTransform>();
        if(text.text=="Menu")
        {
            transform.position = transform.position + new Vector3(-canvasWidth / 2+button.rect.height/2,
                canvasHeight / 2 - button.rect.width / 2-interval, 0);
            Debug.Log(new Vector3(-canvasWidth / 2 + button.rect.height / 2,
                canvasHeight / 2 - button.rect.width / 2 - interval, 0));
        }
        else if(text.text=="Close")
        {
            transform.position = transform.position + new Vector3(canvasWidth / 2-button.rect.height/2,
                canvasHeight / 2 - button.rect.width / 2 - interval, 0);
            Debug.Log(new Vector3(canvasWidth / 2 - button.rect.height / 2,
                canvasHeight / 2 - button.rect.width / 2 - interval, 0));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class JoyStickController : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler{

    public float maxDragDistance = 50f;
    public Vector3 direction;
    public Vector3 initPos;
    public Vector3 dragPos;
	// Use this for initialization
    private static JoyStickController _instance;

    public static JoyStickController instance
    {
        get 
        { 
            return _instance; 
        }
    }
    public Vector3 GetDirction()
    {
        return direction.normalized;
    }
    void Awake()
    {
        _instance = this;
    }
	void Start () {
        initPos = transform.position;
        Debug.Log(initPos);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log(Input.mousePosition);
        dragPos = Input.mousePosition;
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        float dis = Vector3.Distance(dragPos, Input.mousePosition);
        direction = Input.mousePosition - dragPos;
        if(dis>=maxDragDistance)
        { dis = maxDragDistance; }
        transform.localPosition = direction.normalized * dis;

        Debug.Log("OnDrag");

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = initPos;
        direction = Vector3.zero;

        Debug.Log("OnEndDrag");
        Debug.Log(transform.position);

    }
}

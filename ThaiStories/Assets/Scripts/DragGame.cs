using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragGame : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject DraggedInstance;

    Vector3 startPos;
    Vector3 offset;
    float distCam;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*Start collision section*/
    void OnCollisionEnter(Collision collision)
    {
        //check what it collided with

        //if question 1

            //check answer

        //if question 2
            
            //check answer

        //if question 3

            //check answer
    }


    /*End collision section*/

    /*Start drag section*/
    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedInstance = gameObject;
        startPos = transform.position;
        distCam = Mathf.Abs(startPos.z - Camera.main.transform.position.z);
        offset = startPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distCam));
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1) { return; }
        else
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distCam)) + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedInstance = null;
        offset = Vector3.zero;
    }
    /*End drag section*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCheck : MonoBehaviour
{
    RectTransform rect;
    public bool inside;
    Vector3[] corners;
    Vector3 mousePosition;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        corners =  new Vector3[4];
        rect.GetWorldCorners(corners);
    }
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       if ((mousePosition.x > corners[0].x) && (mousePosition.y > corners[0].y) && (mousePosition.x < corners[2].x) && (mousePosition.y < corners[2].y))
       {
            inside = true;
       }
       else
       {
            inside = false;
       }

    }
}

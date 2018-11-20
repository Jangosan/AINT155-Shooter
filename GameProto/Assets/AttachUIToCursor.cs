using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachUIToCursor : MonoBehaviour {
    //Variable to hold the target of the camera
    public Vector2 cursor;


    public Canvas UItoFollowCursor;
    //Used to smooth the movement of the camera
    public float cameraSmooth = 400.0f;

    private void Start()
    {

        Vector2 pos;

        cursor = Input.mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(UItoFollowCursor.transform as RectTransform, cursor, UItoFollowCursor.worldCamera, out pos);

        

    }

    //Moves the camera towards the target over time
    private void Update()
    {

        Vector2 movePos;

        cursor = Input.mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(UItoFollowCursor.transform as RectTransform, cursor, UItoFollowCursor.worldCamera, out movePos);

        transform.position = UItoFollowCursor.transform.TransformPoint(movePos);
    }
}

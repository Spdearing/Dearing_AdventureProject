using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject squarePrefab;


    // Update is called once per frame
    void Update()
    {
        //this code will only work on touch screen devices

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            if (t.phase == TouchPhase.Began)
            {
                GameObject square = Instantiate(squarePrefab);
                square.name = "Touch" + t.fingerId;
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 11));
                square.transform.position = pos;
            }
            else if (t.phase == TouchPhase.Moved)
            {

                GameObject square = GameObject.Find("Touch " + t.fingerId);
                square.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 11));
                if (t.deltaPosition.x > 100)
                {
                    Debug.Log("Swiping right ");
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                GameObject square = GameObject.Find("Touch " + t.fingerId);
                Destroy(square);
            }
            else
            {
                Debug.Log("Something went wrong with touch " + t.fingerId);
            }
        }

        //only one touch needed
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
        }
    }
}

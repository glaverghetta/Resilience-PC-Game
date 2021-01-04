using UnityEngine;
using System.Collections;

public class PressButtons : MonoBehaviour
{

    public float range = 1f;

    public Camera cam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Press();
        }
    }

    void Press()
    {
        /* Cast an invisible ray outward from the direction of the camera. If it hits a button, it should perform the appropriate action */
        RaycastHit hit;                     
        if( Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) )
        {
            if (hit.transform.name == "Button1")
            {
                GameObject Door = GameObject.Find("Door1");
                Vector3 distance = new Vector3(0, 2.5f, 0);
                StartCoroutine( MoveOverSeconds(Door, Door.transform.position - distance, 1f) );  //change the position of the door's y coordinate over 1 second
            }
        }
    }

    IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        //transform.position = end;
    }
}

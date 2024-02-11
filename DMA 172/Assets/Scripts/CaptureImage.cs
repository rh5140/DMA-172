using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //https://gamedevbeginner.com/how-to-capture-the-screen-in-unity-3-methods/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(TakeScreenshot());
        }
    }

    IEnumerator TakeScreenshot()
    {
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot("Assets/Screenshots/screenshot" + System.DateTime.Now.ToString("MM-dd-yy_(HH-mm-ss)") + ".png"); // need to have unique filename so distinguishable
        Debug.Log("a screenshot was taken!");
    }
}

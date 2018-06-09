using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.IO;
using System;
using System.Runtime.InteropServices;

public class ObjectDetect : MonoBehaviour
{

    private Texture2D screenCap;
    private Texture2D border;

    private Camera camera;
    private Rect cameraRect;

    // Use this for initialization
    void Start ()
    {
        camera = GetComponent<Camera>();
        cameraRect = camera.pixelRect;
    }

    // Update is called once per frame
    void Update()
    {
        //If end user clicks mouse, take a screen capture
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StartCoroutine("Capture");
        }
    }
	
	 //PInvoke
    [DllImport("OpenCVDotNet.dll")]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static extern string DetectObjectsInImage(IntPtr p, int size);

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();

        screenCap = new Texture2D((int)cameraRect.width, (int)cameraRect.height, TextureFormat.RGB24, false);
        screenCap.ReadPixels(new Rect(cameraRect.x, cameraRect.y, cameraRect.width, cameraRect.height), 0, 0);
        screenCap.Apply();

        // Encode texture into PNG
        byte[] imageData = screenCap.EncodeToJPG();

        IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(byte)) * imageData.Length);
        Marshal.Copy(imageData, 0, p, imageData.Length);
        string detectedObject = DetectObjectsInImage(p, imageData.Length);
        Marshal.FreeHGlobal(p);

        Debug.Log(detectedObject);

        //string fileName = "/SavedScreen" + DateTime.Now.Ticks.ToString() + ".jpg";

        // For testing purposes, also write to a file in the project folder
        // File.WriteAllBytes(Application.dataPath + fileName, bytes);


    }
}

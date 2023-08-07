using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] [Range (3f, 100f)]float mouseSensetivity;
    [SerializeField] GameObject body;
  
    [SerializeField] GameObject head;
    private float xRotation = 0;
    private float yRotation = 0;
   
    private float eulerY = 0;
    private float eulerX = 0;

    private bool isPaused = false;


    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!isPaused) {
            xRotation = mouseSensetivity * Input.GetAxis("Mouse X") * Time.deltaTime;
            yRotation = mouseSensetivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

            eulerX += xRotation;
            eulerY -= yRotation;
            eulerY = Mathf.Clamp(eulerY, -90f, 90f);
            
            transform.localRotation = Quaternion.Euler(eulerY, 0f, 0f);
            head.transform.rotation = Quaternion.Euler(xRotation, eulerY, 0f);
            body.transform.localRotation = Quaternion.Euler(0f , eulerX, 0f);

        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
            
    }

}

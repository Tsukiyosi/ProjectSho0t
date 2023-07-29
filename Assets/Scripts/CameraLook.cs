using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] [Range (3f, 100f)]float mouseSensetivity;
    [SerializeField] GameObject body;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject head;
    private float xRotation = 0;
    private float yRotation = 0;
   
    private float eulerY = 0;

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

            eulerY -= yRotation;
            eulerY = Mathf.Clamp(eulerY, -90f, 90f);
            
            transform.localRotation = Quaternion.Euler(eulerY, xRotation, 0f);
            weapon.transform.localRotation = Quaternion.Euler(eulerY, xRotation, 0f);
            head.transform.rotation = Quaternion.Euler(xRotation, eulerY, 0f);
            body.transform.Rotate(Vector3.up * xRotation);

        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
            
    }

}

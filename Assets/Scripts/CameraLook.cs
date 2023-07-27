using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] [Range (3f, 100f)]float mouseSensetivity;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject body;
    [SerializeField] GameObject head;
    private float xRotation = 0;
    private float yRotation = 0;
   

    private float eulerX = 0;
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
            yRotation = mouseSensetivity * -Input.GetAxis("Mouse Y") * Time.deltaTime;

            eulerX = (transform.rotation.eulerAngles.x + yRotation) % 360;
            eulerY = (transform.rotation.eulerAngles.y + xRotation) % 360;

            
            transform.rotation = Quaternion.Euler(eulerX, eulerY, 0f);
            weapon.transform.rotation = Quaternion.Euler(eulerX, eulerY, 0f);
            head.transform.rotation = Quaternion.Euler(eulerX, eulerY, 0f);
            body.transform.rotation = Quaternion.Euler(0f, eulerY, 0f);

        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
            
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    #region Variables

    float mouseX;
    float mouseY;
    [Header ("Position")]
    private Vector3 origin_position;
    float amount = 0.02f;
    float maxAmount = 0.06f;
    float smoothAmount = 6f;

    [Header ("Rotation")]
    float rotationAmount = 4f;
    float maxRotationAmount = 5f;
    float smoothRotation = 12f;
    private Quaternion origin_rotation;
    
    public bool rotationX = true;
    public bool rotationY = true;
    public bool rotationZ = true;

    #endregion

    #region Monobehaviour CallBacks
    void Start()
    {
        origin_position = transform.localPosition; 
        origin_rotation = transform.localRotation; 
    }

    void Update()
    {
        CalculateInput();
        MoveSway();
        TiltSway();
    }
    #endregion

    #region Private Methods

    private void CalculateInput()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }
    private void MoveSway(){
        float moveX = Mathf.Clamp(mouseX * amount, -maxAmount, maxAmount);
        float moveY = Mathf.Clamp(mouseY * amount, -maxAmount, maxAmount);

        Vector3 finalPosition = new Vector3(moveX, moveY, 0f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + origin_position, Time.deltaTime *smoothAmount);
    }

    private void TiltSway(){
        float tiltY = Mathf.Clamp(mouseY * rotationAmount, -maxRotationAmount, maxRotationAmount);
        float tiltX = Mathf.Clamp(mouseX * rotationAmount, -maxRotationAmount, maxRotationAmount);

        Quaternion finalRotation = Quaternion.Euler(new Vector3
        (rotationX ? -tiltX: 0f, 
        rotationY ? tiltY: 0f, 
        rotationZ ? tiltY : 0f));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * origin_rotation, Time.deltaTime * smoothRotation);
    }
    #endregion
}

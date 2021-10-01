using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraPosition;
    public float cameraHeight;
    public float cameraAngle;
    public float zoomSensibility = 20;

    public float cameraSensibility = 8;

    private bool isFree = false;

    private float minHeight = 6f;
    private float maxHeight = 25f;
    private float minRot = 50f;
    private float maxRot = 70f;
    private float minPosition = 5f;
    private float maxPosition = 11f;

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        MouseZoom();
    }

    void MouseZoom()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            if (cameraHeight > minHeight)
            {
                cameraPosition -= ((maxPosition - minPosition) / zoomSensibility) * Time.deltaTime * 10;
                cameraHeight -= ((maxHeight - minHeight) / zoomSensibility) * Time.deltaTime * 10;
                cameraAngle -= ((maxRot - minRot) / zoomSensibility) * Time.deltaTime * 10;
            }
        }
        else if (Input.GetKey(KeyCode.KeypadMinus))
        {
            if (cameraHeight < maxHeight)
            {
                cameraPosition += ((maxPosition - minPosition) / zoomSensibility) * Time.deltaTime * 10;
                cameraHeight += ((maxHeight - minHeight) / zoomSensibility) * Time.deltaTime * 10;
                cameraAngle += ((maxRot - minRot) / zoomSensibility) * Time.deltaTime * 10;
            }
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            if (cameraHeight < maxHeight)
            {
                cameraPosition += (maxPosition - minPosition) / zoomSensibility;
                cameraHeight += (maxHeight - minHeight) / zoomSensibility;
                cameraAngle += (maxRot - minRot) / zoomSensibility;
            }
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            if (cameraHeight > minHeight)
            {
                cameraPosition -= (maxPosition - minPosition) / zoomSensibility;
                cameraHeight -= (maxHeight - minHeight) / zoomSensibility;
                cameraAngle -= (maxRot - minRot) / zoomSensibility;
            }
        }

        if(cameraHeight < minHeight)
        {
            cameraHeight = minHeight;
            cameraPosition = minPosition;
            cameraAngle = minRot;
        }
        else if (cameraHeight > maxHeight)
        {
            cameraHeight = maxHeight;
            cameraPosition = maxPosition;
            cameraAngle = maxRot;
        }
    }
    void CameraMove()
    {
        if (isFree)
        {
            if (Input.GetMouseButtonDown(2))
            {
                isFree = false;
            }
            FreeCamera();
        }
        else
        {
            if (Input.GetMouseButtonDown(2))
            {
                isFree = true;
            }
            LockedCamera();            
        }
    }

    void FreeCamera()
    {
        Vector3 translation = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (translation.x >= 0.9 || translation.y >= 0.9 || translation.x <= 0.1 || translation.y <= 0.1)
        {
            transform.position = new Vector3(transform.position.x + ((translation.x * 2) - 1) * Time.deltaTime * cameraSensibility, transform.position.y, transform.position.z + ((translation.y * 2) - 1) * Time.deltaTime * cameraSensibility);
        }
    }

    void LockedCamera()
    {
        if (playerTransform != null && transform != null)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraHeight, playerTransform.position.z - cameraPosition);
            transform.rotation = Quaternion.Euler(cameraAngle, 0, 0);
        }
    }
}

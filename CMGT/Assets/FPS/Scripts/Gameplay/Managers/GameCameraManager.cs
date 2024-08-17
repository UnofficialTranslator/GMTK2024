using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameCameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] Cameras;
    CinemachineVirtualCamera ActiveCamera;

    private void Start()
    {
        ActiveCamera = Cameras[5];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = ActiveCamera.GetComponent<Camera>().ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.tag == "CamTrigger")
                {
                    ChangeCam(hit.collider.gameObject.GetComponent<ClickChangeCam>().CamID);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCam(5);
        }
    }

    void ChangeCam(int ID)
    {
        foreach (CinemachineVirtualCamera c in Cameras)
        {
            if (c != null)
            {
                c.Priority = 1;
            }
        }

        Cameras[ID].Priority = 10;
    }
    
}

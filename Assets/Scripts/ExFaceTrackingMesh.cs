#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARFaceManager))]

public class ExFaceTrackingMesh : MonoBehaviour
{
    [SerializeField] Text message;
    [SerializeField] ARCameraManager cameraManager;
    ARFaceManager faceManager;
    bool isReady;

    void ShowMessage(string text)
    {
        message.text = $"{text}\r\n";
    }

    void AddMessage(string text)
    {
        message.text += $"{text}\r\n";
    }

    void Awake()
    {
        if (message == null)
        {
            Application.Quit();
        }

        faceManager = GetComponent<ARFaceManager>();
        if (cameraManager == null || faceManager == null || faceManager.facePrefab == null)
        {
            isReady = false;
            ShowMessage("error:SerializeField");
        }
        else
        {
            isReady = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady) return;

        ShowMessage("detecting face");
        AddMessage($"MeshUVsSupport: >>> {faceManager.descriptor.supportsFaceMeshUVs}");
        AddMessage($"direction of the current camera: {cameraManager.currentFacingDirection}");
        AddMessage($"the number of face: >>> {faceManager.supportedFaceCount}");
        AddMessage($"the maximum number of detecting face: >>> {faceManager.currentMaximumFaceCount}");
        AddMessage($"the number of detecting face currently: {faceManager.trackables.count}");
    }
}

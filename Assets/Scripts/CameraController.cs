using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CameraThreshold
{
    public CinemachineVirtualCamera Camera;
    public int Score;
}

public class CameraController : MonoBehaviour
{
    [SerializeField] private List<CameraThreshold> _cameras;

    public void ScoreUpdate(float score)
    {
        Debug.Log($"Score: {score}");

        foreach (CameraThreshold camera in _cameras)
        {
            camera.Camera.Priority = score > camera.Score ? camera.Score : 0;
        }
    }
}

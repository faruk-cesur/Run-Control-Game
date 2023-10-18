using System;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _firstVirtualCamera;
    [SerializeField] private CinemachineVirtualCamera _secondVirtualCamera;
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    public bool IsCameraBlendCompleted => _cinemachineBrain.IsBlending && (_cinemachineBrain.ActiveBlend.TimeInBlend + 0.05f >= _cinemachineBrain.ActiveBlend.Duration || !_cinemachineBrain.ActiveBlend.IsValid);

    public void EnableFirstVirtualCamera()
    {
        _firstVirtualCamera.Priority = 1;
        _secondVirtualCamera.Priority = 0;
    }

    public void EnableSecondVirtualCamera()
    {
        _firstVirtualCamera.Priority = 0;
        _secondVirtualCamera.Priority = 1;
    }
}
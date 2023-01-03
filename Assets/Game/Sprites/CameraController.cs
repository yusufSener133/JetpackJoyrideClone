using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Character _character;

    Vector3 _distance;
    private void Start()
    {
        _distance = _camera.transform.position - _character.transform.position;
    }
    void LateUpdate()
    {
        _camera.transform.position = _character.transform.position + _distance;
    }
}

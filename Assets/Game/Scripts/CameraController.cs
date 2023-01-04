using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField,Range(-8,8)] float _offSet = 5;
    Vector3 _distance;
    
    void LateUpdate()
    {
        var targetPos = _camera.transform.position;
        targetPos.x = CharacterController.Instance.GetCharPos().x + _offSet;
        _camera.transform.position = targetPos;
    }
}

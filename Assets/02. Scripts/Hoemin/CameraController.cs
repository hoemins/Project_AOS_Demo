using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraMoveSpeed;

    public void Update()
    {
        // 문제점 : Screen.width = 상수(1920) 이므로 오른쪽으로 이동하는것은 되나 왼쪽으로 이동할 수 없음
        // 해결 : 너비 상수에 부동소수점을 곱하여 해결
        if (Input.mousePosition.x >= Screen.width * 0.95f)
            transform.position += Vector3.right * cameraMoveSpeed * Time.deltaTime;

        if (Input.mousePosition.x <= Screen.width * 0.05f)
            transform.position += Vector3.left * cameraMoveSpeed * Time.deltaTime;

        if (Input.mousePosition.y >= Screen.height * 0.95f)
            transform.position += Vector3.forward * cameraMoveSpeed * Time.deltaTime;

        if (Input.mousePosition.y <= Screen.height * 0.05f)
            transform.position += Vector3.back * cameraMoveSpeed * Time.deltaTime;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraMoveSpeed;

    public void Update()
    {
        // ������ : Screen.width = ���(1920) �̹Ƿ� ���������� �̵��ϴ°��� �ǳ� �������� �̵��� �� ����
        // �ذ� : �ʺ� ����� �ε��Ҽ����� ���Ͽ� �ذ�
        if (Input.mousePosition.x >= Screen.width * 0.98f)
            transform.position += Vector3.right * cameraMoveSpeed * Time.deltaTime;

        if (Input.mousePosition.x <= Screen.width * 0.02f)
            transform.position += Vector3.left * cameraMoveSpeed * Time.deltaTime;

        if (Input.mousePosition.y >= Screen.height * 0.98f)
            transform.position += Vector3.forward * cameraMoveSpeed * Time.deltaTime;

        if (Input.mousePosition.y <= Screen.height * 0.02f)
            transform.position += Vector3.back * cameraMoveSpeed * Time.deltaTime;

    }
}

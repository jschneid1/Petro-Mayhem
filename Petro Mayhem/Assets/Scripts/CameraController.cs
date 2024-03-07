using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private const float MIN_ZOOM = 0.0F, MAX_ZOOM = -10.0F;

    private const float MIN_FOLLOW_Y_OFFSET = 2.0f, MAX_FOLLOW_Y_OFFSET = 12.0f;
    //private CinemachineTransposer _cinemachineTransposer;
    //private CinemachineVirtualCamera _cinemachineVirtualCamera;


    private Vector3 _targetFollowOffset;
    // Start is called before the first frame update
    void Start()
    {
        //_cinemachineVirtualCamera = Cinemachine.GetCinemachineComponent<CinemachineVirtualCamera>();
        //_targetFollowOffset = _cinemachineTransposer.m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraMovement();
        HandleCameraRotation();
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        HandleCameraZoom(scrollWheel);
    }

    private void HandleCameraMovement()
    {
        Vector3 inputMoveDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1.0f;
        }

        float cameraMoveSpeed = 10.0f;

        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += moveVector * cameraMoveSpeed * Time.deltaTime;
    }

    private void HandleCameraRotation()
    {
        Vector3 cameraRotationVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            cameraRotationVector.y = +1.0f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            cameraRotationVector.y = -1.0f;
        }

        float cameraRotationSpeed = 100.0f;
        transform.eulerAngles += cameraRotationVector * cameraRotationSpeed * Time.deltaTime;
    }

    private void HandleCameraZoom(float zoomInput)
    {
        float zoomSpeed = 2.0f;

        Vector3 inputMoveDir = new Vector3(0, 0, 0);

        if (Input.mouseScrollDelta.y > 0)
        {
            inputMoveDir.y = -1.0f;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            inputMoveDir.y = +1.0f;
        }

        if(transform.position.y <= MIN_ZOOM && transform.position.y >= MAX_ZOOM) 
        {
            Vector3 moveVector = transform.up * inputMoveDir.y;
            transform.position += moveVector * zoomSpeed;
        }
        
        if(transform.position.y < MAX_ZOOM)
        {
            transform.position = MAX_ZOOM * transform.up;
        }

        if (transform.position.y > MIN_ZOOM)
        {
            transform.position = MIN_ZOOM* transform.up;
        }
    }
}

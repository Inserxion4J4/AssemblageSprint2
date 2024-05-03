using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class AimZoomController : MonoBehaviour
{
    public CinemachineFreeLook freelookCamera;
    public InputActionReference aimAction;
    public InputActionReference zoomAction;

    public float sensitivity = 1f;
    public float zoomSpeed = 1f;
    public float minZoom = 5f;
    public float maxZoom = 20f;

    private bool isAiming = false;
    private float currentZoom = 10f;
    private float originalZoom = 10f;

    private void Start()
    {
        originalZoom = currentZoom;
    }

    private void OnEnable()
    {
        aimAction.action.started += AimStarted;
        aimAction.action.canceled += AimCanceled;
        zoomAction.action.performed += ZoomPerformed;
        zoomAction.action.canceled += ZoomCanceled;

        aimAction.action.Enable();
        zoomAction.action.Enable();
    }

    private void OnDisable()
    {
        aimAction.action.started -= AimStarted;
        aimAction.action.canceled -= AimCanceled;
        zoomAction.action.performed -= ZoomPerformed;
        zoomAction.action.canceled -= ZoomCanceled;

        aimAction.action.Disable();
        zoomAction.action.Disable();
    }

    private void AimStarted(InputAction.CallbackContext context)
    {
        isAiming = true;
    }

    private void AimCanceled(InputAction.CallbackContext context)
    {
        isAiming = false;
    }

    private void ZoomPerformed(InputAction.CallbackContext context)
    {
        float zoomInput = context.ReadValue<float>();
        currentZoom -= zoomInput * zoomSpeed * Time.deltaTime;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        freelookCamera.m_Lens.FieldOfView = currentZoom;
    }

    private void ZoomCanceled(InputAction.CallbackContext context)
    {
        currentZoom = originalZoom;
        freelookCamera.m_Lens.FieldOfView = currentZoom;
    }

    private void Update()
    {
        if (isAiming)
        {
            Vector2 aimInput = aimAction.action.ReadValue<Vector2>();

            Vector3 rotationDelta = new Vector3(-aimInput.y, aimInput.x, 0) * sensitivity;
            freelookCamera.m_XAxis.Value += rotationDelta.y;
            freelookCamera.m_YAxis.Value += rotationDelta.x;
        }
    }
}

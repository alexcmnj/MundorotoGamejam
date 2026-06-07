using System.Collections;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Movimiento")]
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public float jumpForce = 5f;
    public float gravity = -20f;

    [Header("Salto - Sincronización")]
    public float jumpDelay = 0f;

    [Header("Cámara")]
    public Transform cameraPivot;
    public float mouseSensitivity = 2f;
    public float maxLookUp = 80f;
    public float maxLookDown = 80f;

    private CharacterController cc;
    private Animator animator;
    private Vector3 velocity;
    private bool isGrounded;
    private bool wasGrounded;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        UpdateAnimator();
    }

    void LateUpdate()
    {
        HandleCamera();
    }

    void HandleCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookUp, maxLookDown);
        yRotation += mouseX;

        // Reseteamos la posición local para neutralizar cualquier offset del hueso
        cameraPivot.localPosition = Vector3.zero;

        // Rotación local: anulamos la rotación heredada del hueso y aplicamos solo el mouse
        cameraPivot.localRotation = Quaternion.Euler(0f, 0f, xRotation);

        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    void HandleMovement()
    {
        isGrounded = cc.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && z > 0;
        float currentSpeed = isSprinting ? runSpeed : walkSpeed;

        Vector3 camForward = new Vector3(-cameraPivot.right.x, 0f, -cameraPivot.right.z).normalized;
        Vector3 camRight = new Vector3(cameraPivot.forward.x, 0f, cameraPivot.forward.z).normalized;

        Vector3 move = camRight * x + camForward * z;
        cc.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            StartCoroutine(DelayedJump());
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }

    IEnumerator DelayedJump()
    {
        yield return new WaitForSeconds(jumpDelay);
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
    }

    void UpdateAnimator()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float speed = new Vector2(x, z).magnitude;
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && z > 0;

        animator.SetFloat("Speed", speed);
        animator.SetBool("InSprinting", isSprinting);
        animator.SetBool("IsGrounded", isGrounded);

        if (!wasGrounded && isGrounded)
            animator.SetTrigger("Land");

        wasGrounded = isGrounded;
    }

    public void TriggerRecoger() => animator.SetTrigger("Pickup");
    public void TriggerRecogerMedio() => animator.SetTrigger("PickupMid");
    public void TriggerPoner() => animator.SetTrigger("Put");
    public void TriggerTalar() => animator.SetTrigger("Chop");
}

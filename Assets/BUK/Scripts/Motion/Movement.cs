using UnityEngine;
using UnityEngine.InputSystem;

namespace Buk.Motion
{
  [RequireComponent(typeof(CapsuleCollider))]
  public class Movement : MonoBehaviour
  {
    // Two axis movement forward/backward and left/right
    [Header("Movement")]
    public InputAction move;
    // Single button to jump
    [Header("Jump")]
    public InputAction jump;
    // Single axis rotation left/right
    [Header("Rotate")]
    public InputAction rotate;
    [Header("Speed and acceleration")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateVelocity = 3f;

    private new CapsuleCollider collider;
    private Rigidbody body;
    private bool onGround = false;
    // The camera for the player.
    [SerializeField] private new Camera camera;
    private Vector2 rotation;


    [SerializeField] private CatchBirds birbScript;
    public void Awake()
    {
      collider = GetComponent<CapsuleCollider>();
      body = collider.attachedRigidbody;
      if (jump != null) {
        jump.performed += Jump;
      }
      move?.Enable();
      jump?.Enable();
      rotate?.Enable();
    }

    public void Jump(InputAction.CallbackContext _)
    {
      birbScript.GrabBird();
    }
    public void FixedUpdate()
    {
      var newOnGround = body.SweepTest(-transform.up, out var _, 0.1f);
      if (onGround != newOnGround) {
        onGround = newOnGround;
        //Debug.Log($"Player is {(onGround ? "on" : "off")} the ground.");
      };
      // Rotate character in VR using controller, this value is always zero if using mouse look on the PC.
      rotation = rotate?.ReadValue<Vector2>() ?? Vector2.zero;
      var movement = move?.ReadValue<Vector2>() ?? Vector2.zero;

      body.velocity = (Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0) * new Vector3(movement.x * speed, body.velocity.y, movement.y * speed));
      
    }
    void LateUpdate(){
        // Rotate the player, not the RigidBody (which is rotation locked relative to the player)
        transform.localRotation *= Quaternion.AngleAxis(rotation.x * rotateVelocity, Vector3.up);
    }
    public void OnDestroy() {
      if (jump != null) {
        jump.performed -= Jump;
      }
    }
  }
}

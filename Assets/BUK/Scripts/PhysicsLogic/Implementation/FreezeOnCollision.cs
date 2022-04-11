using UnityEngine;

namespace Buk.PhysicsLogic.Implementation
{
  [RequireComponent(typeof(Collider))]
  public class FreezeOnCollision : MonoBehaviour
  {
    private bool expended = false;
    public float freezeTime = 5f;

    public void OnCollisionEnter(Collision collisionTarget) {
      if (expended) {
        return;
      }
      var freezable = collisionTarget.gameObject.GetComponentInChildren<Freezable>();
      if (freezable != null) {
        freezable.Freeze(freezeTime);
      }
      GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }
  }
}

using UnityEngine;

namespace Buk.PhysicsLogic.Implementation
{
  [RequireComponent(typeof(Collider))]
  public class CollisionDestroyer : MonoBehaviour
  {
    public void OnCollisionEnter(Collision collisionTarget) {
      if (collisionTarget.gameObject.CompareTag("destructible")) {
        Destroy(collisionTarget.gameObject);
      }
      if (gameObject.CompareTag("destructible")) {
        Destroy(gameObject);
      }
    }
  }
}

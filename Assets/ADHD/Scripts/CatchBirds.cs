using UnityEngine;

public class CatchBirds : MonoBehaviour
{
    [SerializeField] private ParticleSystem featherEffect;
    private GameObject birb;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Jump") && other.gameObject.CompareTag("lb_bird")){
            birb = other.gameObject;
            GrabBird();
        }    
    }
    public void GrabBird()
    {
        Instantiate(featherEffect, transform.position, Quaternion.identity);
        Destroy(birb);
    }
}

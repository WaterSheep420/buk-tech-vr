using UnityEngine;

public class CatchBirds : MonoBehaviour
{
    [SerializeField] private GameObject featherEffect;
    private GameObject birb;
    private bool canCatchBirb;
    private int birbsCaught;

    void Awake(){
        canCatchBirb = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lb_bird")){
            canCatchBirb = true;
            birb = other.gameObject;
        }    
    }
    void OnTriggerExit(Collider other){
        canCatchBirb = false;
    }
    public void GrabBird()
    {
        if(canCatchBirb){
            Instantiate(featherEffect, transform.position, Quaternion.identity);
        Destroy(birb);

        birbsCaught++;

        canCatchBirb = false;
        }
    }
}

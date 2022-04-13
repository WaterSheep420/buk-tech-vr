using UnityEngine;
using TMPro;

public class CatchBirds : MonoBehaviour
{
    [SerializeField] private GameObject featherEffect;
    [SerializeField] private TextMeshProUGUI birbCountText;
    private GameObject birb;
    private bool canCatchBirb;
    private int birbsLeft = 5;

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

        birbsLeft--;

        if (birbsLeft > 0)
        birbCountText.SetText("Birbs left: " + birbsLeft);
        else
        birbCountText.SetText("Yay! you caught all birbs!");
        canCatchBirb = false;
        }
    }
}

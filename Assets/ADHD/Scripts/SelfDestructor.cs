using System.Collections;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    void Awake(){

    }
    IEnumerator DestroySelf(){
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}

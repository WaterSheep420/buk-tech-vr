using System.Collections;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip sound;
    void Awake(){
        StartCoroutine(DestroySelf());
        source.PlayOneShot(sound, 0.4f);
    }
    IEnumerator DestroySelf(){
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}

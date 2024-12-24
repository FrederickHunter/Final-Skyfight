using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Explosion_Destroy : MonoBehaviour
{

    private AudioSource explodeAudio;
    public AudioClip explodeSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathTime());
        explodeAudio = GetComponent<AudioSource>();
        explodeAudio.PlayOneShot(explodeSound, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(0.3f);
        Object.Destroy(this.gameObject);
    }
}

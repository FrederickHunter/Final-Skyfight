using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_UFO_Move_Left : MonoBehaviour
{
    private AudioSource laughAudio;
    public AudioClip laughSound;

    public float speed = 5.0f;

    public GameObject ExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        laughAudio = GetComponent<AudioSource>();
        transform.position = new Vector3(80, Random.Range(-50, 50));
    }

    // Update is called once per frame
    void Update()
    {
        //UFO moves to left
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        //Destroys UFO out of bounds
        if (transform.position.x < -80)
        {
            Destroy(gameObject);
        }
    }
    //UFO Contacts enemies
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("UFO_Enemy"))
        {
            Destroy(gameObject);
            Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
        }
        if (collision2D.gameObject.CompareTag("Meteor_Enemy"))
        {
            Destroy(gameObject);
            Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
        }
        if (collision2D.gameObject.CompareTag("Fuel"))
        {
            laughAudio.PlayOneShot(laughSound, 1.0f);
        }
    }
}

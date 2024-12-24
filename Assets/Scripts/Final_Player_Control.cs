using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final_Player_Control : MonoBehaviour
{

    private Final_Game_Manager Game_Manager;

    public GameObject ExplosionPrefab;

    //Sounds
    private AudioSource fuelAudio;
    public AudioClip fuelSound;

    // Play controls
    public float speed = 3.0f;
    public float turnSpeed = 50.0f;
    public float horizontalInput;

    // Animations

    private Animator rocketAnimate;

    // Start is called before the first frame update
    void Start()
    {
        fuelAudio = GetComponent<AudioSource>();
        rocketAnimate = GetComponent<Animator>();
        Game_Manager = GameObject.Find("Game_Manager").GetComponent<Final_Game_Manager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Game_Manager.isGameOn)
        {
            //Rocket Moves Straight
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            horizontalInput = Input.GetAxis("Horizontal");

            //Turns Rocket
            transform.Rotate(Vector3.back, turnSpeed * horizontalInput * Time.deltaTime);

            //Keeps rocket in bounds
            if (transform.position.x > 50)
            {
                transform.position = new Vector3(50, transform.position.y);
            }

            if (transform.position.x < -50)
            {
                transform.position = new Vector3(-50, transform.position.y);
            }
            if (transform.position.y > 50)
            {
                transform.position = new Vector3(transform.position.x, 50);
            }

            if (transform.position.y < -50)
            {
                transform.position = new Vector3(transform.position.x, -50);
            }
        }
        if (Game_Manager.isGameOn)
        {
            rocketAnimate.SetBool("Idle_Bl", true);
        }
        if (!Game_Manager.isGameOn)
        {
            rocketAnimate.SetBool("Idle_Bl", false);
        }
    }

    //Rocket contacts enemies
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("UFO_Enemy"))
        {
            Destroy(gameObject);
            Game_Manager.GameOver();
            Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
        }
        if (collision2D.gameObject.CompareTag("Meteor_Enemy"))
        {
            Destroy(gameObject);
            Game_Manager.GameOver();
            Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
        }
        if (collision2D.gameObject.CompareTag("Fuel"))
        {
            fuelAudio.PlayOneShot(fuelSound, 1.0f);
        }
    }
}

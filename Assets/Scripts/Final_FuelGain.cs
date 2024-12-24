using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_FuelGain : MonoBehaviour
{

    private Final_Game_Manager Game_Manager;

    public GameObject ExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-49, 49), Random.Range(-49, 49));
        Game_Manager = GameObject.Find("Game_Manager").GetComponent<Final_Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("UFO_Enemy"))
        {
            Destroy(gameObject);
        }
        if (collision2D.gameObject.CompareTag("Meteor_Enemy"))
        {
            Destroy(gameObject);
            Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
        }
        if (collision2D.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Game_Manager.FuelUpdate(20);
        }
    }
}

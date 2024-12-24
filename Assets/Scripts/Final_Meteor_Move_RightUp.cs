using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Meteor_Move_Right_Up : MonoBehaviour
{
    public float speed = 1.5f;

    public GameObject ExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-100, 100), -80);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    //Meteor Contacts enemies
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Meteor_Enemy"))
        {
            Destroy(gameObject);
            Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
        }
    }
}

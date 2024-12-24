using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final_Game_Manager : MonoBehaviour
{

    //GameObjectSpawners
    public List<GameObject> UFOs;
    public List<GameObject> Meteors;
    public List<GameObject> Fuels;

    //SpawnRates
    public float UFOSpawnrate = 0.5f;
    public float MeteorSpawnrate = 10.0f;
    public float FuelSpawnrate = 4.0f;

    //Bool
    public bool isGameOn;

    //Title Start
    public GameObject Title_Screen;

    //Fuel
    public TextMeshProUGUI Fuel;
    private float FuelLeft;

    //Points
    public TextMeshProUGUI Points;
    private float PointsGain;

    //UI
    public TextMeshProUGUI Game_Over;

    //Buttons
    public Button Retry_Button;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void GameStart()
    {
        isGameOn = true;
        Title_Screen.gameObject.SetActive(false);
        StartCoroutine(SpawnUFOs());
        StartCoroutine(SpawnMeteors());
        StartCoroutine(SpawnFuels());
        FuelLeft = 100;
        PointsGain = 0;
        FuelUpdate(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOn)
        {
            //Fuel and Points
            FuelLeft -= Time.deltaTime;
            Fuel.SetText("Fuel: " + Mathf.Round((FuelLeft)));
            if (FuelLeft < 0)
            {
                GameOver();
            }

            PointsGain += Time.deltaTime;
            Points.SetText("" + Mathf.Round((PointsGain)));
        }

    }

    public void FuelUpdate(int FuelAdded)
    {
        FuelLeft += FuelAdded;
        Fuel.text = "Fuel: " + FuelLeft;
    }

    public void GameOver()
    {
        //GameOver
        Game_Over.gameObject.SetActive(true);
        Retry_Button.gameObject.SetActive(true);
        isGameOn = false;
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnUFOs()
    {
        while(isGameOn)
        {
            yield return new WaitForSeconds(UFOSpawnrate);
            int UFOindex = Random.Range(0, UFOs.Count);
            Instantiate(UFOs[UFOindex]);
        }
    }

    IEnumerator SpawnMeteors()
    {
        while(isGameOn)
        {
            yield return new WaitForSeconds(MeteorSpawnrate);
            int Meteorindex = Random.Range(0, Meteors.Count);
            Instantiate(Meteors[Meteorindex]);
        }
    }

    IEnumerator SpawnFuels()
    {
        while(isGameOn)
        {
            yield return new WaitForSeconds(FuelSpawnrate);
            int Fuelindex = Random.Range(0, Fuels.Count);
            Instantiate(Fuels[Fuelindex]);
        }
    }
}

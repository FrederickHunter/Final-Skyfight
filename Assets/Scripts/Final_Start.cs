using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_Start : MonoBehaviour
{

    private Final_Game_Manager Game_Manager;

    private Button Start_Button;

    // Start is called before the first frame update
    void Start()
    {
        Game_Manager = GameObject.Find("Game_Manager").GetComponent<Final_Game_Manager>();

        Start_Button = GetComponent<Button>();
        Start_Button.onClick.AddListener(GameOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOn()
    {
        Game_Manager.GameStart();
    }
}

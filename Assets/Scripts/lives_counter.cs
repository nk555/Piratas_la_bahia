using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lives_counter : MonoBehaviour
{
    private int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.lives<=0){
            //make a you lost popout with a button to replay or go back to main_menu
            //add the file to save resources in particular add points or special coins for shop
            SceneManager.LoadScene("main_menu_scene");
        }
    }

    void add_lives(int life){
        this.lives+=life;
    }
}

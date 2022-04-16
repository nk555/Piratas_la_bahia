using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start_game : MonoBehaviour
{
    public Button b;
    // Start is called before the first frame update
    void Start()
    {
        //b.onClick.AddListener(delegate() { startgame(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startgame(){
        SceneManager.LoadScene("Assets/Scenes/5by5.unity");
    }
}

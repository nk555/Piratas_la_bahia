using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class go_store : MonoBehaviour
{
    public Button b; 
    // Start is called before the first frame update
    void Start()
    {
        //b.onClick.AddListener(gostore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gostore(){
        SceneManager.LoadScene("Assets/Scenes/store.unity");
    }
}

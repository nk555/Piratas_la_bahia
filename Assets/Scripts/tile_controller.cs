using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_controller : MonoBehaviour
{
    private List<tiles> tile_list;
    private List<tiles> outer_tiles;
    private List<tiles> inner_tiles;
    private float cooldown_time= 240f;
    private float cooldown=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown+=Time.deltaTime;
        
    }
}

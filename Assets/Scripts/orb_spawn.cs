using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb_spawn : MonoBehaviour
{
    public tile_controller controller;
    public GameObject orb_prefab;
    public string[] orb_list;
    public int num_orb_type;
    public float cooldown_time = 1f;
    private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown+= Time.deltaTime;
        if(cooldown>=cooldown_time){
            this.spawn_orb();
            cooldown=0;
        }
    }

    void spawn_orb(){
        List<tiles> tile_list=controller.get_active_tiles();
        int tile_index=Random.Range(0, tile_list.Count);
        tiles tile=tile_list[tile_index];
        int orb_type_index=Random.Range(0, num_orb_type);
        string orb_type_string= orb_list[orb_type_index];
        GameObject new_orb=Instantiate(orb_prefab, tile.get_pos(), Quaternion.identity);
        new_orb.GetComponent<orb>().set_orb_type(orb_type_string);
        tile.set_orb(new_orb.GetComponent<orb>());
    }

    public void make_orb(string orb_type){
        List<tiles> tile_list=controller.get_active_tiles();
        int tile_index=Random.Range(0, tile_list.Count);
        tiles tile=tile_list[tile_index];
        GameObject new_orb=Instantiate(orb_prefab, tile.get_pos(), Quaternion.identity);
        new_orb.GetComponent<orb>().set_orb_type(orb_type);
        tile.set_orb(new_orb.GetComponent<orb>());
    }
}

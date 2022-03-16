using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_controller : MonoBehaviour
{
    public List<tiles> tile_list;
    //public List<tiles> outer_tiles;
    //public List<tiles> inner_tiles;
    public float cooldown_time= 5f;
    private float cooldown=0f;
    public List<tiles> inactive_tiles;
    public List<tiles> active_tiles;
    public int num_inac_tiles= 7;
    // Start is called before the first frame update
    public int num_tiles=25;
    void Start()
    {
        active_tiles = new List<tiles>(tile_list);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown+=Time.deltaTime;
        if(cooldown>=cooldown_time){
            cooldown=0;
            this.activate_tiles();
            this.inactive_tiles = new List<tiles>();
            this.active_tiles = new List<tiles>(this.tile_list);
            for(int i = 0; i< this.num_inac_tiles; i++){
                int index=Random.Range(0, num_tiles);
                this.inactive_tiles.Add(tile_list[index]);
                this.active_tiles.Remove(tile_list[index]);
            }
            this.deactivate_tiles();
        }
    }

    void activate_tiles(){
        for(int i=0; i< this.tile_list.Count; i++){
            this.tile_list[i].activate();
        }
    }

    void deactivate_tiles(){
        for(int i=0; i< this.inactive_tiles.Count; i++){
            this.inactive_tiles[i].deactivate();
        }
    }
    public bool valid_pos(Vector3 pos){
        bool valid=false;
        for(int i=0; i< this.active_tiles.Count; i++){
            if(Vector3.Distance(pos, this.active_tiles[i].gameObject.transform.position)<0.5){
                valid=true;
            }
        }
        return valid;
    }
    public List<tiles> get_active_tiles(){
        return this.active_tiles;
    }
}

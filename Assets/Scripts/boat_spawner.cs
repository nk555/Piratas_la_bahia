using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat_spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<boat_tiles> spawn_tiles;
    public List<string> boat_types;
    public List<boat_tiles> active_tiles = new List<boat_tiles>();
    public float deactivate_cooldown = 6f;
    private float spawn_timer = 0f;
    public float spawn_cooldown_down; 
    public float spawn_cooldown_up;
    private float next_spawn = 0.2f;
    private List<float> active_cooldowns = new List<float>();
    private List<int> deactivate_list = new List<int>();
    private bool inactive_boat = false;
    private int tile_index = 0;
    private string type;
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
        this.track_active_boats();
        this.spawn_new_boats();
    }

    void track_active_boats(){
        for(int i=0; i < this.active_cooldowns.Count; i++){
            this.active_cooldowns[i]+=Time.deltaTime;
            if(this.active_cooldowns[i]> this.deactivate_cooldown){
                this.active_tiles[i].destroy_boat();
                this.deactivate_list.Add(i);
            }
        }
        for(int i=0; i < this.deactivate_list.Count; i++){
            this.active_tiles.RemoveAt(i);
            this.active_cooldowns.RemoveAt(i);
        }
        this.deactivate_list.RemoveAll(always_true);
    }

    bool always_true(int i){
        return true;
    }

    void spawn_new_boats(){
        this.spawn_timer+= Time.deltaTime;
        if (this.spawn_timer>= this.next_spawn){
            this.spawn_timer = 0;
            this.next_spawn = Random.Range(this.spawn_cooldown_down, this.spawn_cooldown_up);
            while(this.inactive_boat == false){
                this.tile_index=Random.Range(0, this.spawn_tiles.Count);
                this.inactive_boat = !this.active_tiles.Contains(this.spawn_tiles[this.tile_index]);
                this.type = this.boat_types[Random.Range(0, this.boat_types.Count)];
            }
            this.spawn_tiles[this.tile_index].create_boat(this.type);
            this.active_tiles.Add(this.spawn_tiles[this.tile_index]);
            this.active_cooldowns.Add(0);
            this.inactive_boat=false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class shop : MonoBehaviour
{
    [SerializeField] private int money=0;
    private string money_file="money_file";
    
    public Text money_text;
    // Start is called before the first frame update
    void Start()
    {
        if(File.Exists(System.IO.Path.Combine(Application.persistentDataPath, money_file))){
            using FileStream fileStream = File.Open(System.IO.Path.Combine(Application.persistentDataPath, money_file), FileMode.Open); 
            using BinaryReader binaryReader = new BinaryReader(fileStream); 
            money = binaryReader.ReadInt32(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        money_text.text="Dinero: "+money;
    }

    public void buy_item(int i){
        if (money>= i){
            money-=i;
            using FileStream fileStream = File.Open(System.IO.Path.Combine(Application.persistentDataPath, money_file), FileMode.Create);
            using BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            binaryWriter.Write(money);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateGUI : MonoBehaviour
{
    public PlayerData Data;
    public InventoryController Inventory;
    public BaseItemData Key;
    public Text Score;
    public Text Life;
    public Text Jump;
    public Text KeyText;
    public string CheckKey;

    void Update()
    {
        if(Inventory.FindItem(Key)!=-1){
            CheckKey="есть";
        }else{
            CheckKey="нет";
        }

        Score.text = "Score: "+Data.Score;
        Life.text = "Жизней: "+Data.Life +"/" + Data.MaxLife;
        Jump.text = "Прыжков: "+Data.CountJump+"/"+Data.MaxJump;
        KeyText.text = "Ключ: "+CheckKey;
    }
}

using TMPro;
using UnityEngine;

public class EggShop : MonoBehaviour
{
    public TextMeshProUGUI all_Egg_Data;
    GameData g_Data;
    // Start is called before the first frame update
    void Start()
    {
        g_Data = FindObjectOfType<GameData>();
        g_Data.loadAllEgg(all_Egg_Data);
    }

    // Update is called once per frame

}

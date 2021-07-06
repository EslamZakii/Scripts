using UnityEngine;

public class MaterialData : MonoBehaviour
{    //gameData.henskin
    public Material[] henSkins;
    public Renderer hen_Rend;
    public GameData materialIndex;
    // Start is called before the first frame update
    void Start()
    {
        hen_Rend = GetComponent<Renderer>();
        materialIndex.material_Index = 0;
        hen_Rend.enabled = true;
        hen_Rend.sharedMaterial = henSkins[materialIndex.material_Index];
        materialIndex = FindObjectOfType<GameData>();
    }

    // Next Chicken 
    public void next_Hen()
    {
        materialIndex.material_Index = materialIndex.material_Index + 1;

        if (materialIndex.material_Index < henSkins.Length)
        {

            hen_Rend.sharedMaterial = henSkins[materialIndex.material_Index];


        }
        if (materialIndex.material_Index > henSkins.Length - 1)
        {
            materialIndex.material_Index = 0;
            hen_Rend.sharedMaterial = henSkins[materialIndex.material_Index];
        }
    }
    public void prev_Hen()
    {

        materialIndex.material_Index = materialIndex.material_Index - 1;
        if (materialIndex.material_Index < henSkins.Length && materialIndex.material_Index >= 0)
        {

            hen_Rend.sharedMaterial = henSkins[materialIndex.material_Index];

            print(henSkins.Length + "  VS   " + materialIndex.material_Index);
        }
        if (materialIndex.material_Index < 0)
        {
            materialIndex.material_Index = henSkins.Length - 1;
            hen_Rend.sharedMaterial = henSkins[materialIndex.material_Index];
        }
    }
}

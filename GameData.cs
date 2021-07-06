using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    [SerializeField] int[] pricess = { 0, 1000, 5000, 10000, 15000, 20000, 25000, 30000, 35000, 40000, 45000, 50000, 55000, 60000, 65000, 70000, 75000, 80000, 85000, 100000 };
    public bool[] isBought = new bool[20];
    public Material current_Material;
    public Material[] henSkins;
    string[] btns = { "buyChicken", "leftArrow","rightArrow","selectChicken" };
    public  Renderer hen_Rendder;
    public  GameObject  chickenModel1;
    public TextMeshProUGUI eggPrice_Text;
    public TextMeshProUGUI allegg_Text;
    public TextMeshProUGUI notEnoughEggTxt;
    public GameObject notEnoughEggss;
    public GameObject priceHeader;
    public GameObject eggCurrencyAll;
    delegate void delegateReferenceRendererRD();
    delegateReferenceRendererRD ChickenDelegate;

    public int material_Index { set; get; }
    public int highScore { set; get; }
    public int AllEggs { set; get; }
    public int collectedEggs { set; get; }
    public int ChickenPrice { set; get; }
    public int[] ChickenMaterial { set; get; }
  
     void Start()
    {
        current_Material = henSkins[PlayerPrefs.GetInt("SelectedMaterial")];

        //setup materials for checking
        getSelectedChicken();

    }

    public void getSelectedChicken()
    {
        for (int i = 0; i < isBought.Length; i++)
        {


            if (PlayerPrefs.GetInt(i.ToString()) == 1)
            {
                isBought[i] = true;
                hen_Rendder.sharedMaterial = henSkins[PlayerPrefs.GetInt("SelectedMaterial")];
            }
            else
            {
                isBought[i] = false;
            }
        }
    }

    void Update()
    {
    

        if (priceHeader==null)
        {

            priceHeader = GameObject.FindGameObjectWithTag("PriceHeader");
            if (eggPrice_Text==null)
            {
                eggPrice_Text = priceHeader.GetComponentInChildren<TextMeshProUGUI>();

            }


        }
        //check if text ref in null
        if (eggCurrencyAll == null )
        {
            eggCurrencyAll = GameObject.FindGameObjectWithTag("eggCurrencyAll");
            if (allegg_Text == null )
            {
                print("you are here");
                allegg_Text = eggCurrencyAll.GetComponentInChildren<TextMeshProUGUI>();
            }
        }
        allegg_Text.text = PlayerPrefs.GetInt("All_Eggs").ToString();
      
        //to chek if it bought the skin
        if (PlayerPrefs.GetInt(material_Index.ToString()) == 1)
        {
            isBought[material_Index] = true;
        }
        if (notEnoughEggss == null)
        {
            notEnoughEggss = GameObject.FindGameObjectWithTag("notEnoughEggs");
            notEnoughEggTxt = notEnoughEggss.GetComponentInChildren<TextMeshProUGUI>();
        }
    }
    //TO GET REFERENCE FOR CHICKEN
    void OnSceneLoaded(Scene scene ,LoadSceneMode mol)
    {
        if (chickenModel1 == null)
        {

            chickenModel1 = GameObject.FindGameObjectWithTag("Chicken");
            if (hen_Rendder == null)
            {
                hen_Rendder = GameObject.FindGameObjectWithTag("Chicken").GetComponentInChildren<Renderer>();
                getSelectedChicken();

            }
        }
    }



    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        int numOfGameData = FindObjectsOfType<GameData>().Length;
        if (numOfGameData > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

   

    //get int ,score , highscore
    public void saveHighScore(int hScore_s, TextMeshProUGUI Current_Text, TextMeshProUGUI hScoreText)
    {
        Debug.Log("saveing" + hScore_s);
        if (hScore_s > int.Parse(Current_Text.text))
        {
            hScoreText.text = hScoreText.ToString();
        }
        else if (hScore_s < int.Parse(Current_Text.text))
        {

            PlayerPrefs.SetInt("High_Score", int.Parse(Current_Text.text));
        }
    }

    public void loadHighScore(TextMeshProUGUI text)
    {
        try
        {
            text.text = PlayerPrefs.GetInt("High_Score").ToString();
        }
        catch (System.Exception)
        {

            Debug.Log("Main Menue");

        }



    }
    public void saveAllEgg(int ScoredEggs)
    {
        int debug1;
        PlayerPrefs.SetInt("All_Eggs", PlayerPrefs.GetInt("All_Eggs") + ScoredEggs);
        debug1 = PlayerPrefs.GetInt("All_Eggs");
        Debug.Log("the score is :     " + debug1);


    }
    public int loadAllEgg(TextMeshProUGUI AllEggs_Text)
    {
        AllEggs_Text.text = PlayerPrefs.GetInt("All_Eggs").ToString();
        return PlayerPrefs.GetInt("All_Eggs");
    }
    // change Charcter next
    public void next_Hen()
    {
       // print(material_Index + "test"); test

        material_Index = material_Index + 1;

        if (material_Index < henSkins.Length)
        {

            hen_Rendder.sharedMaterial = henSkins[material_Index];
            eggPrice_Text.text = pricess[material_Index].ToString();
            pirceHeaderChecker();
            disableNotEnoughEggs();
        }
        if (material_Index > henSkins.Length - 1)
        {
            material_Index = 0;
            hen_Rendder.sharedMaterial = henSkins[material_Index];
            eggPrice_Text.text = pricess[material_Index].ToString();
            pirceHeaderChecker();
            disableNotEnoughEggs();
        }
    }
    //check if skin bought or not
    private void pirceHeaderChecker()
    {
        if (isBought[material_Index] == true)
        {
            priceHeader.SetActive(false);
        }
        else if (isBought[material_Index] == false)
        {
            priceHeader.SetActive(true);

        }
    }

    public void prev_Hen()
    {

        material_Index = material_Index - 1;
        if (material_Index < henSkins.Length && material_Index >= 0)
        {

            hen_Rendder.sharedMaterial = henSkins[material_Index];
            eggPrice_Text.text = pricess[material_Index].ToString();
            pirceHeaderChecker();
            disableNotEnoughEggs();

            print(henSkins.Length + "  VS   " + material_Index);
        }
        if (material_Index < 0)
        {
            material_Index = henSkins.Length - 1;
            hen_Rendder.sharedMaterial = henSkins[material_Index];
            pirceHeaderChecker();
            disableNotEnoughEggs();


            eggPrice_Text.text = pricess[material_Index].ToString();
        }
    }


    public void buychicken()
    {
        if (isBought[material_Index] == false)
        {
            if (PlayerPrefs.GetInt("All_Eggs") >= pricess[material_Index])

            {
                isBought[material_Index] = true;
                PlayerPrefs.SetInt("All_Eggs", PlayerPrefs.GetInt("All_Eggs") - pricess[material_Index]);
                PlayerPrefs.SetInt(material_Index.ToString(), 1);
                if (PlayerPrefs.GetInt(material_Index.ToString()) == 1)
                {
                    isBought[material_Index] = true;
                }
                print("Bought");
            }
            else
            {
                notEnoughEggs();
                Invoke("disableNotEnoughEggs", 2);

            }
        }



    }
    public void selectChicken()
    {
        if (isBought[material_Index]==true)
        {
            PlayerPrefs.SetInt("SelectedMaterial", material_Index);
            current_Material = henSkins[PlayerPrefs.GetInt("SelectedMaterial")];
            hen_Rendder.sharedMaterial = current_Material;
            print("Selected");

        }
        else
        {
            print("Selected Denied");
        }
    }
    public void loadChicken()
    {
        if (isBought[material_Index] == true)
        {
           
          //  current_Material = henSkins[PlayerPrefs.GetInt("SelectedMaterial")];
            hen_Rendder.sharedMaterial = henSkins[PlayerPrefs.GetInt("SelectedMaterial")];
            print("Selected");

        }
        else
        {
            print("Selected Denied");
        }
    }
    void notEnoughEggs()
    {
        notEnoughEggss.SetActive(true);

    }
    void disableNotEnoughEggs()
    {
        notEnoughEggss.SetActive(false);

    }
}

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class GameManger : MonoBehaviour
{
    CameraFollow CamLerp;
    public GameObject shopPanel;
    public GameObject mainMenuePanel;
    bool mainMenuePanelt, shopPanelt;
    public GameObject gamePlayCanvas;
    public Canvas canvaseGameplay;
   public TouchChiken to;
   public CameraFollow cameraflow;
  public  GameData chickenSelection;
    public GameObject cameraFollow;

     void Awake()
    {
        CamLerp = GameObject.FindGameObjectWithTag("MainCamera1").GetComponent<CameraFollow>();
    }
    void Start()
    {
        gamePlayCanvas = GameObject.FindGameObjectWithTag("GamePlayCanvas");
        canvaseGameplay = gamePlayCanvas.GetComponentInChildren<Canvas>();
        shopPanel.SetActive(false);
        mainMenuePanel.SetActive(true);
        shopPanelt = false;
        mainMenuePanelt = true;
        gamePlayCanvas.SetActive(false);

        if (cameraFollow == null)
        {
            cameraFollow = GameObject.FindGameObjectWithTag("MainCamera1");
            cameraflow = cameraFollow.GetComponent<CameraFollow>();
        }
        if (to==null)
        {
            to = GameObject.FindGameObjectWithTag("Chicken").GetComponentInChildren<TouchChiken>();
        }
        if (chickenSelection == null)
        {
            chickenSelection = GameObject.FindGameObjectWithTag("GameDataProfile").GetComponent<GameData>();

        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        //SceneManager.LoadScene(1);
        gamePlayCanvas.SetActive(true);
        gameObject.SetActive(false);
        to.touchCheker();
        cameraflow.touchCheker();
        CamLerp.shopLerp = false;
        CamLerp.mainmenuelerp = false;




    }
    public void mainMenue()
    {
        if (shopPanelt == true && mainMenuePanelt == false)
        {
            shopPanel.SetActive(false);
            mainMenuePanel.SetActive(true);
            shopPanelt = false;
            mainMenuePanelt = true;
            CamLerp.mainmenuelerp = true;
            CamLerp.shopLerp = false;


        }
        chickenSelection.hen_Rendder.sharedMaterial = chickenSelection.current_Material;
    }
    public void shopPanelf()
    {
        if (shopPanelt == false && mainMenuePanelt == true)
        {
            shopPanel.SetActive(true);
            mainMenuePanel.SetActive(false);
            shopPanelt = true;
            mainMenuePanelt = false;
            CamLerp.shopLerp = true;
            CamLerp.mainmenuelerp = false;

        }


    }

}

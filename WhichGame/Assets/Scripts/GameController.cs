using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [Header("About Objects")]
    public GameObject[] prefabs;
    int randomObj = 0;
    bool createObje = true;
    bool objeSec = true;
    Vector2 randomPos;
    float time = 0;
    string[] objeName = new string[5];
    int randomName = 0;
    [Header("UI")]
    public Text RandomObjeName;
    public Text ScoreText;
    public Text NewScore;
    [Header("Raycast2D")]
    RaycastHit2D hit;
    [Header("RGB Color For Sprite")]
    int []RGB=new int[3];
    [Header("Scripts")]
    GameController gameScript;
    GameObject gameController;
    GameObject Canvas;
    [Header("Score")]
    int highScore=0;
    //-8 ve 8 arası X ekseni
    // -4 ve 3 arası Y ekseni 
     void Start()
    {
        objeName[0] = "Kare";
        objeName[1] = "Daire";
        objeName[2] = "Dikdörtgen";
        objeName[3] = "Altıgen";
        objeName[4] = "Beşgen";
        gameScript = GetComponent<GameController>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
    void Update()
    {
        StartCoroutine(olustur());
        if(objeSec)
        {
            RandomObjName();
            objeSec = false;
        }
        time += Time.deltaTime;
        if(time>5f)
        {
            objeSec = true;
            time = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Raycast();
        }
    }
    private IEnumerator olustur()
    {
        while(createObje)
        {
            createObje = false;
            randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-4, 3));
            randomObj = Random.Range(0, 5);
            for (int i = 0; i < 3; i++)
            {
                RGB[i] = Random.Range(50, 255);
            }
            GameObject obje = Instantiate(prefabs[randomObj], randomPos, Quaternion.identity);
            obje.GetComponent<SpriteRenderer>().color = new Color32((byte)RGB[0], (byte)RGB[1], (byte)RGB[2],255);
            yield return new WaitForSeconds(.5f);
            createObje = true;

        } 
    }
    void RandomObjName()
    {
        randomName = Random.Range(0, 5);
        RandomObjeName.text = objeName[randomName];
    }
    void Raycast()
    {
     hit = Physics2D.Raycast(new Vector2(0.5f, 0.5f), Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if(hit.collider!=null)
        {
            if (hit.collider.tag != RandomObjeName.text)
            {
                GameOVER();
            }
            else
            {
                Destroy(hit.collider.gameObject);
                highScore = highScore + 10;
                ScoreText.text = "Score :" + highScore;
            }
        }
    }
    void GameOVER()
    {
        gameController.SetActive(false);
        RandomObjeName.text = null;
        ScoreText.text = null;
        Canvas.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void AnaMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

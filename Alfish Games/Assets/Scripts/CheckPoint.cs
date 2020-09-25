using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public int NumberOfBallForCP;
    public GameObject Clamp,pb,RoadCube;
    public TextMesh text;
    public bool WaitBool,CreateRoadBool;
    public Collider collider;
    public ProgressBar progressBar;
    public Canvas RestartGameCanvas;

    void Start()
    {
      SetObjects();
        
      gameObject.AddComponent<CheckPointClass>();
      gameObject.GetComponent<CheckPointClass>().SetNumberOfRequiredBall(NumberOfBallForCP);
      
    }

    
    void Update()
    {
        text.text = gameObject.GetComponent<CheckPointClass>().NumberOfBall.ToString() + " / " +
                    gameObject.GetComponent<CheckPointClass>().RequiredBall.ToString();

      CreateRoad();
       
        
        
    }

    public void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "Ball":
                gameObject.GetComponent<CheckPointClass>().AddBallToCheckPoint();
                break;
            case "Clamp":
                Clamp.GetComponent<MoveClamp>().MoveBool = false;
                StartCoroutine(CompareNumberOfBalls());
                break;
            
            default:
                break;
        }    
    }
    
    private IEnumerator CompareNumberOfBalls()
    {
        yield return new WaitForSeconds(3f);
        
        if (gameObject.GetComponent<CheckPointClass>().CompareNumberOfBalls())
        {
            progressBar.CheckPointPass();
            collider.enabled = false;
            StartCoroutine(ClampMoveActive());
            text.gameObject.SetActive(false);
            CreateRoadBool = true;
            AddCoin();
        }
        else
        {
            RestartGameCanvas.enabled = true;
        }
    }

    private IEnumerator ClampMoveActive()
    {
        yield return new WaitForSeconds(3f);
        Clamp.GetComponent<MoveClamp>().MoveBool = true;
    }

    public void CreateRoad()
    {
        if (CreateRoadBool)
        {
            if (RoadCube.transform.position.y < -.525f)
            {
                RoadCube.SetActive(true);
                RoadCube.transform.position+=new Vector3(0,0.05f,0);
            }
        }
    }

    public void SetObjects()
    {
        Clamp=GameObject.Find("Clamp");
        pb=GameObject.Find("ProgressBar");
        progressBar = pb.GetComponent<ProgressBar>();
        text = GetComponentInChildren<TextMesh>();
        RoadCube = this.transform.Find("RoadCube").gameObject;
        collider = GetComponent<Collider>();

        RestartGameCanvas = GameObject.Find("RestartGameCanvas").GetComponent<Canvas>();
        RestartGameCanvas.enabled = false;
    }

    public void AddCoin()
    {
        var coin=PlayerPrefs.GetInt("Coin");
        coin += 150;
        PlayerPrefs.SetInt("Coin",coin);
    }

}

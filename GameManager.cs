using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int health;
    public PlayerMove player;
    public Image[] UIhealth;
    public Text UIpoint;
    public Text UIstage;
    public GameObject UIRestartBtn;
    public GameObject UIClearBtn;


    void Update()
    {
        UIpoint.text = (totalPoint + stagePoint).ToString();
    }
    public void NextStage()
    {

       
        totalPoint += stagePoint;
        stagePoint = 0;
    }

    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);
        }
        else
        {
            UIhealth[0].color = new Color(1, 0, 0, 0.4f);
            player.OnDie();

            Time.timeScale = 0;
            Debug.Log("Á×À½");
            UIRestartBtn.SetActive(true);
            Text btnText = UIRestartBtn.GetComponentInChildren<Text>();
            btnText.text = "Game Over!";
            UIRestartBtn.SetActive(true);
        }
    }
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            HealthDown();

            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.transform.position = new Vector3(0, 0, -1);
        }


    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameCam;
    public GameObject player;
    public Rigidbody2D rb;
    private int currentLevel;
    private float y;
    public bool endGame;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!endGame){
            y = player.transform.position.y;
            currentLevel = (int)(y-4.43f)/10;
            if(player.transform.position.y > 4.43f*(currentLevel+1)){
                gameCam.transform.position = new Vector3(0, 10*(currentLevel+1), -10);
            }else{
                gameCam.transform.position = new Vector3(0, 10*currentLevel, -10);
            }
        }
    }
}

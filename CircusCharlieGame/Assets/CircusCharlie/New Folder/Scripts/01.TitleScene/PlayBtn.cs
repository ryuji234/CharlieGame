using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayBtn : MonoBehaviour
{
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //! 플레이 버튼을 눌렀을 때 플레이 씬으로 넘어간다.

    public void OnplayButton()
    {
        GFunc.LoadScene(GData.SCENE_NAME_STAGE_1);
    }       // OnPlayButton()
}

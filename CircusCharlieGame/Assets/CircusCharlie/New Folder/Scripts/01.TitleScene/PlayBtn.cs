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

    //! �÷��� ��ư�� ������ �� �÷��� ������ �Ѿ��.

    public void OnplayButton()
    {
        GFunc.LoadScene(GData.SCENE_NAME_STAGE_1);
    }       // OnPlayButton()
}

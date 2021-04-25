using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentController : MonoBehaviour
{

    private bool commentsEnabled = false;

    private float tickShowtime = 0f;
    private float timeBetweenRemarks = 10f;
    private float timeShow = 5f;
    private float tickComment = 0f;
    private bool showing = false;
    // Start is called before the first frame update
    void Start()
    {
        if(GameController.instance.tutorialOn == false)
        {
            commentsEnabled = true;
            timeBetweenRemarks = 1f;
        }
    }

    private void Update()
    {
        if(commentsEnabled)
        {
            if(!showing)
            {
                tickComment += Time.deltaTime;

                if (tickComment >= timeBetweenRemarks)
                {
                    GameController.instance.ActivateScreen(TextHolder.instance.GetRandomWittynessString());
                    tickComment = 0f;
                    timeBetweenRemarks = Random.Range(12f, 20f);
                    showing = true;

                }
            }
            
            if(showing)
            {
                tickShowtime += Time.deltaTime;

                if(tickShowtime >= timeShow)
                {
                    GameController.instance.DeactivateScreen();
                    tickShowtime = 0f;
                    showing = false;
                }
            }


        }
    }

    public void EnableComments()
    {
        commentsEnabled = true;
    }



    


}

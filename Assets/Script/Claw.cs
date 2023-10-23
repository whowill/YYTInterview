using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public enum clawState
    {
        move,
        down,
        claim,
        moveTowardGoal,
        remove,
        restart
    }
    [SerializeField] clawState currentState;

    [SerializeField] GameObject rClaw, lClaw;
    [SerializeField] BoxCollider2D prizeDetection;

    [SerializeField] bool isMovingDown = false;
    [SerializeField] bool clawOpen = true;
    [SerializeField] float clawSpeed;

    [SerializeField] Vector2 windowsSize;
    [SerializeField] Vector3 startPosition;

    [Header("PathFinding")]
    [SerializeField] List<Transform> wayPoint;
    [SerializeField] int wayPointIndex;

    [SerializeField] GameObject panelUI;
    float timeToShowPrize = 3f;

    private void Start()
    {
        windowsSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        currentState = clawState.move;
        startPosition = transform.position;
    }


    private void Update()
    {
        switch (currentState)
        {
            case clawState.move:
                timeToShowPrize = 3f;
                moveClaw();
                break;
            case clawState.down:
                movingDown();
                break;
            case clawState.claim:
                claimPrize();
                break;
            case clawState.moveTowardGoal:
                followPath();
                break;
            case clawState.remove:
                removePrize();
                break;
            case clawState.restart:
                restart();
                timeToShowPrize -= Time.deltaTime;
                if(panelUI.activeInHierarchy == false && timeToShowPrize <= 0)
                {
                    FindObjectOfType<ClaimPrize>().showPanelPrize();
                }
                break;
        }
    }

    #region movement Function
    private void moveClaw()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x >= windowsSize.x - 2)
            {
                return;
            }
            transform.Translate(Vector2.right * clawSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x <= -windowsSize.x + 6.5)
            {
                return;
            }
            transform.Translate(Vector2.left * clawSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y >= windowsSize.y + 2)
            {
                return;
            }
            transform.Translate(Vector2.up * clawSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y <= -windowsSize.y /2 + 6)
            {
                return;
            }
            transform.Translate(Vector2.down * clawSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            currentState = clawState.down;
            isMovingDown = true;
        }
    }

    private void movingDown()
    {
        if (isMovingDown)
        {
            transform.Translate(Vector2.down * clawSpeed * Time.deltaTime);
        }
    }

    #endregion

    #region Claw Function
    private void claimPrize()
    {
        if (clawOpen)
        {
            if (lClaw.transform.eulerAngles.z < 358)
            {
                lClaw.transform.Rotate(0, 0, 30f * Time.deltaTime);
            }
            if (rClaw.transform.eulerAngles.z > 2)
            {
                rClaw.transform.Rotate(0, 0, -30f * Time.deltaTime);
            }
        }
        if (lClaw.transform.eulerAngles.z >= 358 && rClaw.transform.eulerAngles.z <= 2)
        {
            clawOpen = false;
            currentState = clawState.moveTowardGoal;
            return;
        }
    }

    private void removePrize()
    {
        if (!clawOpen)
        {
            if (lClaw.transform.eulerAngles.z > 310)
            {
                lClaw.transform.Rotate(0, 0, -30f * Time.deltaTime);
            }
            if (rClaw.transform.eulerAngles.z < 50)
            {
                rClaw.transform.Rotate(0, 0, 30f * Time.deltaTime);
            }
        }
        if (lClaw.transform.eulerAngles.z >= 309 && rClaw.transform.eulerAngles.z >= 49)
        {
            clawOpen = true;
            currentState = clawState.restart;
            return;
        }
    }

    #endregion

    #region automatic Movement
    public void followPath()
    {
        if(wayPointIndex < wayPoint.Count)
        {
            Vector3 targetPosition = wayPoint[wayPointIndex].position;
            var delta = clawSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
            if (transform.position == wayPoint[wayPoint.Count -1].transform.position)
            {
                wayPointIndex = 0;
                currentState = clawState.remove;
                
            }
        }
    }

    public void restart()
    {
        if (transform.position == startPosition)
        {
            currentState = clawState.move;
            return;
        }
        Vector3 targetPosition = startPosition;
        var delta = 2 * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
    }
    #endregion


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currentState == clawState.down)
        {
            currentState = clawState.claim;
            isMovingDown = false;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIplayer : MonoBehaviour
{
    Player playerTarget;
    Transform playerTrans;
    Vector3 targetPos;
    Renderer targetRenderer;
    public float offSet = 2;
    CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();
    }
    public void SetUI(Player _player)
    {
        this.playerTarget = _player;
        playerTrans = playerTarget.GetComponent<Transform>();
        targetRenderer = playerTarget.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        if (targetRenderer != null)
        {
            if (playerTrans != null)
            {
                targetPos = playerTrans.position;
                this.transform.position = Camera.main.WorldToScreenPoint(targetPos + (Vector3.up * offSet));
            }
        }
    }

}

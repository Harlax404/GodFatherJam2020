using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    #region Variables
    // public PlayerEntity entity;
    public PlayerRigidBodyEntity entity;
    //public GameManager gameManager;
    private GameManager gameManager;

    private Player _mainPlayer;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _mainPlayer = ReInput.players.GetPlayer("Player0");
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //Pause
        if (_mainPlayer.GetButtonDown("Pause"))
        {
            gameManager.PlayPause();
        }

        float dirX = _mainPlayer.GetAxis("MoveHorizontal");
        float dirY = _mainPlayer.GetAxis("MoveVertical");

        entity.Move(dirX, dirY);
    }
}

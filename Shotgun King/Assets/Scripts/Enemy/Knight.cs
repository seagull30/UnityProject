using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    private void OnEnable()
    {
        InitCooltime = 2;
        RemainingCooltime = Random.Range(1, InitCooltime);
        Helth = 3;
        pos = new GridIndex(7, 1);
        MoveDir = new GridIndex[8] { new GridIndex(2, -1), new GridIndex(2, 1), new GridIndex(1, 2), new GridIndex(-1, 2), new GridIndex(-2, 1), new GridIndex(-2, -1), new GridIndex(-1, -2), new GridIndex(1, -2) };
        _moveType = EMovementType.Jump;
        MoveCount = 1;
        Board.state[pos.X, pos.Y] = Board.State.full;
        GameManager.instance.OnTurnEnd += TurnCount;
        //transform.position = Gamemanager.instance.Board.BoardPan[pos.X, pos.Y];
    }


    protected override void CheckAttak(GridIndex playerPos)
    {
        base.CheckAttak(playerPos);
    }

    protected override void arrivalPosition(GridIndex targetGrid, out Vector3 target)
    {
        base.arrivalPosition(targetGrid, out target);
    }
    private void OnDisable()
    {
        GameManager.instance.OnTurnEnd -= TurnCount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Enemy
{
    private void OnEnable()
    {
        InitCooltime = 4;
        RemainingCooltime = Random.Range(1, InitCooltime);
        Helth = 5;
        pos = new GridIndex(7, 3);
        _moveType = EMovementType.Slide;
        MoveDir = new GridIndex[8] { new GridIndex(1, 0), new GridIndex(1, 1), new GridIndex(0, 1), new GridIndex(-1, 1), new GridIndex(-1, 0), new GridIndex(-1, -1), new GridIndex(0, -1), new GridIndex(1, -1) };
        MoveCount = 7;
        Board.state[pos.X, pos.Y] = Board.State.full;
        GameManager.instance.OnTurnEnd += TurnCount;

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

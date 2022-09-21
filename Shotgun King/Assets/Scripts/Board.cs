using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public enum State
    {
        empty,
        full,
        preemption
    }


    public Vector3[,] BoardPan = new Vector3[8, 8];
    public State[,] state = new State[8, 8];


    public GridIndex PlayerPos;
    private void Awake()
    {
        for (int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                float boardPosX = (-21 + 6 * j) / 100f;
                float boardPosZ = (-21 + 6 * i) / 100f;
                BoardPan[i, j] = new Vector3(boardPosX, 0f, boardPosZ);
            }
        }
    }
    void Start()
    {
        //state[0, 4] = State.full;
        //state[7, 1] = State.full;
        //state[7, 2] = State.full;
        //state[7, 3] = State.full;
        //state[7, 4] = State.full;
        //state[7, 5] = State.full;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

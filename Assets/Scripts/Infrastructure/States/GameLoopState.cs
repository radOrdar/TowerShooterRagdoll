using System;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        public GameLoopState(GameStateMachine gameStateMachine)
        {
         
        }

        public void Exit()
        {
           
        }

        public void Enter()
        {
            Debug.Log("privet");
        }
    }
}
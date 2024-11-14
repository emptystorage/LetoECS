using UnityEngine;
using System;

namespace LETO.ECS
{
    public class ECSUpdater : MonoBehaviour, IWorldTick
    {
        public event Action UpdateTick;
        public event Action FixedUpdateTick;
        public event Action LateUpdateTick;

        void Update()
        {
            UpdateTick?.Invoke();
        }

        void FixedUpdate()
        {
            FixedUpdateTick?.Invoke();
        }

        void LaterUpdate()
        {
            LateUpdateTick?.Invoke();
        }
    }
}


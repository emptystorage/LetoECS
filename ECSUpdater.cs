using UnityEngine;
using System;

namespace LETO.ECS
{
    public class ECSUpdater : MonoBehaviour, IWorldTick
    {
        public event Action UpdateTick;
        public event Action FixedUpdateTick;
        public event Action LateUpdateTick;

        public static ECSUpdater Initialize()
        {
            return new GameObject(nameof(ECSUpdater)).AddComponent<ECSUpdater>();
        }

        void Update()
        {
            UpdateTick?.Invoke();
        }

        void FixedUpdate()
        {
            FixedUpdateTick?.Invoke();
        }

        void LateUpdate()
        {
            LateUpdateTick?.Invoke();
        }
    }
}


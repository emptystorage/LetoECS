using System;
using System.Collections.Generic;
using EmptyDI;

namespace LETO.ECS
{
    public sealed class ECSSystemFactoryWithDI : ISystemFactory
    {
        private HashSet<Type> _bindedSystems = new HashSet<Type>();

        public ECSSystemFactoryWithDI Bind<T>(in IInstaller installer)
            where T : ECSSystem
        {
            if(!_bindedSystems.Contains(typeof(T)))
            {
                _bindedSystems.Add(typeof(T));
                var context = new BindSystemContext<T>();
                context.Bind(installer);
            }

            return this;
        }

        public T Create<T>() where T : ECSSystem
        {
            if (_bindedSystems.Contains(typeof(T)))
            {
                var context = new BindSystemContext<T>();
                return context.Get();
            }
            else
            {
                return Activator.CreateInstance<T>();
            }
        }

        private ref struct BindSystemContext<T>
            where T : class
        {
            public void Bind(in IInstaller installer)
            {
                installer.Bind<T>().AsSingle();
            }

            public T Get()
            {
                return EmptyDIConnector.Get<T>();
            }
        }
    }
}
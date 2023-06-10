using LevelSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private Transform spawnPoint;
        
        public override void InstallBindings()
        {
            Container.Bind<ObjectPool>()
                .AsSingle()
                .WithArguments(spawnPoint)
                .NonLazy();
            
            Container.Bind<Generation>()
                .AsSingle()
                .NonLazy();
        }
    }
}

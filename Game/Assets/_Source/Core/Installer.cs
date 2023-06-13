using BulletSystem;
using LevelSystem;
using UISystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private GameUIView gameUIView;
        [SerializeField] private Distance distance;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform playerPoint;
        [SerializeField] private GameObject bulletPrefab;

        public override void InstallBindings()
        {
            Container.Bind<GameUIView>()
                .FromInstance(gameUIView)
                .AsSingle()
                .NonLazy();

            Container.Bind<GameUIController>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<TilePool>()
                .AsCached()
                .WithArguments(spawnPoint)
                .NonLazy(); 

            Container.Bind<BulletPool>()
                .AsCached()
                .WithArguments(bulletPrefab, playerPoint)
                .NonLazy();

            Container.Bind<Distance>()
                .FromInstance(distance)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<Generation>()
                .AsSingle()
                .NonLazy();

            Container.Bind<BulletSpawner>()
                .AsSingle()
                .NonLazy();
            Container.Bind<GameObject>()
                .FromInstance(bulletPrefab)
                .AsCached()
                .NonLazy();
            Container.BindFactory<Bullet, Bullet.BulletFactory>()
                .FromComponentInNewPrefab(bulletPrefab);
        }
    }
}

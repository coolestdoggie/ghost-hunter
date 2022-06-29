using GhostHunter;
using GhostHunter.Scenes.Game;
using UnityEngine;
using Zenject;

public class CharactersInstaller : MonoInstaller
{
    [SerializeField] private GameObject ghostPrefab;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GhostsSpawner>().AsSingle();
        Container
            .BindFactory<Ghost, Ghost.Factory>()
            .FromMonoPoolableMemoryPool(x => x.FromComponentInNewPrefab(ghostPrefab).
            UnderTransformGroup("Ghosts"));
    }
}
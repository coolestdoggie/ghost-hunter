using GhostHunter.Scenes.Game;
using UnityEngine;
using Zenject;

public class ScoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ScoreCounter>().AsSingle();
    }
}
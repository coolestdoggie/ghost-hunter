using GhostHunter.Scenes.Game;
using Zenject;

public class ScoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ScoreCounter>().AsSingle();
    }
}
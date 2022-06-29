using GhostHunter.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GhostHunter.Scenes.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        private ISceneLoader _sceneLoader;
        
        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;    
        }
        
        private void OnEnable()
        {
            playButton.onClick.AddListener(PlayButtonPressed);
        }

        private void OnDisable()
        {
            playButton.onClick.RemoveListener(PlayButtonPressed);
        }

        private void PlayButtonPressed()
        {
            _sceneLoader.LoadScene(1); //TODO: Remove literals
        }
    }
}

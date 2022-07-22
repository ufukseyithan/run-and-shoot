using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Core {
    public static class LevelManager {
        public static void LoadNextLevel() {
            var currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            var nextLevelIndex = currentLevelIndex + 1;
            var isNextLevelAvailable = nextLevelIndex <= SceneManager.sceneCount;
            
            SceneManager.LoadScene(isNextLevelAvailable ? nextLevelIndex : 0);
        } 
        
        public static void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
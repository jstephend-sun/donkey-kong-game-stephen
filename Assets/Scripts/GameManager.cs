using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private int lives;
    private int score;

    private int levelIdx;

    private void Start() {
        DontDestroyOnLoad(gameObject);

        levelIdx = 1;

        NewGame();
    }

    private void NewGame() {
        lives = 3;
        score = 0;

        LoadLevel();
    }

    private void LoadLevel() {
        Camera camera = Camera.main;

        if (camera != null) {
            camera.cullingMask = 0;
        }
        
        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene() {
        SceneManager.LoadScene(levelIdx);
    }

    public void LevelComplete() {
        score += 1000;

        levelIdx++;
        if (levelIdx < SceneManager.sceneCountInBuildSettings) LoadLevel();
        else {
            levelIdx = 1;
            LoadLevel();
        }
    }
    public void LevelFail() {
        lives --;

        if (lives <= 0) NewGame();
        else LoadLevel();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;

    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)
            {
                return;
            }

            Debug.Log("All enemies killed");

            _nextLevelIndex++;
            string nextLevel = "Level" + _nextLevelIndex;
            SceneManager.LoadScene(nextLevel);

        }
    }
}

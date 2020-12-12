using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    List<Diamond> uncollectedDiamonds = new List<Diamond>();

    [SerializeField] AudioClip collectSFX;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        uncollectedDiamonds = new List<Diamond>(FindObjectsOfType<Diamond>());
    }

    public static void Collect(Diamond diamond)
    {
        AudioSource.PlayClipAtPoint(instance.collectSFX, diamond.transform.position);

        instance.uncollectedDiamonds.Remove(diamond);
        Destroy(diamond.gameObject);

        if (instance.uncollectedDiamonds.Count <= 0)
        {
            instance.GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver");

        instance.StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }


}

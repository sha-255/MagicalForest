using UnityEngine;
using UnityEngine.UI;

public class Prefs : MonoBehaviour
{
    [SerializeField] private Button discardChanges;
    [SerializeField] private Button exit;

    private void Awake()
    {
        discardChanges.onClick.AddListener(discardAllChanges);
        exit.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void discardAllChanges()
    {
        PlayerPrefs.DeleteAll();
    }
}

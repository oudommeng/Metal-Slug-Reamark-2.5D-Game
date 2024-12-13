using UnityEngine;

public class PlayButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject difficultyPanel;

    // Method to show the difficulty panel
    public void ShowDifficultyPanel()
    {
        difficultyPanel.SetActive(true);
    }

    public void HideDiffcultyPanel()
    {
        difficultyPanel.SetActive(false);
    }
}

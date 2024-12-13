using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScenes : MonoBehaviour
{
    public float toggleInterval; // Interval to toggle rendering on/off
    private float originalToggleInterval; // To store the original interval

    public Text textComponent; // Reference to the Text component
    // public RectTransform textImage; // Reference to the RectTransform of TextImage
    private bool isRendering = true; // Track the rendering state
    public float normalSpeed = 0.8f; // Normal rendering speed
    public float fastSpeed = 0.6f; // Fast rendering speed
    private float currentSpeed; // Current rendering speed
    public string newSceneName; // Name of the new scene to load
    public float TextImageMovePosY; // Y position to move the TextImage
    public float textComponentMovePosY = -700f; // Y position to move the textComponent
    public float moveSpeed; // Speed at which TextImage moves to the target position

    // public AudioClip introSound; // Reference to the intro sound clip
    // public AudioClip clickSound; // Reference to the click sound clip
    // private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource component
        // audioSource.clip = introSound; // Assign the intro sound clip to the AudioSource
        // audioSource.loop = true; // Loop the intro sound
        // audioSource.volume = 0.5f; // Set the initial volume to 0.5
        // audioSource.Play(); // Play the intro sound

        currentSpeed = normalSpeed;
        originalToggleInterval = toggleInterval; // Save the original interval
        StartCoroutine(AutoToggleRendering());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for mouse click
        {
            StartCoroutine(FastRenderAndChangeScene());
        }

        if (isRendering)
        {
            // Add rendering logic here if needed
        }
    }

    IEnumerator FastRenderAndChangeScene()
    {
        // // Lower the background volume
        // StartCoroutine(FadeOutBackgroundVolume());

        // // Play the click sound
        // audioSource.PlayOneShot(clickSound);

        currentSpeed = fastSpeed;
        toggleInterval = fastSpeed; // Set the interval to fast speed
        yield return new WaitForSeconds(2f);

        currentSpeed = normalSpeed;
        toggleInterval = originalToggleInterval;

        // // Start moving TextImage and textComponent simultaneously
        // Coroutine moveTextImageCoroutine = StartCoroutine(MoveTextImageToPosition());
        // Coroutine moveTextComponentCoroutine = StartCoroutine(MoveTextComponentToPosition());

        // // Wait for both coroutines to complete
        // yield return moveTextImageCoroutine;
        // yield return moveTextComponentCoroutine;

        // Change the scene after both movements are complete
        ChangeScene();
    }

    // IEnumerator MoveTextImageToPosition()
    // {
    //     Vector2 targetPosition = new Vector2(textImage.anchoredPosition.x, TextImageMovePosY);

    //     while (Mathf.Abs(textImage.anchoredPosition.y - TextImageMovePosY) > 0.1f)
    //     {
    //         // Gradually move the TextImage towards the target Y position
    //         textImage.anchoredPosition = Vector2.MoveTowards(textImage.anchoredPosition,
    //             targetPosition,
    //             moveSpeed * Time.deltaTime);
    //         yield return null; // Wait for the next frame
    //     }
    // }

    // IEnumerator MoveTextComponentToPosition()
    // {
    //     Vector2 targetPosition = new Vector2(textComponent.rectTransform.anchoredPosition.x, textComponentMovePosY);

    //     while (Mathf.Abs(textComponent.rectTransform.anchoredPosition.y - textComponentMovePosY) > 0.1f)
    //     {
    //         // Gradually move the textComponent towards the target Y position
    //         textComponent.rectTransform.anchoredPosition = Vector2.MoveTowards(textComponent.rectTransform.anchoredPosition,
    //             targetPosition,
    //             moveSpeed * Time.deltaTime);
    //         yield return null; // Wait for the next frame
    //     }
    // }

    IEnumerator AutoToggleRendering()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggleInterval);
            isRendering = !isRendering;
            textComponent.enabled = isRendering;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(newSceneName); // Load the new scene
    }

    // IEnumerator FadeOutBackgroundVolume()
    // {
    //     float startVolume = audioSource.volume;

    //     while (audioSource.volume > 0.1f)
    //     {
    //         audioSource.volume -= startVolume * Time.deltaTime / 2f; // Adjust the duration as needed
    //         yield return null;
    //     }

    //     audioSource.volume = 0.1f; // Set to a low volume
    // }
}
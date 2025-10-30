using TMPro;
using UnityEngine;
using UnityEngine.UI; // Botón de UI clásico
using UnityEngine.SceneManagement; // Para cambiar de escenas

public class NivelSelector : MonoBehaviour
{
    public GameObject nivelButtonPrefab;  
    public Transform buttonContainer;      
    public int totalLevels = 10;           

    void Start()
    {
        GenerateLevelButtons(); 
    }

    void GenerateLevelButtons()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
          
            GameObject buttonObj = Instantiate(nivelButtonPrefab, buttonContainer);

            
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = "Nivel " + i;
            }

            int nivelIndex = i; 

            
            Button uiButton = buttonObj.GetComponent<Button>();
            if (uiButton != null)
            {
                uiButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene("Nivel_" + nivelIndex);
                });
            }
        }
    }
}


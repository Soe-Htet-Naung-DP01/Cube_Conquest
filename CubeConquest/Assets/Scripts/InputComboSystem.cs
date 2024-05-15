using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComboSystem : MonoBehaviour
{
    private string currentComboInput = "";
    private Renderer cubeRenderer;
    private bool isCastingCombo;

    [SerializeField] private Material fireMaterial;
    [SerializeField] private Material iceMaterial;
    [SerializeField] private Material defaultMaterial;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Ignore input if casting combo
        if (isCastingCombo)
            return;

        // Check for combo inputs
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentComboInput += "Q";
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentComboInput += "E";
        }

        // Check for combo completion
        if (currentComboInput.Length >= 3)
        {
            if (currentComboInput == "QQQ")
            {
                CastFireCombo();
            }
            else if (currentComboInput == "EEE")
            {
                CastIceCombo();
            }
            else
            {
                // Cancel the current combo if it doesn't match "QQQ" or "EEE"
                CancelCombo();
            }

            // Reset the combo input after a short delay
            currentComboInput = "";
            Invoke(nameof(ResetCombo), 1.5f);
        }
    }

    private void CastFireCombo()
    {
        isCastingCombo = true;
        cubeRenderer.material = fireMaterial;
        Debug.Log("Casting Fire Combo!");
    }

    private void CastIceCombo()
    {
        isCastingCombo = true;
        cubeRenderer.material = iceMaterial;
        Debug.Log("Casting Ice Combo!");
    }

    private void CancelCombo()
    {
        Debug.Log("Combo Canceled!");
        cubeRenderer.material = defaultMaterial;
    }

    private void ResetCombo()
    {
        isCastingCombo = false;
        cubeRenderer.material = defaultMaterial; // Set the material back to the default (ice) after combo casting is complete
    }

    // Method to get the current combo input
    public string GetCurrentComboInput()
    {
        return currentComboInput;
    }
}

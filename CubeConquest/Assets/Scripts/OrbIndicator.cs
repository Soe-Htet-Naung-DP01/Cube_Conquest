using UnityEngine;

public class OrbIndicator : MonoBehaviour
{
    public InputComboSystem inputComboSystem;
    public GameObject orbPrefab;
    public Transform orbSpawnPoint;
    public float orbRadius = 2f;
    public float orbRotationSpeed = 100f;

    private GameObject[] orbs;

    private void Start()
    {
        CreateOrbs(); // Create orbs at the start
    }

    private void CreateOrbs()
    {
        orbs = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            GameObject orb = Instantiate(orbPrefab, orbSpawnPoint.position, Quaternion.identity, orbSpawnPoint);
            orbs[i] = orb;
            orb.SetActive(false); // Hide orbs initially
        }
    }

    private void Update()
    {
        // Rotate the orbs around the player only when combo starts
        if (inputComboSystem.GetCurrentComboInput().Length > 0)
        {
            for (int i = 0; i < orbs.Length; i++)
            {
                Vector3 orbPosition = orbSpawnPoint.position;
                float angle = i * (360f / orbs.Length) + Time.time * orbRotationSpeed;
                orbPosition += Quaternion.Euler(0f, angle, 0f) * Vector3.forward * orbRadius;
                orbs[i].transform.position = orbPosition;
            }
        }

        // Get the current combo input from InputComboSystem
        string currentComboInput = inputComboSystem.GetCurrentComboInput();

        // Check if the current combo input is not empty
        if (!string.IsNullOrEmpty(currentComboInput))
        {
            // Show the appropriate number of orbs based on the current combo input length
            for (int i = 0; i < currentComboInput.Length; i++)
            {
                orbs[i].SetActive(true);
            }

            // Hide any remaining orbs
            for (int i = currentComboInput.Length; i < orbs.Length; i++)
            {
                orbs[i].SetActive(false);
            }
        }
        else
        {
            // If the current combo input is empty, deactivate all orbs
            foreach (GameObject orb in orbs)
            {
                orb.SetActive(false);
            }
        }
    }
}

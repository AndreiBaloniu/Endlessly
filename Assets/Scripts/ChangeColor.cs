using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float timeSinceLastColorChange = 0f;
    public float timeBetweenColorChanges = 1f;
    private Color targetColor;
    private Color currentColor;

    // Inițializează SpriteRenderer la începutul rulării
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = spriteRenderer.color;
        // atribuie aleator un nou Color obiect sprite-ului
        targetColor = new Color(Random.value, Random.value, Random.value);
    }

    // La fiecare cadru, schimbă culoarea sprite-ului într-una aleatoare la intervale regulate de timp
    private void Update()
    {
        // Verifică dacă a trecut destul timp pentru a schimba culoarea din nou
        if (timeSinceLastColorChange >= timeBetweenColorChanges)
        {
            // Schimbă culoarea sprite-ului într-una aleatoare
            currentColor = spriteRenderer.color;
            targetColor = new Color(Random.value, Random.value, Random.value);
            // Resetează cronometrul pentru următoarea schimbare de culoare
            timeSinceLastColorChange = 0f;
        }
        // Incrementăm cronometrul pentru a ține evidența timpului trecut între schimbările de culoare
        timeSinceLastColorChange += Time.deltaTime;

        // Interpolează între culorile curentă și ținta pentru a crea o tranziție lină
        spriteRenderer.color = Color.Lerp(currentColor, targetColor, timeSinceLastColorChange / timeBetweenColorChanges);
    }
}

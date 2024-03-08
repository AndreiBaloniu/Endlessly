using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public float colorChangeInterval = 2f; // Intervalul de timp dintre schimbările de culoare
    public float colorChangeRate = 0.05f; // Rata de schimbare a culorii (0.0f - 1.0f)
    public Image panelImage; // Imaginea panoului

    private Color targetColor; // Culoarea țintă, spre care se va schimba culoarea actuală
    private float elapsedTime; // Timpul scurs de la ultima schimbare de culoare

    // Culorile disponibile
    private Color[] colors = new Color[]
    {
        new Color(0.4f, 0.0f, 0.4f), // mov inchis
        new Color(0.0f, 0.2f, 0.4f), // albastru inchis
        new Color(0.4f, 0.0f, 0.0f), // rosu inchis
        new Color(0.0f, 0.4f, 0.0f), // verde inchis
    };

    // Start is called before the first frame update
    void Start()
    {
        // Setează o culoare inițială aleatoare pentru panou
        panelImage.color = colors[Random.Range(0, colors.Length)];

        // Inițializează timpul scurs de la ultima schimbare de culoare cu intervalul specificat
        elapsedTime = colorChangeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Incrementază timpul scurs de la ultima schimbare de culoare
        elapsedTime += Time.deltaTime;

        // Dacă timpul scurs depășește intervalul specificat, schimbă culoarea panoului
        if (elapsedTime >= colorChangeInterval)
        {
            // Setează culoarea țintă, o culoare aleatoare din lista de culori disponibile, dar mai întunecată
            Color currentColor = panelImage.color;
            Color newColor = colors[Random.Range(0, colors.Length)];
            targetColor = Color.Lerp(currentColor, newColor, colorChangeRate);

            // Resetază timpul scurs de la ultima schimbare de culoare
            elapsedTime = 0f;
        }

        // Schimbă treptat culoarea panoului spre culoarea țintă
        panelImage.color = Color.Lerp(panelImage.color, targetColor, Time.deltaTime * 0.5f);
    }
}

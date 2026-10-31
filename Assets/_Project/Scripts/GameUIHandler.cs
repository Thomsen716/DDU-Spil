using UnityEngine;
using UnityEngine.UIElements;

public class GameUIHandler : MonoBehaviour
{
    public PlayerControl PlayerControl; // Bruger PlayerControl som i dit originalprojekt
    public UIDocument UIDoc;

    private VisualElement m_HealthBarFill; // Referencen til selve fyldet

    private void Start()
    {
        // Lyt på eventen fra PlayerControl
        PlayerControl.OnHealthChange += HealthChanged;

        // Find fyldet i din UI Document via dens navn i UI Builder ("HealthBarFill")
        m_HealthBarFill = UIDoc.rootVisualElement.Q<VisualElement>("HealthBarFill");

        // Kør den én gang ved start, så baren har den rigtige størrelse fra start
        HealthChanged();
    }

    void HealthChanged()
    {
        if (m_HealthBarFill != null)
        {
            // 1. Regn ud hvor mange procent liv spilleren har tilbage (f.eks. 1.0 = fuldt liv, 0.5 = halv skade)
            float healthPercent = (float)PlayerControl.currentHealth / PlayerControl.maxHealth;

            // 2. Sæt bredden som en procentdel (0% til 100%), så den skrumper når man mister liv
            m_HealthBarFill.style.width = new Length(healthPercent * 100, LengthUnit.Percent);
        }
    }
}
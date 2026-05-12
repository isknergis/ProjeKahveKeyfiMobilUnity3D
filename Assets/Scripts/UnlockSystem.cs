using System.Collections.Generic;
using UnityEngine;

public class UnlockSystem : MonoBehaviour
{
    public List<string> unlockedAromas = new List<string>();
    private GameManager gameManager;

    // Kilitli objelerin rengi (Koyu Gri)
    private Color lockedColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    // Açýk objelerin rengi (Beyaz/Kendi Rengi)
    private Color unlockedColor = Color.white;

    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Start()
    {
        SyncEverything();
    }

    public void CheckUnlock(int level)
    {
        bool change = false;

        if (level >= 2)
        {
            if (AddAroma("Fýndýk")) change = true;
            if (AddAroma("Karamel")) change = true;
        }
        if (level >= 3)
        {
            if (AddAroma("Fýstýk")) change = true;
            if (AddAroma("Bal")) change = true;
        }
        if (level >= 4)
        {
            if (AddAroma("Tarçýn")) change = true;
            if (AddAroma("Damla Sakýzý")) change = true;
        }

        if (change)
        {
            SyncEverything();
        }
    }

    private bool AddAroma(string aromaName)
    {
        if (!unlockedAromas.Contains(aromaName))
        {
            unlockedAromas.Add(aromaName);
            return true;
        }
        return false;
    }

    public void SyncEverything()
    {
        // 1. Butonlarý Güncelle
        AromaButton[] buttons = FindObjectsByType<AromaButton>(FindObjectsSortMode.None);
        foreach (var btn in buttons) btn.CheckUnlockStatus();

        // 2. 3D Objeleri Güncelle
        GameObject[] aromaVisuals = GameObject.FindGameObjectsWithTag("AromaObject");

        foreach (GameObject obj in aromaVisuals)
        {
            // HATA ÇÖZÜMÜ: AromaSelection yerine AromaButton'dan isim çekmeyi deniyoruz
            // Eðer AromaSelection kullanacaksan, o scriptin içinde 'public string aromaName;' olduðundan emin ol.
            AromaButton aromaBtn = obj.GetComponentInParent<AromaButton>();

            if (aromaBtn != null)
            {
                // Burada AromaButton scriptindeki isim deðiþkenini kullanmalýsýn
                // Eðer hata devam ederse AromaButton içindeki isim deðiþkeninin adýný kontrol et
                string currentAroma = aromaBtn.aromaName;
                Renderer rend = obj.GetComponent<Renderer>();

                if (rend != null)
                {
                    if (unlockedAromas.Contains(currentAroma))
                    {
                        rend.material.color = unlockedColor;
                    }
                    else
                    {
                        rend.material.color = lockedColor;
                    }
                }
            }
        }

        // 3. Order Manager Güncelle
        if (gameManager != null && gameManager.orderManager != null)
        {
            gameManager.orderManager.unlockedAromas = new List<string>(unlockedAromas);
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    public string selectedCoffee;
    public int sugarLevel = 0;
    public Text sugarText;

    [Header("Mantýk Kilidi")]
    public bool siparisVerildimi = false; // Fincan masaya giderken bu true olacak

    [Header("Þeker Görselleþtirmesi")]
    public Light sugarPointLight; // Bardaðýn içindeki Point Light
    public float baseIntensity = 10f;

    void Start()
    {
        UpdateSugarUI();
    }

    public void SelectCoffee(string coffee, GameObject coffeeLight)
    {
        // KÝLÝT: Eðer sipariþ verildiyse (fincan masadaysa) seçim yapma
        if (siparisVerildimi) return;

        // 1. SADECE Kahve Butonlarýnýn üzerindeki seçim ýþýklarýný kapatýyoruz
        CoffeeButton[] allButtons = FindObjectsByType<CoffeeButton>(FindObjectsSortMode.None);
        foreach (CoffeeButton btn in allButtons)
        {
            if (btn.selectionLight != null)
                btn.selectionLight.SetActive(false);
        }

        // 2. Seçilen kahveyi kaydet ve buton ýþýðýný yak
        selectedCoffee = coffee;
        if (coffeeLight != null) coffeeLight.SetActive(true);

        UpdateSugarUI();
        Debug.Log("Seçilen kahve: " + coffee);
    }

    public void NextSugar()
    {
        // KÝLÝT: Eðer sipariþ verildiyse þeker miktarýný deðiþtirme
        if (siparisVerildimi) return;

        sugarLevel = (sugarLevel + 1) % 3;
        UpdateSugarUI();
    }

    void UpdateSugarUI()
    {
        string text = sugarLevel == 0 ? "Sade" :
                      sugarLevel == 1 ? "Orta" : "Çok";

        if (sugarText != null)
            sugarText.text = "Þeker: " + text;

        if (sugarPointLight != null)
        {
            if (sugarLevel == 0)
            {
                sugarPointLight.intensity = 0;
            }
            else if (sugarLevel == 1)
            {
                sugarPointLight.intensity = baseIntensity;
                sugarPointLight.color = new Color(1f, 0.9f, 0.7f);
            }
            else
            {
                sugarPointLight.intensity = baseIntensity * 3f;
                sugarPointLight.color = Color.white;
            }
        }
    }

    // Yeni sipariþ geldiðinde veya temizlik yapýldýðýnda çaðýr
    public void ResetSelection()
    {
        siparisVerildimi = false; // KÝLÝDÝ AÇ: Tekrar kahve/þeker seçilebilir
        selectedCoffee = null;
        sugarLevel = 0;
        UpdateSugarUI();

        CoffeeButton[] allButtons = FindObjectsByType<CoffeeButton>(FindObjectsSortMode.None);
        foreach (CoffeeButton btn in allButtons)
        {
            if (btn.selectionLight != null) btn.selectionLight.SetActive(false);
        }
    }
}
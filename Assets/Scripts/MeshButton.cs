using UnityEngine;
using UnityEngine.Events;

public class MeshButton : MonoBehaviour
{
    // Bu kýsýmlarý Inspector'dan sürükleyip baðlayacaðýz
    public GameManager gameManager;

    public enum ClickType { KahveSec, SekerArtir, AromaEkle }
    public ClickType neYapsin;

    public string kahveVeyaAromaAdi; // "Espresso" veya "Vanilya" gibi

    void OnMouseDown()
    {
        Debug.Log(gameObject.name + " objesine týklandý!");

        if (gameManager == null) return;

        switch (neYapsin)
        {
            case ClickType.KahveSec:
                gameManager.player.SelectCoffee(kahveVeyaAromaAdi, null);
                break;
            case ClickType.SekerArtir:
                gameManager.player.NextSugar();
                break;
            case ClickType.AromaEkle:
                // Buraya aroma ekleme mantýðýný baðlayabilirsin
                break;
        }
    }
}
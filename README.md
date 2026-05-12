# ☕ Coffee Joy: 3D Barista Simulator

**Kahve Keyfi**, oyuncuyu huzurlu ama tempolu bir kahve dükkanının merkezine koyan, strateji ve dikkati birleştiren bir barista simülasyonudur. Bu projede bir baristanın günlük rutinini, gelişmiş bir oyun mekaniği ve dinamik görsel geri bildirimlerle birleştirmeyi hedefledim.

---

## 🌟 Oyun Konsepti
Bir barista olarak her seviyede daha zorlu siparişlerle karşılaşıyorsunuz. Oyun sadece bir "hazırlama" süreci değil, aynı zamanda bir keşif yolculuğudur. Seviye atladıkça yeni aromaların kilitlerini açar, daha sofistike tarifler hazırlarsınız. Şeker dengesinden aroma seçimine kadar her dokunuş, müşterinin memnuniyetini etkiler.

## 🚀 Öne Çıkan Özellikler
* **Dinamik Sipariş Algoritması:** Seviyeye bağlı olarak binlerce farklı kahve-şeker-aroma kombinasyonu sunar.
* **İlerleme Odaklı Görselleştirme:** Kilitli olan 3D aroma modelleri sahnede gri ve sönük dururken, kilit açıldığında gerçek zamanlı materyal değişimi ile canlanarak renklenir.
* **Zamana Karşı Yarış:** Seviye arttıkça daralan sabır süresiyle artan oyun zorluğu, oyuncunun karar verme hızını test eder.
* **Etkileşimli 3D Dünyası:** Tüm UI ve 3D modellerin birbiriyle konuştuğu (seçim yapınca tetiklenen ışıklar, animasyonlar vb.) bütünsel bir yapı.

## 🛠️ Teknik Altyapı
Proje, modüler bir kod mimarisi ve tamamen özgün varlıklar (assets) üzerine inşa edilmiştir:

* **Yazılım Mimarisi:** C# ile geliştirilen modüler yapı; `OrderManager`, `UnlockSystem` ve `PlayerSelection` gibi ana scriptler üzerinden merkezi bir yönetim sağlar.
* **Kullanıcı Arayüzü (UI):** Tüm tasarımlar tarafımdan hazırlanmıştır. Slider ve Fill Image sistemleriyle gerçek zamanlı durum takibi (müşteri sabrı vb.) sağlanmıştır.
* **3D Modelleme & Tasarım:** Sahnede bulunan tüm modeller, UI tasarımları ve ses efektleri tamamen tarafımca tasarlanmış ve projeye dahil edilmiştir.


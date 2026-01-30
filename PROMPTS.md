# LLM Kullanım Dokümantasyonu

> Bu dosyayı case boyunca kullandığınız LLM (ChatGPT, Claude, Copilot vb.) etkileşimlerini belgelemek için kullanın.
> Dürüst ve detaylı dokümantasyon beklenmektedir.

## Özet

Semih Kaan Duran
https://www.linkedin.com/in/semih-kaan-duran-09359933a/
https://github.com/5ekha

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | 9 |
| Kullanılan araçlar | Gemini |
| En çok yardım alınan konular | Kodlama |
| Tahmini LLM ile kazanılan süre | 6 saat |

-----------------------------------------------------------------------------------------------------------------------------------

## Prompt 1: [Raycast ve Interface Kodları]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 14:15

**Prompt:**
```
[Unity'de Raycast ve Interface kullanarak objelerle etkileşime geçmemi sağlayan bir script yaz.]
```

**Alınan Cevap (Özet):**
```
[IInteractable arayüzü ve oyuncunun baktığı objeyi algılayan InteractionDetector scripti sağlandı. LayerMask kullanımı ve Interface üzerinden haberleşme mantığı açıklandı.]
```

**Nasıl Kullandım:**
- [X] Direkt kullandım (değişiklik yapmadan)
- [ ] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**
> Bir Raycase kullanarak ve IInteractable arayüzünü inherit alarak objelerle etkileşime geçilmesi gerektiğini öğrendim.

-----------------------------------------------------------------------------------------------------------------------------------

## Prompt 2: [UI ve Bilgi Mesajları]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 14:30

**Prompt:**
```
[Objeye bakarken ekranda 'E'ye bas yazısnın çıkmasını sağla.]
```

**Alınan Cevap (Özet):**
```
[InteractionUI scripti oluşturuldu. Interface'e InteractionPrompt özelliği eklendi ve UI'ın Raycast verisine göre güncellenmesi sağlandı.]
```

**Nasıl Kullandım:**
- [X] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Öğrendiğime göre oyuncudan çıkan bir raycastin interactable objelere değip değmemesini kontrol ederek interaction işlemi sağlanıyor.

-----------------------------------------------------------------------------------------------------------------------------------

## Prompt 3: [Envanter ve Anahtar Sistemi]

**Araç:** [Gemini]
**Tarih/Saat: 2026-01-30 14:45

**Prompt:**
```
[Kilitli kapının anahtarla açılmasını sağlayan bir script yaz ve mantığını bana açıkla.]
```

**Alınan Cevap (Özet):**
```
[PlayerInventory (List<string>) scripti yazıldı. Key ve LockedDoor sınıfları oluşturularak ID tabanlı anahtar kontrol mekanizması kuruldu.]
```

**Nasıl Kullandım:**
- [X] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Kilitli kapının anahtar envanterde olmadan açılmasını engelleyen bir kod yazdı.

-----------------------------------------------------------------------------------------------------------------------------------

## Prompt 4: [Switch ve Lamba Otomasyonu]

**Araç:** [Gemini]
**Tarih/Saat: 2026-01-30 15:00

**Prompt:**
```
[Bir switch ile etkileşime girildiğinde lambanın yanmasını sağlayan scripti yaz.]
```

**Alınan Cevap (Özet):**
```
[ITriggerable interface'i tanıtıldı. PhysicalSwitch'in bir TargetObject alıp onu tetiklemesi (Decoupled architecture) sağlandı.]
```

**Nasıl Kullandım:**
- [X] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> ITriggerable interfacei inherit edilerek switchin lambayı tetiklemesi sağlandı.

-----------------------------------------------------------------------------------------------------------------------------------

## Prompt 5: [İlerleme Çubuğu ve Basılı Tutma]

**Araç:** [Gemini]
**Tarih/Saat: 2026-01-30 15:15

**Prompt:**
```
[Belli bir tuşa basılı tutulunca dolan bir loading barı tasarla]
```

**Alınan Cevap (Özet):**
```
[InteractionDetector'a float zamanlayıcı (timer) eklendi. UI tarafında Slider kontrolü sağlandı. IInteractable'a HoldDuration özelliği eklendi.]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [X] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Unity'nin built-in slider'ı kullanılarak loading bar benzeri bir arayüz elemanı oluşturuldu.

-----------------------------------------------------------------------------------------------------------------------------------

## Prompt 6: [Sandık Mekanizması]

**Araç:** [Gemini]
**Tarih/Saat: 2026-01-30 15:45

**Prompt:**
```
[İçinde anahtarın bulunduğu bir sandığı nasıl yapabilirim?]
```

**Alınan Cevap (Özet):**
```
[Pivot (menteşe) mantığı açıklandı. Boş bir obje (Parent) kullanarak kapağın kenardan dönmesi için sahne kurulumu ve LootChest scripti sağlandı.]
```

**Nasıl Kullandım:**
- [X] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Boş bir pivot objesine child olarak chest tanıtıldı ve etkileşim anında pivot etrafında dönüş sağlandı.

-----------------------------------------------------------------------------------------------------------------------------------

## Prompt 7: [Görev Döngüsü]

**Araç:** [Gemini]
**Tarih/Saat: 2026-01-30 16:00

**Prompt:**
```
[Kilitli kapı, sandık, anahtar ve switch bulunan bir oynanış döngüsü nasıl yaratırım?]
```

**Alınan Cevap (Özet):**
```
[Objeleri art arda dizerek ve birbirlerine bağımlı hale getirerek bir oyun döngüsü önerildi.]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [X] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Bu aşamada artık basit bir oyun prototipi elde etmiş oldum..

-----------------------------------------------------------------------------------------------------------------------------------

## Prompt 8: [Ses Efektleri ve Cila]

**Araç:** [Gemini]
**TTarih/Saat: 2026-01-30 16:30

**Prompt:**
```
[Kapıya, sandığa (arama sesi dahil), anahtar toplamaya ve switch'e ses eklemek istiyorum. Bunu nasıl yapabilirim?]
```

**Alınan Cevap (Özet):**
```
[AudioSource ve PlayOneShot kullanımı gösterildi. Sandık için looping (döngüsel) ses, anahtar için PlayClipAtPoint (yok olan objeler için) mantığı uygulandı..]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [X] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Sandık için döngüsel ses özelliği çalışmadı ancak diğer etkileşimli olaylara ses efekleri eklendi.

-----------------------------------------------------------------------------------------------------------------------------------
## Prompt 9: [Görsel Geri Bildirim]

**Araç:** [Gemini]
**TTarih/Saat: 2026-01-30 16:40

**Prompt:**
```
[Platformların ve objelerin rengini nasıl değiştiririm?]
```

**Alınan Cevap (Özet):**
```
[Renderer ve Material kullanımı açıklandı. ITriggerable interface'i üzerinden Switch ile tetiklenen bir ColorChanger scripti sağlandı.]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [X] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Materiallar kullanarak objeleri metalik ve renkli hale getirdim..

-----------------------------------------------------------------------------------------------------------------------------------


## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar
1. [Kodlama]
2. [Mekaniklerin arkasındaki mantık]
3. [Unity arayüzü kullanımı]

### LLM'in Yetersiz Kaldığı Alanlar
1. [Yaratıcılık]

### LLM Kullanımı Hakkında Düşüncelerim
> [Bu case boyunca LLM kullanarak neler öğrendiniz?
	- LLM kullanarak asıl yaratıcılık gerektiren oynanış ve tasarım kısmın insana ait olduğunu ve öğrendikten sonra tekrar tekrar kod yazarak zaman kaybetmemek için LLM'lerden faydalanmak gerektiğini kavradım.
> LLM'siz ne kadar sürede bitirebilirdiniz?
	- LLM olmadan bunu muhtemelen 12 saatte bitiremezdim. Şayet bu süreçte bile bir sürü şey öğrendim. İnternetten işime yarayacak mekanikleri tek tek öğrenmek ve implemente etmek haftalarımı alabilirdi.
> Gelecekte LLM'i nasıl daha etkili kullanabilirsiniz?]
	- Bu biraz da LLM'lerin gelecekte nereye evrileceğiyle alakalı. Ancak şu anki haliyle kod yazma kısmını insandan daha hatasız ve hızlı bir şekilde halledebildiği için yaratıcılık ve tasarım kısımlarında insanın daha fazla vakti oluyor.

---

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*

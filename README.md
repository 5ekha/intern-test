> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | Unity 6.0 (6000.0.5.51f1) |
| Render Pipeline | Built-in / URP / HDRP |
| Case Süresi | 12 saat |
| Tamamlanma Oranı | %95 |

---------------------------------------------------------------------------------------------------------------------------------

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/[username]/[repo-name].git
```

2. Unity Hub'da projeyi açın
3. `Assets/[ProjectName]/Scenes/TestScene.unity` sahnesini açın
4. Play tuşuna basın

---------------------------------------------------------------------------------------------------------------------------------

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |

### Test Senaryoları

1. **Door Test:** ✅
   - Kapıya yaklaşın, "Press E to Open" mesajını görün
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:** ✅
   - Kilitli kapıya yaklaşın, "Locked - Key Required" mesajını görün
   - Anahtarı bulun ve toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

3. **Switch Test:** ✅
   - Switch'e yaklaşın ve aktive edin
   - Bağlı nesnenin (kapı/ışık vb.) tetiklendiğini görün

4. **Chest Test:** ✅
   - Sandığa yaklaşın
   - E'ye basılı tutun, progress bar dolsun
   - Sandık açılsın ve içindeki item alınsın

---------------------------------------------------------------------------------------------------------------------------------

## Mimari Kararlar

### Interaction System Yapısı

Sistem Interface-based (Arayüz tabanlı) bir mimari üzerine kurulmuştur.

InteractionDetector: Raycast atarak IInteractable arayüzüne sahip objeleri algılar.

IInteractable: Her etkileşimli nesnenin (Door, Key, Chest) uyması gereken sözleşmedir.

Neden bu yapıyı seçtim: PlayerController veya InteractionDetector sınıflarının, etkileşime girilen nesnenin ne olduğunu (kapı mı, sandık mı) bilmesine gerek yoktur. Bu sayede yeni bir etkileşimli nesne eklerken mevcut kodları değiştirmek gerekmez (Open/Closed Principle).

Alternatifler: Tag tabanlı kontrol veya GetComponent<Door>() gibi doğrudan referans alma. Ancak bu yöntemler sistem büyüdükçe performans kaybına ve kod karmaşasına (spagetti kod) yol açar.

Trade-off'lar: Interface kullanımı başlangıçta biraz daha fazla dosya/yapı kurulumu gerektirir ancak uzun vadede bakım ve genişletilebilirlik sağlar.

### Kullanılan Design Patterns

Pattern	Kullanım 	Yeri				Neden
Interface		IInteractable, ITriggerable	Nesneler arası bağımlılığı (Decoupling) minimize etmek için.
Strategy		Farklı Interactable sınıfları	Her nesnenin kendi "Interact" mantığını kendi içinde barındırması için.
Coroutine		Door Rotation & Color Lerp	İşlemleri asenkron ve akıcı bir şekilde yönetmek için.

---------------------------------------------------------------------------------------------------------------------------------

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

Kural,Uygulandı,Notlar
m_ prefix (private fields),	[x],Tüm private değişkenlerde kullanıldı.
s_ prefix (private static),	[x],Statik değişkenlerde uygulandı.
Region kullanımı,		[x],Kod okunabilirliği için alanlar ayrıldı.
Explicit interface impl.,	[x],IInteractable üyeleri açıkça tanımlandı.

### Naming Convention

Kural,Uygulandı,Örnekler
P_ prefix (Prefab),		[x],"P_Loot_Chest, P_Rotating_Door"
M_ prefix (Material),		[x],M_Platform_Active
T_ prefix (Texture),		[x],T_Wood_Albedo

### Zorlandığım Noktalar
> [Standartları uygularken zorlandığınız yerler]

---------------------------------------------------------------------------------------------------------------------------------

## Tamamlanan Özellikler

Zorunlu (Must Have)
[x] Core Interaction System (Raycast + Interface)

[x] Interaction Types (Instant, Hold, Toggle)

[x] Interactable Objects (Locked Door, Key, Switch, Chest)

[x] UI Feedback (Dynamic Prompts, Progress Bar)

[x] Simple Inventory (ID based Key System)

Bonus (Nice to Have)
[x] Sound Effects: Kapı gıcırtısı, kilit sesi, sandık karıştırma ve switch klik sesleri.

[x] Smooth Animations: Coroutine tabanlı Quaternion rotasyonları.

[x] Feedback: Sandık açıldığında içinden anahtar çıkması (Nested interaction).

[x] Visual Toggles: Switch ile tetiklenen renk değişimleri.

---------------------------------------------------------------------------------------------------------------------------------

## Bilinen Limitasyonlar

### Bilinen Bug'lar
1.[Chest searching sfx hata] 
2.[Chest aranırken loading bar dolarken oynaması gereken ses efekkti çalışmadı]
 

### İyileştirme Önerileri
1. Animasyonlar ve karakterler eklenebilirdi
2. Bulmaca şeklinde bölüm dizaynları yapılabilirdi

---------------------------------------------------------------------------------------------------------------------------------

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:

1. **[Ses efektleri]**
   - Açıklama: Bazı nesnelerle etkileşime girildiğinde ses efekti oynuyor.
   - Neden ekledim: Daha oyunsu hissettirmesi adına

2. **[Sandıktaki anahtar]**
   - Açıklama: Sandığın içine bedava bir anahtar asseti bulup koydum.
   - Neden: Anahtarı bulup kapıyı açma hissini verebilmek için

3. **[Renklendirme]**
   - Açıklama: Objeleri ve platformları renklendirdim.
   - Nedeni: Estetik gözükmesi için.


## Dosya Yapısı

---------------------------------------------------------------------------------------------------------------------------------
Assets/
├── [ProjectName]/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── IInteractable.cs
│   │   │   │   └── ...
│   │   │   ├── Interactables/
│   │   │   │   ├── Door.cs
│   │   │   │   └── ...
│   │   │   ├── Player/
│   │   │   │   └── ...
│   │   │   └── UI/
│   │   │       └── ...
│   │   └── Editor/
│   ├── ScriptableObjects/
│   ├── Prefabs/
│   ├── Materials/
│   └── Scenes/
│       └── TestScene.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore
```
------------------------------------------------------------------------------------------------------------------------------------

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | [Semih Kaan Duran] |
| E-posta | [semihkaan58@gmail.com] |
| LinkedIn | [https://www.linkedin.com/in/semih-kaan-duran-09359933a/] |
| GitHub | [https://github.com/5ekha] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*

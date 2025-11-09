# 💻 Projekt: Digitalni potpis

Ovaj projekt izrađen je u sklopu kolegija **Napredni operacijski sustavi** na *Sveučilištu u Zagrebu, Fakultetu organizacije i informatike*.

Projekt prikazuje **izvedbu sustava digitalnog potpisa** pomoću programskog jezika **C#** i okvira **Windows Forms**. Kroz aplikaciju se omogućuje stvaranje i verifikacija digitalnog potpisa korištenjem kriptografskih algoritama.

---

## 🎯 **Cilj projekta**
Cilj projekta je demonstrirati praktičnu implementaciju koncepta digitalnog potpisa u sigurnosti podataka. Digitalni potpis osigurava **autentičnost, integritet i neporecivost** podataka tijekom prijenosa između korisnika.

---

## 🧠 **Opis rješenja**
Aplikacija omogućuje:
- Generiranje para kriptografskih ključeva (privatni i javni ključ)
- Potpisivanje datoteka pomoću privatnog ključa
- Provjeru autentičnosti potpisa pomoću javnog ključa
- Pohranu i učitavanje ključeva te digitalnih potpisa

Projekt koristi klase iz .NET biblioteke kao što su **RSA**, **SHA256** i **CryptoStream** za implementaciju kriptografskih operacija.

---

## 🧩 **Korištene tehnologije**
- C# (.NET Framework)
- Windows Forms
- System.Security.Cryptography biblioteka
- Visual Studio 2022

---

## ⚙️ **Upute za pokretanje**
1. Otvorite projekt u **Visual Studio 2022** ili novijem.
2. Provjerite da su sve reference automatski učitane.
3. Pokrenite aplikaciju (F5) i odaberite datoteku za potpisivanje.
4. Generirajte ključeve, potpišite datoteku te provjerite valjanost potpisa.

---

## 📁 **Struktura repozitorija**
```
digital-signature-project/
│
├── docs/                ← dokumentacija i dodatni materijali
├── screenshots/         ← slike aplikacije
├── src/                 ← izvorni kod (Windows Forms projekt u C#)
│   ├── Form1.cs
│   ├── Program.cs
│   └── ...
└── README.md            ← opis projekta
```

---

## 🧾 **Teorijska podloga**
Digitalni potpis je kriptografski mehanizam koji koristi asimetrične algoritme (npr. RSA).  
Proces uključuje stvaranje **hash vrijednosti** dokumenta i njezino **šifriranje privatnim ključem**.  
Primatelj koristi **javni ključ** za provjeru potpisa i osigurava da sadržaj nije mijenjan nakon potpisivanja.

---

## 🏷️ **Oznake (tags)**
`#digitalni-potpis` `#kriptografija` `#sigurnost-podataka` `#csharp`  
`#windows-forms` `#foi` `#napredni-operacijski-sustavi` `#akademski-projekt`

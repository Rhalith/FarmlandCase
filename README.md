# **🌾 Farmland Case - Wibesoft İşe Alım Değerlendirme Projesi**  

Bu proje, **Wibesoft işe alım süreci kapsamında hazırlanan çiftlik/simülasyon oyunu geliştirme testidir**.  
Proje, **grid tabanlı tarım ve bina yerleştirme mekanizmalarını** içermektedir.  

---

## **🎮 Oynanış Mekanikleri**  
### **🌱 Ekin Sistemi (Görev 1)**  
1. **Boş bir grid hücresine tıklayarak** ekin ekin.  
2. **Ekinlerin zamanla büyümesini izleyin** (farklı aşamalarla).  
3. **Olgunlaşan ekinleri tıklayarak hasat edin.**  
4. **Yeni ekinler ekerek süreci tekrar edin.**  

### **🏗️ Bina Yerleştirme (Görev 2)**  
1. **Boş bir grid hücresine tıklayarak bina yerleştirin.**  
2. **Tıklanabilir grid hücreleri şeffaf mavi olarak işaretlenmiştir.**  
3. **Yerleştirilen binaları kaldırmak için tıklayın ve boş alanı geri kazanın.**  

---

## **🛠️ Kullanılan Teknolojiler**  
- **Oyun Motoru:** Unity (2022.x ve üzeri)  
- **Programlama Dili:** C#  
- **Render Pipeline:** Built-in / URP  
- **Versiyon Kontrol:** Git + GitHub  
- **Mobil Uyumluluk:** Touch Input desteği  

---

## **🖥️ Sistem Mimarisi**  

### **🌱 Ekin Sistemi (Görev 1)**
Ekin ekme, büyütme ve hasat etme mekanizmalarını içeren bir **grid tabanlı tarım sistemi**.

| **Bileşen** | **Açıklama** |
|-------------|-------------|
| `FieldGrid.cs` | Tarlayı oluşturur ve grid hücrelerini yönetir. |
| `Plot.cs` | Grid hücrelerini temsil eder, ekin ekme ve hasat işlemlerini yönetir. |
| `Crop.cs` | Ekin büyüme aşamalarını kontrol eder ve hasat işlemini belirler. |
| `CropChooser.cs` | Rastgele bir ekin türü seçerek ekme işlemini yönetir. |

**🔹 Akış Şeması:**  
1. **Grid (FieldGrid.cs) oluşturulur.**  
2. **Oyuncu bir hücreye (Plot.cs) tıklarsa:**  
   - **Boşsa:** Rastgele bir ekin ekilir (`CropChooser.cs`).  
   - **Doluysa ve tam büyümüşse:** Hasat edilir (`Crop.cs`).  
3. **Ekin, belirli sürelerde büyüme aşamalarını tamamlar.**  
4. **Hasat edilen ekin, hücreyi tekrar kullanılabilir hale getirir.**  

---

### **🏗️ Bina Yerleştirme Sistemi (Görev 2)**
Oyuncuların **grid tabanlı bir sistemde bina inşa etmesini** sağlayan sistem.

| **Bileşen** | **Açıklama** |
|-------------|-------------|
| `BuildingGrid.cs` | Bina yerleştirme için grid hücrelerini oluşturur ve yönetir. |
| `GridCell.cs` | Her bir hücreyi temsil eder, bina ekleme/kaldırma işlemlerini yürütür. |

**🔹 Akış Şeması:**  
1. **BuildingGrid.cs, grid hücrelerini oluşturur ve sahneye yerleştirir.**  
2. **Oyuncu bir hücreye (GridCell.cs) tıklarsa:**  
   - **Boşsa:** Bina eklenir ve hücre inaktif hale gelir.  
   - **Doluysa:** Bina kaldırılır ve hücre tekrar aktif olur.  
3. **Binaların yerleşimi görsel olarak gösterilir (geçerli alan: şeffaf mavi).**  
4. **Oyuncular istedikleri kadar bina ekleyip kaldırabilir.**  

---

## **🚀 Projeyi Çalıştırma**  
### **1️⃣ GitHub Deposu**
```bash
git clone https://github.com/Rhalith/FarmlandCase.git
cd FarmlandCase
```

### **2️⃣ Unity ile Açma**
1. **Unity Hub'ı açın.**  
2. **"Open" butonuna basın** ve proje klasörünü seçin.  
3. **Görev 1 için "CaseOne" sahnesini, Görev 2 için "CaseTwo" sahnesini açın.**  
4. **Oynat butonuna (▶️) basarak oyunu başlatın.**  



## **🖼️ Oyun Görselleri**  
### **Görev 1**

![image](https://github.com/user-attachments/assets/8b9f4e73-6997-4833-8293-c53e4772425a)
![image](https://github.com/user-attachments/assets/5b5a10b2-df8e-42d2-8055-0aa9631abaad)

### **Görev 2**

![image](https://github.com/user-attachments/assets/0ffc81c1-5897-409e-8b20-76c4162ed807)
![image](https://github.com/user-attachments/assets/c1f04b87-bce7-4d10-bdfc-f745b2286cb1)


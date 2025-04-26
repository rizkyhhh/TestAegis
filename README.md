# TestAegis

Sebuah project sederhana ASP.NET Core API untuk **mengunduh file** dalam format **Excel** dan **PDF** menggunakan **ClosedXML** dan **Rotativa.AspNetCore**.

---

## ✨ Fitur

- Download file **Excel** sederhana menggunakan **ClosedXML**.
- Download file **PDF** dari tampilan HTML menggunakan **Rotativa.AspNetCore**.
- Input data karyawan secara **dinamis** menggunakan **POST API**.

---

## 🛠️ Teknologi yang Digunakan

- ASP.NET Core 6 / 7
- Rotativa.AspNetCore (PDF Generator)
- ClosedXML (Excel Generator)
- Swagger (API Documentation)

---

## 🚀 Cara Menjalankan Project

1. **Clone repository**:

```bash
git clone https://github.com/username/TestAegis.git
```

2. **Masuk ke folder project**:

```bash
cd TestAegis
```

3. **Restore dependencies**:

```bash
dotnet restore
```

4. **Build project**:

```bash
dotnet build
```

5. **Jalankan project**:

```bash
dotnet run
```

6. **Akses API** melalui:
   - Swagger UI: `http://localhost:5094/swagger`

---

## 📡 Daftar Endpoint API

| HTTP Method | Endpoint                   | Deskripsi                     |
| ----------- | -------------------------- | ----------------------------- |
| GET         | `/download/download-excel` | Download file Excel sederhana |
| GET         | `/download/download-pdf`   | Download file PDF sederhana   |
| POST        | `/download/add-employee`   | Tambah data karyawan dinamis  |

---

## 🯩 Contoh Body Request untuk Add Employee

```json
{
  "nama": "Andi",
  "umur": 25,
  "jabatan": "Developer",
  "tanggalBergabung": "2022-06-20"
}
```

---

## 📦 Struktur Project

```
TestAegis/
├── Controllers/
│   └── DownloadController.cs
├── Views/
│   └── PdfView.cshtml
├── Rotativa/
│   └── wkhtmltopdf.exe
├── Program.cs
├── TestAegis.csproj
├── README.md
```

---

## 📚 Catatan

- Pastikan folder `Rotativa` tersedia di root project (dibutuhkan oleh Rotativa untuk generate PDF).
- link (https://wkhtmltopdf.org/downloads.html)
- Disarankan menggunakan **Postman** atau **Swagger UI** untuk menguji API.

---

## ✍️ Author

- **Nama**: Rizky Hilman Faturrahman
- **GitHub**: [@rizkyhhh](https://github.com/rizkyhhh)

---


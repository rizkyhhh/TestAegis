using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using Rotativa.AspNetCore;
using System.IO;
using TestAegis.Models; // Tambahkan
using System.Collections.Generic;

namespace TestAegis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DownloadController : Controller
    {
        // Simpan data sementara
        private static List<Employee> employees = new List<Employee>();

        [HttpPost("add-employee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            employees.Add(employee);
            return Ok(new { Message = "Data karyawan berhasil ditambahkan!" });
        }

        [HttpGet("download-excel")]
        public IActionResult DownloadExcel()
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Data Karyawan");

            // Header
            worksheet.Cell(1, 1).Value = "Nama";
            worksheet.Cell(1, 2).Value = "Umur";
            worksheet.Cell(1, 3).Value = "Jabatan";
            worksheet.Cell(1, 4).Value = "Tanggal Bergabung";

            // Isi Data
            for (int i = 0; i < employees.Count; i++)
            {
                var emp = employees[i];
                worksheet.Cell(i + 2, 1).Value = emp.Nama;
                worksheet.Cell(i + 2, 2).Value = emp.Umur;
                worksheet.Cell(i + 2, 3).Value = emp.Jabatan;
                worksheet.Cell(i + 2, 4).Value = emp.TanggalBergabung.ToString("yyyy-MM-dd");
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DataKaryawan.xlsx");
        }

        [HttpGet("download-pdf")]
        public IActionResult DownloadPDF()
        {
            var htmlContent = "<h1 style='text-align:center;'>Data Karyawan</h1>" +
                              "<table style='width:100%; border-collapse: collapse;' border='1'>" +
                              "<thead style='background-color: #f2f2f2;'>" +
                              "<tr><th>Nama</th><th>Umur</th><th>Jabatan</th><th>Tanggal Bergabung</th></tr></thead><tbody>";

            foreach (var emp in employees)
            {
                htmlContent += $"<tr><td>{emp.Nama}</td><td>{emp.Umur}</td><td>{emp.Jabatan}</td><td>{emp.TanggalBergabung:yyyy-MM-dd}</td></tr>";
            }

            htmlContent += "</tbody></table>";

            return new ViewAsPdf("PdfView", new { HtmlContent = htmlContent })
            {
                FileName = "DataKaryawan.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait
            };
        }
    }
}

 
﻿using BellezaTotal_BE.Auditoria;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BLL.Clases
{

    public class PDF_BLL
        {
            public PDF_BLL()
            {
                QuestPDF.Settings.License = LicenseType.Community;
            }

            public void ExportarBitacora(List<Bitacora> listaDatos, string rutaArchivo)
            {
                if (listaDatos == null || listaDatos.Count == 0)
                    throw new ArgumentException("No hay datos para exportar.");

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4.Landscape());
                        page.Margin(1.5f, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(10));

                        page.Header().Column(col =>
                        {
                            col.Item().Text("Bitácora - Belleza Total").SemiBold().FontSize(20).FontColor(Colors.Purple.Medium);
                            col.Item().Text($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(9).FontColor(Colors.Grey.Darken1);
                        });

                        page.Content().PaddingVertical(0.5f, Unit.Centimetre).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(110);  // Fecha y hora
                                columns.ConstantColumn(90);   // Usuario
                                columns.ConstantColumn(70);   // Severidad
                                columns.RelativeColumn();     // Acción / descripción
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Grey.Lighten3).BorderBottom(1).Padding(4).Text("Fecha").Bold();
                                header.Cell().Background(Colors.Grey.Lighten3).BorderBottom(1).Padding(4).Text("Usuario").Bold();
                                header.Cell().Background(Colors.Grey.Lighten3).BorderBottom(1).Padding(4).Text("Severidad").Bold();
                                header.Cell().Background(Colors.Grey.Lighten3).BorderBottom(1).Padding(4).Text("Acción").Bold();
                            });

                            foreach (var item in listaDatos)
                            {
                                string color = ColorSeveridad(item.Severidad.ToString());
                                table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(4)
                                     .Text(item.FechaHora.ToString("dd/MM/yyyy HH:mm"));
                                table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(4)
                                     .Text(item.NombreUsuario ?? "");
                                table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(4)
                                     .Text(item.Severidad.ToString() ?? "").FontColor(color).Bold();
                                table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(4)
                                     .Text(item.Accion ?? "");
                            }
                        });

                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                    });
                })
                .GeneratePdf(rutaArchivo);
            }
            private static string ColorSeveridad(string severidad)
            {
                switch ((severidad ?? "").Trim().ToUpper())
                {
                    case "ERROR": return Colors.Red.Medium;
                    case "WARNING": return Colors.Yellow.Medium;   
                    case "INFO": return Colors.Blue.Medium;
                    default: return Colors.Black;
                }
            }
    }
}



    



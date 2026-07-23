using AutoMapper;
using BeerC0d3.API.Dtos.Comite.Personas;
using BeerC0d3.API.Dtos.Comite.Reportes;
using BeerC0d3.Core.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace BeerC0d3.API.Services.Comite.ReportesPdf
{
    public class ReporteCoopIntegranteService : IGeneratePdfService
    {


        public Document ReporteCooperacionIntegrante(RptTotalCooperacionDto resultMapper, ICollection<PersonaCooperacionDto> listPersonaCooperacion)
        {


            var report = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Header().ShowOnce().Row(row =>
                    {
                        var rutaImagen = Path.Combine("Images/sanmartin.png");
                        byte[] imageData = File.ReadAllBytes(rutaImagen);

                        row.ConstantItem(100).Image(imageData);

                        row.RelativeItem()
                        .AlignCenter()
                        .Width(400)

                        .Column(col =>
                        {
                            col.Item()
                            .AlignCenter()
                            .PaddingBottom(5)
                            .Text(resultMapper.NombrePeriodo)
                            .Bold()
                            .FontSize(16);

                            col.Item().Background("#3748a6")
                            .AlignCenter()
                            .Text("Integrante comité")
                            .FontColor("#fff")
                            .FontSize(13);

                            col.Item()
                            .AlignCenter().Text(resultMapper.NombreIntegrante)
                             .Bold()
                             .FontSize(13);

                            col.Item().Background("#3748a6")
                            .AlignCenter()
                            .Text("Total")
                            .FontColor("#fff")
                            .FontSize(13);

                            col.Item()
                            .AlignCenter()
                            .Text(resultMapper.Monto)
                            .Bold()
                            .FontSize(14);



                        });


                    });

                    page.Content().PaddingVertical(10).Column(col1 =>
                    {


                        col1.Item().LineHorizontal(0.5f);
                        //Tabla
                        col1.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                // columns.ConstantColumn(1);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(3);
                                //columns.RelativeColumn();
                                //columns.RelativeColumn();

                            });

                            tabla.Header(header =>
                            {
                                header.Cell()
                                .Background("#3748a6")
                                .MinWidth(267)
                                .Padding(2).Text("Nombre").FontColor("#fff");

                                header.Cell()

                               .AlignCenter()
                                .Background("#3748a6")
                                 .MinWidth(267)
                                 .AlignCenter()
                               .Padding(2).Text("Monto").FontColor("#fff");


                            });

                            foreach (var item in listPersonaCooperacion)
                            {
                                tabla.Cell()
                             .Padding(2)
                             .Text(item.Nombre)
                             .FontSize(13);

                                tabla.Cell()
                                .AlignCenter()
                                .Padding(2)
                                .Text(item.Monto)
                                .FontSize(13);
                            }

                       
                        });

                        // col1.Item().AlignRight().Text("Total: 1500").FontSize(12);

                    });

                    page.Footer()
                   .AlignRight()
                   .Text(txt =>
                   {
                       txt.Span("Pagina ").FontSize(10);
                       txt.CurrentPageNumber().FontSize(10);
                       txt.Span(" de ").FontSize(10);
                       txt.TotalPages().FontSize(10);
                   });
                });
            });

            return report;

        }
    }
}

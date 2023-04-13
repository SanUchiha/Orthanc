using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Orthanc
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {

        }

        /**
         * Evento que se ejecuta al hacer clic en el botón "Descargar plantilla".
         * Descarga una plantilla de Excel con los campos requeridos para la carga de datos.
         * 
         * @param  sender  Objeto que generó el evento.
         * @param  e       Argumentos del evento.
         */
        private void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un nuevo documento de Excel
                var memoryStream = new MemoryStream();
                using (var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    // Crear la hoja de trabajo
                    var workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();
                    var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new SheetData();
                    worksheetPart.Worksheet = new Worksheet(sheetData);
                    var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                    sheets.Append(sheet);

                    // Crear los encabezados de las columnas con el estilo de fondo gris claro
                    var headerRow = new Row();
                    headerRow.Append(CreateTextCell("NAME"));
                    headerRow.Append(CreateTextCell("LOCATION"));
                    headerRow.Append(CreateTextCell("SIDE"));
                    headerRow.Append(CreateTextCell("POINT 1"));
                    headerRow.Append(CreateTextCell("PV 1"));
                    headerRow.Append(CreateTextCell("PC 1"));
                    headerRow.Append(CreateTextCell("LEADER 1 (SI/NO)"));
                    headerRow.Append(CreateTextCell("POINT 2"));
                    headerRow.Append(CreateTextCell("PV 2"));
                    headerRow.Append(CreateTextCell("PC 2"));
                    headerRow.Append(CreateTextCell("LEADER 2 (SI/NO)"));
                    headerRow.Append(CreateTextCell("POINT 3"));
                    headerRow.Append(CreateTextCell("PV 3"));
                    headerRow.Append(CreateTextCell("PC 3"));
                    headerRow.Append(CreateTextCell("LEADER 3 (SI/NO)"));
                    sheetData.AppendChild(headerRow);

                    // Guardar el archivo
                    worksheetPart.Worksheet.Save();
                    document.Close();
                }

                // Creamos un SaveFileDialog para que el usuario pueda elegir la ubicación y el nombre del archivo
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Save template";
                saveFileDialog.FileName = "Template.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Creamos un objeto FileStream para escribir los datos en el archivo
                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        // Escribimos los datos en el archivo
                        // Suponemos que los datos ya han sido generados y almacenados en la variable memoryStream
                        memoryStream.WriteTo(fileStream);
                    }

                    // Mostramos un mensaje al usuario informando que se ha descargado la plantilla
                    MessageBox.Show("Template save ok.", "template", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to generate template: " + ex.ToString(), "ERROR");
                MessageBox.Show("Please, close template");
            }
        }

        /**
         * Crea y devuelve una celda de texto en formato de Excel con el valor especificado.
         * @param value El valor que se quiere insertar en la celda.
         * @return Una nueva celda de texto en formato de Excel con el valor especificado.
         */
        private Cell CreateTextCell(string value)
        {
            var cell = new Cell();
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue(value);
            return cell;
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Closing Orthanc...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /**
         * Boton que cambia de formulario
         */
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Mostramos el formulario
            FormPairings formPairings = new FormPairings();
            formPairings.Show();
            //Ocultamos el form
            this.Hide();

        }

        private void lblDescription2_Click(object sender, EventArgs e)
        {

        }

        private void lblDescription3_Click(object sender, EventArgs e)
        {

        }
    }
}
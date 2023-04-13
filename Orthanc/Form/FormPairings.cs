using ExcelDataReader;
using System.Data;
using System.Text;
using Orthanc.Class;
using ClosedXML.Excel;


namespace Orthanc
{
    public partial class FormPairings : Form
    {
        //Flag para controlar que hay opciones marcadas.
        bool flagRounds = false;
        string roundChecked;
        bool flagTypeTournament = false;
        string typeTournament;
        bool flagPairings = false;
        bool flagClasification = false;
        bool flagResultFinal = false;
        bool flagRound1 = false;

        public FormPairings()
        {
            InitializeComponent();
        }

        //Back formMain
        private void btnBack_Click(object sender, EventArgs e)
        {
            //Ocultamos el form
            this.Hide();
            //Back al main
            FormStart formStart = new();
            formStart.Show();
        }

        private void FormPairings_Load(object sender, EventArgs e)
        {

        }

        private void FormPairings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Ocultamos el form
            this.Close();
            //Back al main
            FormStart formStart = new();
            formStart.Show();
        }

        private void listTournamentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listTournamentType.Items.Count; i++)
            {
                if (i != listTournamentType.SelectedIndex)
                {
                    listTournamentType.SetItemChecked(i, false);
                    flagTypeTournament = true;
                }
            }

            flagTypeTournament = (listTournamentType.CheckedItems.Count == 1);
            btnGeneratePairings.Enabled = flagTypeTournament && flagRounds;
        }

        private void listRounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listRounds.Items.Count; i++)
            {
                if (i != listRounds.SelectedIndex)
                {
                    listRounds.SetItemChecked(i, false);
                    flagRounds = true;
                }
            }
            flagRounds = (listRounds.CheckedItems.Count == 1);
            btnGeneratePairings.Enabled = flagTypeTournament && flagRounds;
        }

        /**
         * Boton que activa todo el proceso para generar los pairings
         * 1. Lee excel con los datos.
         * 2. Genera los pairings
         * 3. Crea el excel con los pairings
         * 4. Genera la clasificacion
         * 5. Crea un excel con la clasificacion.
         */
        private void btnGeneratePairings_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> typesTournament = new List<string>();
                foreach (object item in listTournamentType.CheckedItems)
                {
                    typesTournament.Add(item.ToString());
                }
                this.typeTournament = typesTournament[0];
                if (this.typeTournament != "Good vs Evil")
                {
                    List<Player> listPlayersUpdate = new();
                    List<Pairing> listPairingsUpdate = new();
                    List<Clasification> listClasification = new();
                    // 1.Lee excel con los datos.
                    listPlayersUpdate = ReadingExcel();

                    // 2.Genera los pairings
                    if (listPlayersUpdate.Count != 0)
                    {
                        listPairingsUpdate = GeneratePairings(listPlayersUpdate, listClasification);
                    }
                    else
                    {
                        if (listPairingsUpdate.Count == 0)
                        {
                            MessageBox.Show("Excel not players", "ERROR");
                        }
                        else
                        {
                            MessageBox.Show("Error read excel", "ERROR");
                        }
                    }

                    // 3.Crea el excel con los pairings
                    if (listPairingsUpdate.Count != 0)
                    {
                        flagClasification = false;
                        flagPairings = true;
                        flagResultFinal = false;
                        GenerateExcelPairings(listPairingsUpdate);
                    }

                    // 4.Genera la clasificacion
                    if (listPairingsUpdate.Count != 0 && !flagRound1)
                    {
                        flagClasification = true;
                        flagPairings = false;
                        flagResultFinal = false;
                        generateClasification(listClasification);

                        // 5.Crea un excel con la clasificacion.
                    }
                    flagRound1 = false;

                }
                else
                {
                    MessageBox.Show("Option disabled for now", "INFORMATION");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        /**
         * Genera la clasificacion
         */
        private void generateClasification(List<Clasification> listClasification)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Clasification");

            // Encabezado de la tabla
            worksheet.Cell(1, 1).Value = "Name".ToUpper();
            worksheet.Cell(1, 2).Value = "Location".ToUpper();
            worksheet.Cell(1, 3).Value = "Side".ToUpper();
            worksheet.Cell(1, 4).Value = "Points".ToUpper();
            worksheet.Cell(1, 5).Value = "Diff_Points".ToUpper();
            worksheet.Cell(1, 6).Value = "PV_Totals".ToUpper();
            worksheet.Cell(1, 7).Value = "Leaders_Deads".ToUpper();

            // Establecer color de fondo para el encabezado
            //worksheet.Row(1).Style.Fill.BackgroundColor = XLColor.AliceBlue;

            //Establecer color de fonde para los datos
            var dataRows = worksheet.Range(listClasification.Count + 1, 1, worksheet.LastRowUsed().RowNumber(), worksheet.LastColumnUsed().ColumnNumber());
            dataRows.Style.Fill.BackgroundColor = XLColor.FromColor(Color.LightGray);
            var dataHeard = worksheet.Range(1, 1, worksheet.LastRowUsed().RowNumber(), worksheet.LastColumnUsed().ColumnNumber());
            dataHeard.Style.Fill.BackgroundColor = XLColor.FromColor(Color.SkyBlue);

            // Contenido de la tabla
            for (int i = 0; i < listClasification.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = listClasification[i].Name.ToUpper();
                worksheet.Cell(i + 2, 2).Value = listClasification[i].location.ToUpper();
                worksheet.Cell(i + 2, 3).Value = listClasification[i].side.ToUpper();
                worksheet.Cell(i + 2, 4).Value = listClasification[i].points;
                worksheet.Cell(i + 2, 5).Value = listClasification[i].diffPoints;
                worksheet.Cell(i + 2, 6).Value = listClasification[i].pointVictoryTotals;
                worksheet.Cell(i + 2, 7).Value = listClasification[i].leadersDeadTotals;
            }

            SaveExcel(workbook);
        }

        /**
         * Genera Excel pairings
         */
        private void GenerateExcelPairings(List<Pairing> listPairingsUpdate)
        {

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Pairings");

            // Encabezado de la tabla
            worksheet.Cell(1, 1).Value = "Table".ToUpper();
            worksheet.Cell(1, 2).Value = "Player One".ToUpper();
            worksheet.Cell(1, 3).Value = "Player Two".ToUpper();

            //Establecer color de fonde para los datos
            var dataRows = worksheet.Range(listPairingsUpdate.Count + 1, 1, worksheet.LastRowUsed().RowNumber(), worksheet.LastColumnUsed().ColumnNumber());
            dataRows.Style.Fill.BackgroundColor = XLColor.FromColor(Color.LightGray);
            var dataHeard = worksheet.Range(1, 1, worksheet.LastRowUsed().RowNumber(), worksheet.LastColumnUsed().ColumnNumber());
            dataHeard.Style.Fill.BackgroundColor = XLColor.FromColor(Color.SkyBlue);

            // Contenido de la tabla
            for (int i = 0; i < listPairingsUpdate.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = listPairingsUpdate[i].Table;
                worksheet.Cell(i + 2, 2).Value = listPairingsUpdate[i].PlayerOne;
                worksheet.Cell(i + 2, 3).Value = listPairingsUpdate[i].PlayerTwo;
            }

            SaveExcel(workbook);

        }

        /**
         * Guarda excel en ubicacion elegida por usuario.
         */
        private void SaveExcel(XLWorkbook workbook)
        {
            if (flagPairings)
            {
                MessageBox.Show("Choose the directory to save the pairings", "INFORMATION");

            }
            else if (flagClasification)
            {
                MessageBox.Show("Choose the directory to save the clasification", "INFORMATION");
            }
            else if (flagResultFinal)
            {
                MessageBox.Show("Choose the directory to save the final results", "INFORMATION");
            }

            // Crear un cuadro de diálogo de "Guardar como"
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save to...";
            saveFileDialog.FileName = "Pairings";
            if (flagPairings)
            {
                saveFileDialog.FileName = "Pairings";
            }
            else if (flagClasification)
            {
                saveFileDialog.FileName = "Clasification";
            }
            else if (flagResultFinal)
            {
                saveFileDialog.FileName = "Final_Results";
            }
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Mostrar el cuadro de diálogo y obtener el resultado
            DialogResult result = saveFileDialog.ShowDialog();

            // Si el usuario ha seleccionado una ubicación y ha hecho clic en "Guardar"
            if (result == DialogResult.OK)
            {
                // Guardar el archivo en la ubicación seleccionada
                string filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
                if (flagPairings)
                {
                    MessageBox.Show("Pairings file saved successfully at... " + filePath, "INFORMATION");
                }
                else if (flagClasification)
                {
                    MessageBox.Show("Clasification file saved successfully at... " + filePath, "INFORMATION");
                }
                else if (flagResultFinal)
                {
                    MessageBox.Show("FinalResults file saved successfully at... " + filePath, "INFORMATION");
                }
            }
        }

        /**
         * Genera pairings
         */
        private List<Pairing> GeneratePairings(List<Player> listPlayerUpdate, List<Clasification> listClasification)
        {
            List<Pairing> listPairings = new();
            //Seleccionamos las opciones marcadas
            List<string> rounds = new List<string>();
            foreach (object item in listRounds.CheckedItems)
            {
                rounds.Add(item.ToString());
            }
            this.roundChecked = rounds[0];
            List<string> typesTournament = new List<string>();
            foreach (object item in listTournamentType.CheckedItems)
            {
                typesTournament.Add(item.ToString());
            }
            this.typeTournament = typesTournament[0];
            int countPlayers = listPlayerUpdate.Count;
            List<Tuple<Player, Player>> pairings = new List<Tuple<Player, Player>>();
            int tableNumber = 1;

            //Mapeo
            switch (this.typeTournament)
            {
                case "All vs All":
                    switch (this.roundChecked)
                    {
                        case "Round 1":

                            Random rand = new();
                            flagRound1 = true;

                            bool flagBye = false;
                            // Si hay una cantidad impar de jugadores, asignar un bye a un jugador aleatorio
                            if (listPlayerUpdate.Count % 2 != 0)
                            {
                                flagBye = true;
                                // Seleccionar aleatoriamente un jugador de la lista
                                int byeIndex = rand.Next(listPlayerUpdate.Count);
                                Player byePlayer = listPlayerUpdate[byeIndex];
                                double number = listPlayerUpdate.Count / 2;
                                number = (int)Math.Floor(number) + 1;
                                // Eliminar al jugador seleccionado de la lista
                                listPlayerUpdate.RemoveAt(byeIndex);
                                // Agregar un objeto de pareja de jugadores a la lista de emparejamientos, que contiene el nombre del jugador seleccionado y la cadena "BYE"
                                Pairing pairing = new();
                                pairing.Table = (int)number;
                                pairing.PlayerOne = byePlayer.Name.ToUpper();
                                pairing.PlayerTwo = "BYE";
                                listPairings.Add(pairing);
                            }

                            int countTables = 1;
                            // Emparejar los jugadores restantes en la lista
                            while (listPlayerUpdate.Count > 1)
                            {
                                // Seleccionar aleatoriamente dos jugadores diferentes de la lista
                                int index1 = rand.Next(listPlayerUpdate.Count);
                                int index2 = rand.Next(listPlayerUpdate.Count - 1);
                                if (index2 >= index1) index2++;
                                Player player1 = listPlayerUpdate[index1];
                                Player player2 = listPlayerUpdate[index2];
                                // Eliminar a los jugadores seleccionados de la lista
                                listPlayerUpdate.Remove(player1);
                                listPlayerUpdate.Remove(player2);
                                // Agregar un objeto de pareja de jugadores a la lista de emparejamientos, que contiene los nombres de los jugadores emparejados
                                Pairing pairing = new();
                                pairing.Table = countTables;
                                pairing.PlayerOne = player1.Name.ToUpper();
                                pairing.PlayerTwo = player2.Name.ToUpper();
                                listPairings.Add(pairing);
                                countTables++;
                            }

                            if (flagBye)
                            {
                                Pairing pairingBye = listPairings[0];
                                listPairings.RemoveAt(0);
                                listPairings.Add(pairingBye);
                            }

                            break;
                        case "Round 2":
                            //Ordenar jugadores
                            listPlayerUpdate = listPlayerUpdate.
                                OrderByDescending(p => p.Point1)  // prioridad 1: más puntos
                                .ThenByDescending(p => p.PV1 - p.PC1)  // prioridad 2: mayor diferencia entre PV1 y PC1
                                .ThenByDescending(p => p.PV1)         // prioridad 3: más PV1
                                .ThenByDescending(p => p.Leader1)  // prioridad 4: más líderes "Si"
                                .ToList();

                            //Mapeo de la clasification
                            foreach (Player player in listPlayerUpdate)
                            {
                                Clasification clasification = new Clasification();
                                clasification.Name = player.Name;
                                clasification.location = player.Location;
                                clasification.side = player.Side;
                                clasification.points = player.Point1;
                                clasification.diffPoints = player.PV1 - player.PC1;
                                clasification.pointVictoryTotals = player.PV1;
                                clasification.leadersDeadTotals = player.Leader1;
                                listClasification.Add(clasification);
                            }

                            //Generar pairings
                            for (int i = 0; i < listPlayerUpdate.Count; i += 2)
                            {
                                if (i + 1 < listPlayerUpdate.Count)
                                {
                                    pairings.Add(new Tuple<Player, Player>(listPlayerUpdate[i], listPlayerUpdate[i + 1]));
                                }
                                else
                                {
                                    // Si hay un número impar de jugadores, asignar el último jugador como libre
                                    Player byePlayer = new();
                                    byePlayer.Name = "BYE";
                                    pairings.Add(new Tuple<Player, Player>(listPlayerUpdate[i], byePlayer));
                                }
                            }

                            // Generar la lista
                            foreach (var pairing in pairings)
                            {
                                Pairing pairing2 = new();
                                pairing2.Table = tableNumber;
                                pairing2.PlayerOne = pairing.Item1.Name.ToUpper();
                                pairing2.PlayerTwo = pairing.Item2.Name.ToUpper();
                                listPairings.Add(pairing2);
                                tableNumber++;
                            }

                            break;
                        case "Round 3":
                            //Ordenar jugadores
                            listPlayerUpdate = listPlayerUpdate.
                                OrderByDescending(p => p.Point1 + p.Point2)  // prioridad 1: más puntos
                                .ThenByDescending(p => (p.PV1 - p.PC1) + (p.PV2 - p.PC2))  // prioridad 2: mayor diferencia entre PV1 y PC1
                                .ThenByDescending(p => p.PV1 + p.PV2)         // prioridad 3: más PV1
                                .ThenByDescending(p => p.Leader1 + p.Leader2)  // prioridad 4: más líderes "Si"
                                .ToList();

                            //Mapeo de la clasification
                            foreach (Player player in listPlayerUpdate)
                            {
                                Clasification clasification = new Clasification();
                                clasification.Name = player.Name;
                                clasification.location = player.Location;
                                clasification.side = player.Side;
                                clasification.points = player.Point1 + player.Point2;
                                clasification.diffPoints = (player.PV1 - player.PC1) + (player.PV2 - player.PC2);
                                clasification.pointVictoryTotals = player.PV1 + player.PV2;
                                clasification.leadersDeadTotals = player.Leader1 + player.Leader2;
                                listClasification.Add(clasification);
                            }

                            //Generar pairings
                            for (int i = 0; i < listPlayerUpdate.Count; i += 2)
                            {
                                if (i + 1 < listPlayerUpdate.Count)
                                {
                                    pairings.Add(new Tuple<Player, Player>(listPlayerUpdate[i], listPlayerUpdate[i + 1]));
                                }
                                else
                                {
                                    // Si hay un número impar de jugadores, asignar el último jugador como libre
                                    Player byePlayer = new();
                                    byePlayer.Name = "BYE";
                                    pairings.Add(new Tuple<Player, Player>(listPlayerUpdate[i], byePlayer));
                                }
                            }

                            // Generar la lista
                            foreach (var pairing in pairings)
                            {
                                Pairing pairing2 = new();
                                pairing2.Table = tableNumber;
                                pairing2.PlayerOne = pairing.Item1.Name.ToUpper();
                                pairing2.PlayerTwo = pairing.Item2.Name.ToUpper();
                                listPairings.Add(pairing2);
                                tableNumber++;
                            }
                            break;
                    }//fin switch rounds
                    break;
                case "Good vs Evil":
                    switch (this.roundChecked)
                    {
                        case "Round 1":
                            break;
                        case "Round 2":
                            break;
                        case "Round 3":
                            break;
                    }
                    MessageBox.Show("Option disabled at the moment.", "INFORMATION");
                    break;
            }//fin switch type
            return listPairings;
        }

        /**
         * Leer el excel del template
         */
        private List<Player> ReadingExcel()
        {
            List<Player> listPlayer = new();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            MessageBox.Show("Choose the template with the data", "INFORMATION");

            OpenFileDialog openFileDialog = new()
            {
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = "Open Template",
                FileName = "Template",
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string path = openFileDialog.FileName;

                using var stream = File.Open(path, FileMode.Open, FileAccess.Read);
                using var reader = ExcelReaderFactory.CreateReader(stream);
                var result = reader.AsDataSet();

                // Acceder a la tabla de datos
                DataTable table = result.Tables[0];

                // Recorrer las filas y columnas de la tabla

                foreach (DataRow row in table.Rows.Cast<DataRow>().Skip(1))
                {


                    string name = row[0] != DBNull.Value ? row[0].ToString() : null;
                    string location = row[1] != DBNull.Value ? row[1].ToString() : null;
                    string side = row[2] != DBNull.Value ? row[2].ToString() : null;
                    int? point1 = row[3] != DBNull.Value ? Convert.ToInt32(row[3]) : 0;
                    int? pv1 = row[4] != DBNull.Value ? Convert.ToInt32(row[4]) : 0;
                    int? pc1 = row[5] != DBNull.Value ? Convert.ToInt32(row[5]) : 0;
                    string l1 = row[6] != DBNull.Value ? row[6].ToString() : null;
                    int leader1;
                    if (l1 != null && l1.ToUpper() == "SI")
                    {
                        leader1 = 1;
                    }
                    else if (l1 != null && l1.ToUpper() == "NO")
                    {
                        leader1 = 0;
                    }
                    else
                    {
                        leader1 = 0;
                    }

                    int? point2 = row[7] != DBNull.Value ? Convert.ToInt32(row[7]) : 0;
                    int? pv2 = row[8] != DBNull.Value ? Convert.ToInt32(row[8]) : 0;
                    int? pc2 = row[9] != DBNull.Value ? Convert.ToInt32(row[9]) : 0;
                    string l2 = row[10] != DBNull.Value ? row[10].ToString() : null;
                    int leader2;
                    if (l2 != null && l2.ToUpper() == "SI")
                    {
                        leader2 = 1;
                    }
                    else if (l2 != null && l2.ToUpper() == "NO")
                    {
                        leader2 = 0;
                    }
                    else
                    {
                        leader2 = 0;
                    }

                    int? point3 = row[11] != DBNull.Value ? Convert.ToInt32(row[11]) : 0;
                    int? pv3 = row[12] != DBNull.Value ? Convert.ToInt32(row[12]) : 0;
                    int? pc3 = row[13] != DBNull.Value ? Convert.ToInt32(row[13]) : 0;
                    string l3 = row[14] != DBNull.Value ? row[14].ToString() : null;
                    int leader3;
                    if (l3 != null && l3.ToUpper() == "SI")
                    {
                        leader3 = 1;
                    }
                    else if (l3 != null && l3.ToUpper() == "NO")
                    {
                        leader3 = 0;
                    }
                    else
                    {
                        leader3 = 0;
                    }

                    Player player = new();
                    player.Name = name;
                    player.Location = location;
                    player.Side = side;
                    player.Point1 = (int)point1;
                    player.Point2 = (int)point2;
                    player.Point3 = (int)point3;
                    player.PV1 = (int)pv1;
                    player.PV2 = (int)pv2;
                    player.PV3 = (int)pv3;
                    player.PC1 = (int)pc1;
                    player.PC2 = (int)pc2;
                    player.PC3 = (int)pc3;
                    player.Leader1 = leader1;
                    player.Leader2 = leader2;
                    player.Leader3 = leader3;

                    listPlayer.Add(player);
                }
            }
            return listPlayer;
        }

        /**
         * Boton para generar los resultados finales en excel
         */
        private void btnGenerateFInalResults_Click(object sender, EventArgs e)
        {
            try
            {
                List<Player> listPlayers = new();
                List<Clasification> listClasification = new();
                flagResultFinal = true;

                //1. Leer el template
                listPlayers = ReadingExcel();

                //2. Ordenamos a los jugadores
                listClasification = playerOrder(listPlayers, listClasification);

                //2. Generar la clasificacion Final
                generateClasification(listClasification);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        /**
         * Ordena los jugadores en base a unas condiciones.
         */
        private List<Clasification> playerOrder(List<Player> listPlayers, List<Clasification> listClasification)
        {
            //Ordenar jugadores
            listPlayers = listPlayers.
                OrderByDescending(p => p.Point1 + p.Point2 + p.Point3)  // prioridad 1: más puntos
                .ThenByDescending(p => (p.PV1 - p.PC1) + (p.PV2 - p.PC2) + (p.PV3 - p.PC3))  // prioridad 2: mayor diferencia entre PV1 y PC1
                .ThenByDescending(p => p.PV1 + p.PV2 + p.PV3)         // prioridad 3: más PV1
                .ThenByDescending(p => p.Leader1 + p.Leader2 + p.Leader3)  // prioridad 4: más líderes "Si"
                .ToList();

            //Mapeo de la clasification
            foreach (Player player in listPlayers)
            {
                Clasification clasification = new Clasification();
                clasification.Name = player.Name;
                clasification.location = player.Location;
                clasification.side = player.Side;
                clasification.points = player.Point1 + player.Point2 + player.Point3;
                clasification.diffPoints = (player.PV1 - player.PC1) + (player.PV2 - player.PC2) + (player.PV3 - player.PC3);
                clasification.pointVictoryTotals = player.PV1 + player.PV2 + player.PV3;
                clasification.leadersDeadTotals = player.Leader1 + player.Leader2 + player.Leader3;
                listClasification.Add(clasification);
            }

            return listClasification;
        }
    }
}

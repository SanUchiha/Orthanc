namespace Orthanc
{
    partial class FormPairings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBack = new Button();
            groupBox1 = new GroupBox();
            listTournamentType = new CheckedListBox();
            panel1 = new Panel();
            btnGeneratePairings = new Button();
            groupBox2 = new GroupBox();
            listRounds = new CheckedListBox();
            label1 = new Label();
            btnGenerateFinalResults = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Black;
            btnBack.FlatAppearance.BorderColor = Color.DarkViolet;
            btnBack.FlatAppearance.BorderSize = 5;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.Location = new Point(472, 247);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(122, 58);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listTournamentType);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = Color.DarkViolet;
            groupBox1.Location = new Point(16, 39);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(198, 69);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tournament Type";
            // 
            // listTournamentType
            // 
            listTournamentType.BackColor = Color.Black;
            listTournamentType.BorderStyle = BorderStyle.None;
            listTournamentType.CheckOnClick = true;
            listTournamentType.ForeColor = Color.Lime;
            listTournamentType.FormattingEnabled = true;
            listTournamentType.Items.AddRange(new object[] { "All vs All", "Good vs Evil" });
            listTournamentType.Location = new Point(16, 20);
            listTournamentType.Margin = new Padding(3, 2, 3, 2);
            listTournamentType.Name = "listTournamentType";
            listTournamentType.Size = new Size(164, 36);
            listTournamentType.TabIndex = 0;
            listTournamentType.SelectedIndexChanged += listTournamentType_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnGeneratePairings);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(10, 9);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(237, 296);
            panel1.TabIndex = 4;
            // 
            // btnGeneratePairings
            // 
            btnGeneratePairings.Enabled = false;
            btnGeneratePairings.FlatAppearance.BorderColor = Color.DarkViolet;
            btnGeneratePairings.FlatAppearance.BorderSize = 5;
            btnGeneratePairings.FlatStyle = FlatStyle.Flat;
            btnGeneratePairings.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnGeneratePairings.ForeColor = Color.Lime;
            btnGeneratePairings.Location = new Point(16, 214);
            btnGeneratePairings.Margin = new Padding(3, 2, 3, 2);
            btnGeneratePairings.Name = "btnGeneratePairings";
            btnGeneratePairings.Size = new Size(198, 72);
            btnGeneratePairings.TabIndex = 5;
            btnGeneratePairings.Text = "Generate Pairings";
            btnGeneratePairings.UseVisualStyleBackColor = true;
            btnGeneratePairings.Click += btnGeneratePairings_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listRounds);
            groupBox2.ForeColor = Color.DarkViolet;
            groupBox2.Location = new Point(16, 121);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(198, 89);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Rounds";
            // 
            // listRounds
            // 
            listRounds.BackColor = Color.Black;
            listRounds.BorderStyle = BorderStyle.None;
            listRounds.CheckOnClick = true;
            listRounds.ForeColor = Color.Lime;
            listRounds.FormattingEnabled = true;
            listRounds.Items.AddRange(new object[] { "Round 1", "Round 2", "Round 3" });
            listRounds.Location = new Point(16, 22);
            listRounds.Margin = new Padding(3, 2, 3, 2);
            listRounds.Name = "listRounds";
            listRounds.Size = new Size(164, 54);
            listRounds.TabIndex = 0;
            listRounds.SelectedIndexChanged += listRounds_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(72, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 28);
            label1.TabIndex = 4;
            label1.Text = "Options";
            // 
            // btnGenerateFinalResults
            // 
            btnGenerateFinalResults.FlatAppearance.BorderColor = Color.DarkViolet;
            btnGenerateFinalResults.FlatAppearance.BorderSize = 5;
            btnGenerateFinalResults.FlatStyle = FlatStyle.Flat;
            btnGenerateFinalResults.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerateFinalResults.Location = new Point(266, 223);
            btnGenerateFinalResults.Name = "btnGenerateFinalResults";
            btnGenerateFinalResults.Size = new Size(187, 81);
            btnGenerateFinalResults.TabIndex = 5;
            btnGenerateFinalResults.Text = "Generate Final Results";
            btnGenerateFinalResults.UseVisualStyleBackColor = true;
            btnGenerateFinalResults.Click += btnGenerateFInalResults_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = Color.Lime;
            textBox1.Location = new Point(253, 37);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(341, 57);
            textBox1.TabIndex = 9;
            textBox1.Text = "1. Select type of tournament and round\r\n2. Click on \"Generate Pairings\".";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Black;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.ForeColor = Color.Lime;
            textBox2.Location = new Point(266, 114);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(306, 79);
            textBox2.TabIndex = 10;
            textBox2.Text = "When the template is completely filled, click on the \"Generate final results\" button.";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // FormPairings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            CancelButton = btnBack;
            ClientSize = new Size(606, 316);
            ControlBox = false;
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnGenerateFinalResults);
            Controls.Add(panel1);
            Controls.Add(btnBack);
            ForeColor = Color.Lime;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPairings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pairings";
            Load += FormPairings_Load;
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private GroupBox groupBox1;
        private CheckedListBox listTournamentType;
        private Panel panel1;
        private Button btnGeneratePairings;
        private GroupBox groupBox2;
        private CheckedListBox listRounds;
        private Label label1;
        private Button btnGenerateFinalResults;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
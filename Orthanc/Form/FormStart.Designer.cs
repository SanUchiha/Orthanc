namespace Orthanc
{
    partial class FormStart
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnDownloadTemplate = new Button();
            btnCloseApp = new Button();
            btnStart = new Button();
            tTipClose = new ToolTip(components);
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // btnDownloadTemplate
            // 
            btnDownloadTemplate.BackColor = Color.Black;
            btnDownloadTemplate.FlatAppearance.BorderColor = Color.DarkViolet;
            btnDownloadTemplate.FlatAppearance.BorderSize = 5;
            btnDownloadTemplate.FlatStyle = FlatStyle.Flat;
            btnDownloadTemplate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDownloadTemplate.ForeColor = Color.Lime;
            btnDownloadTemplate.Location = new Point(14, 281);
            btnDownloadTemplate.Margin = new Padding(3, 4, 3, 4);
            btnDownloadTemplate.Name = "btnDownloadTemplate";
            btnDownloadTemplate.Size = new Size(114, 107);
            btnDownloadTemplate.TabIndex = 0;
            btnDownloadTemplate.Text = "Donwload template";
            btnDownloadTemplate.UseVisualStyleBackColor = false;
            btnDownloadTemplate.Click += btnDownloadTemplate_Click;
            // 
            // btnCloseApp
            // 
            btnCloseApp.BackColor = Color.Black;
            btnCloseApp.FlatAppearance.BorderColor = Color.DarkViolet;
            btnCloseApp.FlatAppearance.BorderSize = 5;
            btnCloseApp.FlatStyle = FlatStyle.Flat;
            btnCloseApp.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCloseApp.ForeColor = Color.Lime;
            btnCloseApp.Location = new Point(315, 281);
            btnCloseApp.Margin = new Padding(3, 4, 3, 4);
            btnCloseApp.Name = "btnCloseApp";
            btnCloseApp.Size = new Size(114, 107);
            btnCloseApp.TabIndex = 1;
            btnCloseApp.Text = "Close Orthanc";
            tTipClose.SetToolTip(btnCloseApp, "Close App");
            btnCloseApp.UseVisualStyleBackColor = false;
            btnCloseApp.Click += btnCloseApp_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Black;
            btnStart.FlatAppearance.BorderColor = Color.DarkViolet;
            btnStart.FlatAppearance.BorderSize = 5;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.Lime;
            btnStart.Location = new Point(138, 255);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(171, 133);
            btnStart.TabIndex = 2;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = Color.Lime;
            textBox1.Location = new Point(14, 16);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(416, 155);
            textBox1.TabIndex = 8;
            textBox1.Text = "Tournament management software that streamlines organization and tracking of tournaments. Creates custom pairings and manages results, offering information in generated files.";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Black;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.ForeColor = Color.Lime;
            textBox2.Location = new Point(15, 179);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(416, 69);
            textBox2.TabIndex = 9;
            textBox2.Text = "1. Press \"Download template\" to download the template.\r\n2. Click on the \"START\" button.\r\n";
            // 
            // FormStart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(443, 405);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnStart);
            Controls.Add(btnCloseApp);
            Controls.Add(btnDownloadTemplate);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormStart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Orthanc";
            Load += FormStart_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDownloadTemplate;
        private Button btnCloseApp;
        private Button btnStart;
        private ToolTip tTipClose;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
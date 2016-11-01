namespace msb.Backup
{
  partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxBackupTo = new System.Windows.Forms.TextBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabDirectories = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxAddDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveFullDirs = new System.Windows.Forms.Button();
            this.btnAddFullDirs = new System.Windows.Forms.Button();
            this.lbDirs = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbLöschen = new System.Windows.Forms.CheckBox();
            this.driveCombo1 = new Bienz.UI.DriveCombo();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.fb1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDeleteBackupSet = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxAlternative = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabDirectories.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(304, 352);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(386, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabDirectories);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(6, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(456, 330);
            this.tabControl1.TabIndex = 16;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.button4);
            this.tabGeneral.Controls.Add(this.label12);
            this.tabGeneral.Controls.Add(this.tbxAlternative);
            this.tabGeneral.Controls.Add(this.checkBox4);
            this.tabGeneral.Controls.Add(this.checkBox13);
            this.tabGeneral.Controls.Add(this.button1);
            this.tabGeneral.Controls.Add(this.label4);
            this.tabGeneral.Controls.Add(this.tbxBackupTo);
            this.tabGeneral.Controls.Add(this.tbxDescription);
            this.tabGeneral.Controls.Add(this.tbxName);
            this.tabGeneral.Controls.Add(this.label5);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(448, 304);
            this.tabGeneral.TabIndex = 2;
            this.tabGeneral.Text = "Einstellungen";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(283, 46);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(109, 17);
            this.checkBox4.TabIndex = 25;
            this.checkBox4.Text = "als schattenkopie";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(283, 20);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(93, 17);
            this.checkBox13.TabIndex = 24;
            this.checkBox13.Text = "als Zip-Achive";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Sichern nach:";
            // 
            // tbxBackupTo
            // 
            this.tbxBackupTo.Location = new System.Drawing.Point(11, 210);
            this.tbxBackupTo.Name = "tbxBackupTo";
            this.tbxBackupTo.Size = new System.Drawing.Size(379, 20);
            this.tbxBackupTo.TabIndex = 21;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(11, 78);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(424, 95);
            this.tbxDescription.TabIndex = 5;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(11, 31);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(251, 20);
            this.tbxName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Beschreibung:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jobname:";
            // 
            // tabDirectories
            // 
            this.tabDirectories.Controls.Add(this.button2);
            this.tabDirectories.Controls.Add(this.label3);
            this.tabDirectories.Controls.Add(this.tbxAddDirectory);
            this.tabDirectories.Controls.Add(this.label1);
            this.tabDirectories.Controls.Add(this.btnRemoveFullDirs);
            this.tabDirectories.Controls.Add(this.btnAddFullDirs);
            this.tabDirectories.Controls.Add(this.lbDirs);
            this.tabDirectories.Location = new System.Drawing.Point(4, 22);
            this.tabDirectories.Name = "tabDirectories";
            this.tabDirectories.Size = new System.Drawing.Size(448, 304);
            this.tabDirectories.TabIndex = 1;
            this.tabDirectories.Text = "Verzeichnisse";
            this.tabDirectories.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(376, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 21);
            this.button2.TabIndex = 20;
            this.button2.Text = "...";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 14);
            this.label3.TabIndex = 19;
            this.label3.Text = "zu sichernde Verzeichnisse:";
            // 
            // tbxAddDirectory
            // 
            this.tbxAddDirectory.Location = new System.Drawing.Point(8, 26);
            this.tbxAddDirectory.Name = "tbxAddDirectory";
            this.tbxAddDirectory.Size = new System.Drawing.Size(362, 20);
            this.tbxAddDirectory.TabIndex = 18;
            this.tbxAddDirectory.TextChanged += new System.EventHandler(this.tbxAddDirectory_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "zu sichernde Verzeichnisse:";
            // 
            // btnRemoveFullDirs
            // 
            this.btnRemoveFullDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFullDirs.Location = new System.Drawing.Point(376, 272);
            this.btnRemoveFullDirs.Name = "btnRemoveFullDirs";
            this.btnRemoveFullDirs.Size = new System.Drawing.Size(64, 23);
            this.btnRemoveFullDirs.TabIndex = 16;
            this.btnRemoveFullDirs.Text = "---";
            this.btnRemoveFullDirs.Click += new System.EventHandler(this.btnRemoveDirs_Click);
            // 
            // btnAddFullDirs
            // 
            this.btnAddFullDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFullDirs.Enabled = false;
            this.btnAddFullDirs.Location = new System.Drawing.Point(403, 25);
            this.btnAddFullDirs.Name = "btnAddFullDirs";
            this.btnAddFullDirs.Size = new System.Drawing.Size(37, 23);
            this.btnAddFullDirs.TabIndex = 15;
            this.btnAddFullDirs.Text = "+++";
            this.btnAddFullDirs.Click += new System.EventHandler(this.btnAddDirs_Click);
            // 
            // lbDirs
            // 
            this.lbDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDirs.HorizontalScrollbar = true;
            this.lbDirs.Location = new System.Drawing.Point(8, 80);
            this.lbDirs.Name = "lbDirs";
            this.lbDirs.Size = new System.Drawing.Size(432, 186);
            this.lbDirs.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbLöschen);
            this.tabPage1.Controls.Add(this.driveCombo1);
            this.tabPage1.Controls.Add(this.maskedTextBox1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.checkBox5);
            this.tabPage1.Controls.Add(this.checkBox3);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(448, 304);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Extras";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbLöschen
            // 
            this.cbLöschen.AutoSize = true;
            this.cbLöschen.Location = new System.Drawing.Point(152, 60);
            this.cbLöschen.Name = "cbLöschen";
            this.cbLöschen.Size = new System.Drawing.Size(79, 17);
            this.cbLöschen.TabIndex = 17;
            this.cbLöschen.Text = "mit löschen";
            this.cbLöschen.UseVisualStyleBackColor = true;
            this.cbLöschen.CheckedChanged += new System.EventHandler(this.cbLöschen_CheckedChanged);
            // 
            // driveCombo1
            // 
            this.driveCombo1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.driveCombo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveCombo1.FormattingEnabled = true;
            this.driveCombo1.Location = new System.Drawing.Point(156, 31);
            this.driveCombo1.Name = "driveCombo1";
            this.driveCombo1.Size = new System.Drawing.Size(193, 21);
            this.driveCombo1.TabIndex = 16;
            this.driveCombo1.SelectedIndexChanged += new System.EventHandler(this.driveCombo1_SelectedIndexChanged);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(129, 130);
            this.maskedTextBox1.Mask = "90:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBox1.TabIndex = 15;
            this.maskedTextBox1.Text = "1800";
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(347, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Scheduler";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(6, 180);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(436, 121);
            this.tabControl2.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox12);
            this.tabPage2.Controls.Add(this.checkBox9);
            this.tabPage2.Controls.Add(this.checkBox10);
            this.tabPage2.Controls.Add(this.checkBox11);
            this.tabPage2.Controls.Add(this.checkBox8);
            this.tabPage2.Controls.Add(this.checkBox7);
            this.tabPage2.Controls.Add(this.checkBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(428, 95);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Wochentag";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(337, 40);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(66, 17);
            this.checkBox12.TabIndex = 6;
            this.checkBox12.Text = "Sonntag";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(336, 17);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(67, 17);
            this.checkBox9.TabIndex = 5;
            this.checkBox9.Text = "Samstag";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(281, 17);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(58, 17);
            this.checkBox10.TabIndex = 4;
            this.checkBox10.Text = "Freitag";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(201, 17);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(81, 17);
            this.checkBox11.TabIndex = 3;
            this.checkBox11.Text = "Donnerstag";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(133, 17);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(69, 17);
            this.checkBox8.TabIndex = 2;
            this.checkBox8.Text = "Mittwoch";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(66, 17);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(68, 17);
            this.checkBox7.TabIndex = 1;
            this.checkBox7.Text = "Dienstag";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(6, 17);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(62, 17);
            this.checkBox6.TabIndex = 0;
            this.checkBox6.Text = "Montag";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkedListBox1);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(428, 95);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Monatstage";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ColumnWidth = 100;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalExtent = 4;
            this.checkedListBox1.Items.AddRange(new object[] {
            "1. Tag im Monat",
            "2. Tag im Monat",
            "3. Tag im Monat",
            "4. Tag im Monat",
            "5. Tag im Monat",
            "6. Tag im Monat",
            "7. Tag im Monat",
            "8. Tag im Monat",
            "9. Tag im Monat",
            "10. Tag im Monat",
            "11.Tag im Monat",
            "12. Tag im Monat",
            "13. Tag im Monat",
            "14. Tag im Monat",
            "15. Tag im Monat",
            "16. Tag im Monat",
            "17. Tag im Monat",
            "18. Tag im Monat",
            "19. Tag im Monat",
            "20. Tag im Monat",
            "21. Tag im Monat",
            "22. Tag im Monat",
            "23. Tag im Monat",
            "24. Tag im Monat",
            "25. Tag im Monat",
            "26. Tag im Monat",
            "27. Tag im Monat",
            "28. Tag im Monat",
            "29. Tag im Monat",
            "30. Tag im Monat",
            "31. Tag im Monat",
            "letzter Tag im Monat"});
            this.checkedListBox1.Location = new System.Drawing.Point(15, 36);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(407, 49);
            this.checkedListBox1.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(352, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Wählen Sie die Tage des Monats, an denen eine Sicherung erfolgen soll.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Sicherung beschränken";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Sicherung bei Systemereignis";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Sicherung zur Uhrzeit / im Intervall";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Uhr durchführen";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(15, 132);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(91, 17);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "Sicherung um";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(152, 83);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(126, 17);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Windows-Abmeldung";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(16, 84);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(95, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Windows-Start";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(38, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "nicht aktiviert";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "USB-Geräterkennung";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnDeleteBackupSet
            // 
            this.btnDeleteBackupSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteBackupSet.Location = new System.Drawing.Point(6, 352);
            this.btnDeleteBackupSet.Name = "btnDeleteBackupSet";
            this.btnDeleteBackupSet.Size = new System.Drawing.Size(129, 23);
            this.btnDeleteBackupSet.TabIndex = 0;
            this.btnDeleteBackupSet.Text = "Job löschen";
            this.btnDeleteBackupSet.Click += new System.EventHandler(this.btnDeleteBackupSet_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(396, 248);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 23);
            this.button4.TabIndex = 28;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(180, 14);
            this.label12.TabIndex = 27;
            this.label12.Text = "Alternative nach:";
            // 
            // tbxAlternative
            // 
            this.tbxAlternative.Location = new System.Drawing.Point(11, 250);
            this.tbxAlternative.Name = "tbxAlternative";
            this.tbxAlternative.Size = new System.Drawing.Size(379, 20);
            this.tbxAlternative.TabIndex = 26;
            // 
            // frmOptions
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(468, 382);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeleteBackupSet);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(236, 252);
            this.Name = "frmOptions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Optionen";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabDirectories.ResumeLayout(false);
            this.tabDirectories.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabDirectories;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tabGeneral;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnRemoveFullDirs;
    private System.Windows.Forms.ListBox lbDirs;
    private System.Windows.Forms.FolderBrowserDialog fb1;
    private System.Windows.Forms.TextBox tbxDescription;
    private System.Windows.Forms.TextBox tbxName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbxAddDirectory;
    private System.Windows.Forms.Button btnAddFullDirs;
    private System.Windows.Forms.Button btnDeleteBackupSet;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbxBackupTo;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabControl tabControl2;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.CheckBox checkBox12;
    private System.Windows.Forms.CheckBox checkBox9;
    private System.Windows.Forms.CheckBox checkBox10;
    private System.Windows.Forms.CheckBox checkBox11;
    private System.Windows.Forms.CheckBox checkBox8;
    private System.Windows.Forms.CheckBox checkBox7;
    private System.Windows.Forms.CheckBox checkBox6;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.CheckedListBox checkedListBox1;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.CheckBox checkBox5;
    private System.Windows.Forms.CheckBox checkBox3;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.CheckBox checkBox13;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    private Bienz.UI.DriveCombo driveCombo1;
    private System.Windows.Forms.CheckBox checkBox4;
    private System.Windows.Forms.CheckBox cbLöschen;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox tbxAlternative;
  }
}
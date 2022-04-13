
namespace AntaresUtilsNetFramework
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.CryptoGetter = new System.Windows.Forms.TabPage();
            this.CGCryptoCodeTextBox = new System.Windows.Forms.TextBox();
            this.CGCryptoKeyTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CGSaveImageButton = new System.Windows.Forms.Button();
            this.CGDataMatrixPictureBox = new System.Windows.Forms.PictureBox();
            this.CGSerialTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CGGtinTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CGSgtinTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CGGetCryptocodeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CGServerComboBox = new System.Windows.Forms.ComboBox();
            this.GeometriesPage = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.AGRecipeNameTextBox = new System.Windows.Forms.TextBox();
            this.AGSendAgregationToDbButton = new System.Windows.Forms.Button();
            this.AGGridView = new System.Windows.Forms.DataGridView();
            this.LineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGRecipesComboBox = new System.Windows.Forms.ComboBox();
            this.AGGetAgregationGeometryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AGGetRecipesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AGServerComboBox = new System.Windows.Forms.ComboBox();
            this.RecipePage = new System.Windows.Forms.TabPage();
            this.RecipesMaterialNameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.RecipesUpdateDbButton = new System.Windows.Forms.Button();
            this.RecipesLoadFromFileButton = new System.Windows.Forms.Button();
            this.RecipesSaveToFileButton = new System.Windows.Forms.Button();
            this.RecipesGridView = new System.Windows.Forms.DataGridView();
            this.RecipeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecipesGMIDComboBox = new System.Windows.Forms.ComboBox();
            this.RecipesGetRecipeListButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.RecipesGetGMIDsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RecipesServerComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.AWOStatusComboBox = new System.Windows.Forms.ComboBox();
            this.AWOUpdateDbButton = new System.Windows.Forms.Button();
            this.AWOManufacturedTextBox = new System.Windows.Forms.TextBox();
            this.AWOExpiryTextBox = new System.Windows.Forms.TextBox();
            this.AWOQuantityTextBox = new System.Windows.Forms.TextBox();
            this.AWOLineInfoTextBox = new System.Windows.Forms.TextBox();
            this.AWOLotTextBox = new System.Windows.Forms.TextBox();
            this.AWOWorkordersNameTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.AWOWorkordersListComboBox = new System.Windows.Forms.ComboBox();
            this.AWOGetWODetailButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.AWOGetWOsButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.AWOServerComboBox = new System.Windows.Forms.ComboBox();
            this.CaseCounterPage = new System.Windows.Forms.TabPage();
            this.CountedAggregationTreeView = new System.Windows.Forms.TreeView();
            this.CCWorkordersListComboBox = new System.Windows.Forms.ComboBox();
            this.CCCountCasesButton = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.CCGetWorkordersButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.CCServerComboBox = new System.Windows.Forms.ComboBox();
            this.MainTabControl.SuspendLayout();
            this.CryptoGetter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CGDataMatrixPictureBox)).BeginInit();
            this.GeometriesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AGGridView)).BeginInit();
            this.RecipePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecipesGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.CaseCounterPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.CryptoGetter);
            this.MainTabControl.Controls.Add(this.GeometriesPage);
            this.MainTabControl.Controls.Add(this.RecipePage);
            this.MainTabControl.Controls.Add(this.tabPage1);
            this.MainTabControl.Controls.Add(this.CaseCounterPage);
            this.MainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(763, 500);
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // CryptoGetter
            // 
            this.CryptoGetter.Controls.Add(this.CGCryptoCodeTextBox);
            this.CryptoGetter.Controls.Add(this.CGCryptoKeyTextBox);
            this.CryptoGetter.Controls.Add(this.label10);
            this.CryptoGetter.Controls.Add(this.label9);
            this.CryptoGetter.Controls.Add(this.CGSaveImageButton);
            this.CryptoGetter.Controls.Add(this.CGDataMatrixPictureBox);
            this.CryptoGetter.Controls.Add(this.CGSerialTextBox);
            this.CryptoGetter.Controls.Add(this.label8);
            this.CryptoGetter.Controls.Add(this.CGGtinTextBox);
            this.CryptoGetter.Controls.Add(this.label7);
            this.CryptoGetter.Controls.Add(this.CGSgtinTextBox);
            this.CryptoGetter.Controls.Add(this.label6);
            this.CryptoGetter.Controls.Add(this.CGGetCryptocodeButton);
            this.CryptoGetter.Controls.Add(this.label5);
            this.CryptoGetter.Controls.Add(this.CGServerComboBox);
            this.CryptoGetter.Location = new System.Drawing.Point(4, 29);
            this.CryptoGetter.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.CryptoGetter.Name = "CryptoGetter";
            this.CryptoGetter.Padding = new System.Windows.Forms.Padding(3);
            this.CryptoGetter.Size = new System.Drawing.Size(755, 467);
            this.CryptoGetter.TabIndex = 2;
            this.CryptoGetter.Text = "CryptoGetter";
            this.CryptoGetter.UseVisualStyleBackColor = true;
            // 
            // CGCryptoCodeTextBox
            // 
            this.CGCryptoCodeTextBox.Location = new System.Drawing.Point(77, 233);
            this.CGCryptoCodeTextBox.Name = "CGCryptoCodeTextBox";
            this.CGCryptoCodeTextBox.ReadOnly = true;
            this.CGCryptoCodeTextBox.Size = new System.Drawing.Size(455, 26);
            this.CGCryptoCodeTextBox.TabIndex = 18;
            // 
            // CGCryptoKeyTextBox
            // 
            this.CGCryptoKeyTextBox.Location = new System.Drawing.Point(77, 201);
            this.CGCryptoKeyTextBox.Name = "CGCryptoKeyTextBox";
            this.CGCryptoKeyTextBox.ReadOnly = true;
            this.CGCryptoKeyTextBox.Size = new System.Drawing.Size(59, 26);
            this.CGCryptoKeyTextBox.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Key";
            // 
            // CGSaveImageButton
            // 
            this.CGSaveImageButton.Location = new System.Drawing.Point(593, 200);
            this.CGSaveImageButton.Name = "CGSaveImageButton";
            this.CGSaveImageButton.Size = new System.Drawing.Size(134, 28);
            this.CGSaveImageButton.TabIndex = 14;
            this.CGSaveImageButton.Text = "Save";
            this.CGSaveImageButton.UseVisualStyleBackColor = true;
            this.CGSaveImageButton.Click += new System.EventHandler(this.SaveImageButton_Click);
            // 
            // CGDataMatrixPictureBox
            // 
            this.CGDataMatrixPictureBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CGDataMatrixPictureBox.Location = new System.Drawing.Point(564, 9);
            this.CGDataMatrixPictureBox.Name = "CGDataMatrixPictureBox";
            this.CGDataMatrixPictureBox.Size = new System.Drawing.Size(185, 185);
            this.CGDataMatrixPictureBox.TabIndex = 13;
            this.CGDataMatrixPictureBox.TabStop = false;
            // 
            // CGSerialTextBox
            // 
            this.CGSerialTextBox.Location = new System.Drawing.Point(77, 104);
            this.CGSerialTextBox.Name = "CGSerialTextBox";
            this.CGSerialTextBox.Size = new System.Drawing.Size(124, 26);
            this.CGSerialTextBox.TabIndex = 12;
            this.CGSerialTextBox.TextChanged += new System.EventHandler(this.SerialBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Serial";
            // 
            // CGGtinTextBox
            // 
            this.CGGtinTextBox.Location = new System.Drawing.Point(77, 72);
            this.CGGtinTextBox.Name = "CGGtinTextBox";
            this.CGGtinTextBox.Size = new System.Drawing.Size(134, 26);
            this.CGGtinTextBox.TabIndex = 10;
            this.CGGtinTextBox.TextChanged += new System.EventHandler(this.GtinBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "GTIN";
            // 
            // CGSgtinTextBox
            // 
            this.CGSgtinTextBox.Location = new System.Drawing.Point(77, 40);
            this.CGSgtinTextBox.Name = "CGSgtinTextBox";
            this.CGSgtinTextBox.Size = new System.Drawing.Size(251, 26);
            this.CGSgtinTextBox.TabIndex = 8;
            this.CGSgtinTextBox.TextChanged += new System.EventHandler(this.SgtinBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "SGTIN";
            // 
            // CGGetCryptocodeButton
            // 
            this.CGGetCryptocodeButton.Location = new System.Drawing.Point(77, 136);
            this.CGGetCryptocodeButton.Name = "CGGetCryptocodeButton";
            this.CGGetCryptocodeButton.Size = new System.Drawing.Size(144, 28);
            this.CGGetCryptocodeButton.TabIndex = 5;
            this.CGGetCryptocodeButton.Text = "Get Cryptocode";
            this.CGGetCryptocodeButton.UseVisualStyleBackColor = true;
            this.CGGetCryptocodeButton.Click += new System.EventHandler(this.GetCryptoСodeButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Server";
            // 
            // CGServerComboBox
            // 
            this.CGServerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CGServerComboBox.DropDownWidth = 144;
            this.CGServerComboBox.FormattingEnabled = true;
            this.CGServerComboBox.Location = new System.Drawing.Point(77, 6);
            this.CGServerComboBox.Name = "CGServerComboBox";
            this.CGServerComboBox.Size = new System.Drawing.Size(144, 28);
            this.CGServerComboBox.TabIndex = 3;
            this.CGServerComboBox.SelectedIndexChanged += new System.EventHandler(this.CryptoServerBox_SelectedIndexChanged);
            // 
            // GeometriesPage
            // 
            this.GeometriesPage.Controls.Add(this.label11);
            this.GeometriesPage.Controls.Add(this.AGRecipeNameTextBox);
            this.GeometriesPage.Controls.Add(this.AGSendAgregationToDbButton);
            this.GeometriesPage.Controls.Add(this.AGGridView);
            this.GeometriesPage.Controls.Add(this.AGRecipesComboBox);
            this.GeometriesPage.Controls.Add(this.AGGetAgregationGeometryButton);
            this.GeometriesPage.Controls.Add(this.label2);
            this.GeometriesPage.Controls.Add(this.AGGetRecipesButton);
            this.GeometriesPage.Controls.Add(this.label1);
            this.GeometriesPage.Controls.Add(this.AGServerComboBox);
            this.GeometriesPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeometriesPage.Location = new System.Drawing.Point(4, 29);
            this.GeometriesPage.Name = "GeometriesPage";
            this.GeometriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeometriesPage.Size = new System.Drawing.Size(755, 467);
            this.GeometriesPage.TabIndex = 0;
            this.GeometriesPage.Text = "Aggregation Geometries";
            this.GeometriesPage.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "Name";
            // 
            // AGRecipeNameTextBox
            // 
            this.AGRecipeNameTextBox.Location = new System.Drawing.Point(76, 89);
            this.AGRecipeNameTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.AGRecipeNameTextBox.Name = "AGRecipeNameTextBox";
            this.AGRecipeNameTextBox.ReadOnly = true;
            this.AGRecipeNameTextBox.Size = new System.Drawing.Size(598, 26);
            this.AGRecipeNameTextBox.TabIndex = 9;
            // 
            // AGSendAgregationToDbButton
            // 
            this.AGSendAgregationToDbButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AGSendAgregationToDbButton.Enabled = false;
            this.AGSendAgregationToDbButton.Location = new System.Drawing.Point(679, 198);
            this.AGSendAgregationToDbButton.Name = "AGSendAgregationToDbButton";
            this.AGSendAgregationToDbButton.Size = new System.Drawing.Size(67, 201);
            this.AGSendAgregationToDbButton.TabIndex = 8;
            this.AGSendAgregationToDbButton.Text = "Send to DB";
            this.AGSendAgregationToDbButton.UseVisualStyleBackColor = true;
            this.AGSendAgregationToDbButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // AGGridView
            // 
            this.AGGridView.AllowUserToAddRows = false;
            this.AGGridView.AllowUserToDeleteRows = false;
            this.AGGridView.AllowUserToResizeColumns = false;
            this.AGGridView.AllowUserToResizeRows = false;
            this.AGGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AGGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AGGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineId,
            this.ItemType,
            this.X,
            this.Y,
            this.Z,
            this.Total});
            this.AGGridView.Location = new System.Drawing.Point(8, 129);
            this.AGGridView.Margin = new System.Windows.Forms.Padding(8);
            this.AGGridView.MultiSelect = false;
            this.AGGridView.Name = "AGGridView";
            this.AGGridView.RowHeadersVisible = false;
            this.AGGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AGGridView.Size = new System.Drawing.Size(663, 327);
            this.AGGridView.TabIndex = 7;
            this.AGGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GeometryGridView_CellEndEdit);
            // 
            // LineId
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LineId.DefaultCellStyle = dataGridViewCellStyle1;
            this.LineId.HeaderText = "LineId";
            this.LineId.Name = "LineId";
            this.LineId.ReadOnly = true;
            this.LineId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LineId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LineId.Width = 110;
            // 
            // ItemType
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItemType.DefaultCellStyle = dataGridViewCellStyle2;
            this.ItemType.HeaderText = "ItemType";
            this.ItemType.Name = "ItemType";
            this.ItemType.ReadOnly = true;
            this.ItemType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemType.Width = 110;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.X.Width = 110;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Y.Width = 110;
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            this.Z.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Z.Width = 110;
            // 
            // Total
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Total.DefaultCellStyle = dataGridViewCellStyle3;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Total.Width = 110;
            // 
            // AGRecipesComboBox
            // 
            this.AGRecipesComboBox.FormattingEnabled = true;
            this.AGRecipesComboBox.Location = new System.Drawing.Point(77, 50);
            this.AGRecipesComboBox.Name = "AGRecipesComboBox";
            this.AGRecipesComboBox.Size = new System.Drawing.Size(144, 28);
            this.AGRecipesComboBox.TabIndex = 5;
            this.AGRecipesComboBox.TextChanged += new System.EventHandler(this.RecipesBox_TextChanged);
            // 
            // AGGetAgregationGeometryButton
            // 
            this.AGGetAgregationGeometryButton.Enabled = false;
            this.AGGetAgregationGeometryButton.Location = new System.Drawing.Point(232, 50);
            this.AGGetAgregationGeometryButton.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.AGGetAgregationGeometryButton.Name = "AGGetAgregationGeometryButton";
            this.AGGetAgregationGeometryButton.Size = new System.Drawing.Size(144, 28);
            this.AGGetAgregationGeometryButton.TabIndex = 4;
            this.AGGetAgregationGeometryButton.Text = "Get Geometry";
            this.AGGetAgregationGeometryButton.UseVisualStyleBackColor = true;
            this.AGGetAgregationGeometryButton.Click += new System.EventHandler(this.GetGeometryButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Recipe";
            // 
            // AGGetRecipesButton
            // 
            this.AGGetRecipesButton.Location = new System.Drawing.Point(232, 6);
            this.AGGetRecipesButton.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.AGGetRecipesButton.Name = "AGGetRecipesButton";
            this.AGGetRecipesButton.Size = new System.Drawing.Size(144, 28);
            this.AGGetRecipesButton.TabIndex = 2;
            this.AGGetRecipesButton.Text = "Get Recipes";
            this.AGGetRecipesButton.UseVisualStyleBackColor = true;
            this.AGGetRecipesButton.Click += new System.EventHandler(this.GetRecipesButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // AGServerComboBox
            // 
            this.AGServerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AGServerComboBox.FormattingEnabled = true;
            this.AGServerComboBox.Location = new System.Drawing.Point(77, 6);
            this.AGServerComboBox.Name = "AGServerComboBox";
            this.AGServerComboBox.Size = new System.Drawing.Size(144, 28);
            this.AGServerComboBox.TabIndex = 0;
            this.AGServerComboBox.SelectedIndexChanged += new System.EventHandler(this.GeometryServerBox_SelectedIndexChanged);
            // 
            // RecipePage
            // 
            this.RecipePage.Controls.Add(this.RecipesMaterialNameTextBox);
            this.RecipePage.Controls.Add(this.label12);
            this.RecipePage.Controls.Add(this.RecipesUpdateDbButton);
            this.RecipePage.Controls.Add(this.RecipesLoadFromFileButton);
            this.RecipePage.Controls.Add(this.RecipesSaveToFileButton);
            this.RecipePage.Controls.Add(this.RecipesGridView);
            this.RecipePage.Controls.Add(this.RecipesGMIDComboBox);
            this.RecipePage.Controls.Add(this.RecipesGetRecipeListButton);
            this.RecipePage.Controls.Add(this.label4);
            this.RecipePage.Controls.Add(this.RecipesGetGMIDsButton);
            this.RecipePage.Controls.Add(this.label3);
            this.RecipePage.Controls.Add(this.RecipesServerComboBox);
            this.RecipePage.Location = new System.Drawing.Point(4, 29);
            this.RecipePage.Name = "RecipePage";
            this.RecipePage.Padding = new System.Windows.Forms.Padding(3);
            this.RecipePage.Size = new System.Drawing.Size(755, 467);
            this.RecipePage.TabIndex = 1;
            this.RecipePage.Text = "Recipes";
            this.RecipePage.UseVisualStyleBackColor = true;
            // 
            // RecipesMaterialNameTextBox
            // 
            this.RecipesMaterialNameTextBox.Location = new System.Drawing.Point(76, 89);
            this.RecipesMaterialNameTextBox.Margin = new System.Windows.Forms.Padding(8);
            this.RecipesMaterialNameTextBox.Name = "RecipesMaterialNameTextBox";
            this.RecipesMaterialNameTextBox.ReadOnly = true;
            this.RecipesMaterialNameTextBox.Size = new System.Drawing.Size(548, 26);
            this.RecipesMaterialNameTextBox.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 20);
            this.label12.TabIndex = 13;
            this.label12.Text = "Name";
            // 
            // RecipesUpdateDbButton
            // 
            this.RecipesUpdateDbButton.Location = new System.Drawing.Point(630, 433);
            this.RecipesUpdateDbButton.Name = "RecipesUpdateDbButton";
            this.RecipesUpdateDbButton.Size = new System.Drawing.Size(119, 28);
            this.RecipesUpdateDbButton.TabIndex = 12;
            this.RecipesUpdateDbButton.Text = "Update DB";
            this.RecipesUpdateDbButton.UseVisualStyleBackColor = true;
            this.RecipesUpdateDbButton.Click += new System.EventHandler(this.UpdateDbButton_Click);
            // 
            // RecipesLoadFromFileButton
            // 
            this.RecipesLoadFromFileButton.Location = new System.Drawing.Point(630, 224);
            this.RecipesLoadFromFileButton.Margin = new System.Windows.Forms.Padding(3, 34, 3, 3);
            this.RecipesLoadFromFileButton.Name = "RecipesLoadFromFileButton";
            this.RecipesLoadFromFileButton.Size = new System.Drawing.Size(119, 28);
            this.RecipesLoadFromFileButton.TabIndex = 11;
            this.RecipesLoadFromFileButton.Text = "Load from File";
            this.RecipesLoadFromFileButton.UseVisualStyleBackColor = true;
            this.RecipesLoadFromFileButton.Click += new System.EventHandler(this.LoadFromFileButton_Click);
            // 
            // RecipesSaveToFileButton
            // 
            this.RecipesSaveToFileButton.Location = new System.Drawing.Point(630, 159);
            this.RecipesSaveToFileButton.Name = "RecipesSaveToFileButton";
            this.RecipesSaveToFileButton.Size = new System.Drawing.Size(119, 28);
            this.RecipesSaveToFileButton.TabIndex = 10;
            this.RecipesSaveToFileButton.Text = "Save to File";
            this.RecipesSaveToFileButton.UseVisualStyleBackColor = true;
            this.RecipesSaveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
            // 
            // RecipesGridView
            // 
            this.RecipesGridView.AllowUserToAddRows = false;
            this.RecipesGridView.AllowUserToDeleteRows = false;
            this.RecipesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecipesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecipeID,
            this.Column1,
            this.Column3,
            this.Column4});
            this.RecipesGridView.Location = new System.Drawing.Point(10, 126);
            this.RecipesGridView.Name = "RecipesGridView";
            this.RecipesGridView.ReadOnly = true;
            this.RecipesGridView.RowHeadersVisible = false;
            this.RecipesGridView.Size = new System.Drawing.Size(614, 335);
            this.RecipesGridView.TabIndex = 9;
            // 
            // RecipeID
            // 
            this.RecipeID.HeaderText = "RecipeID";
            this.RecipeID.Name = "RecipeID";
            this.RecipeID.ReadOnly = true;
            this.RecipeID.Width = 220;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "LineID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Type";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 130;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quantity";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // RecipesGMIDComboBox
            // 
            this.RecipesGMIDComboBox.DropDownWidth = 144;
            this.RecipesGMIDComboBox.FormattingEnabled = true;
            this.RecipesGMIDComboBox.Location = new System.Drawing.Point(77, 50);
            this.RecipesGMIDComboBox.Name = "RecipesGMIDComboBox";
            this.RecipesGMIDComboBox.Size = new System.Drawing.Size(144, 28);
            this.RecipesGMIDComboBox.TabIndex = 8;
            this.RecipesGMIDComboBox.TextChanged += new System.EventHandler(this.GMIDBox_TextChanged);
            // 
            // RecipesGetRecipeListButton
            // 
            this.RecipesGetRecipeListButton.Location = new System.Drawing.Point(232, 50);
            this.RecipesGetRecipeListButton.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.RecipesGetRecipeListButton.Name = "RecipesGetRecipeListButton";
            this.RecipesGetRecipeListButton.Size = new System.Drawing.Size(144, 28);
            this.RecipesGetRecipeListButton.TabIndex = 7;
            this.RecipesGetRecipeListButton.Text = "Get Recipes";
            this.RecipesGetRecipeListButton.UseVisualStyleBackColor = true;
            this.RecipesGetRecipeListButton.Click += new System.EventHandler(this.GetRecipeListButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "GMID";
            // 
            // RecipesGetGMIDsButton
            // 
            this.RecipesGetGMIDsButton.Location = new System.Drawing.Point(232, 6);
            this.RecipesGetGMIDsButton.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.RecipesGetGMIDsButton.Name = "RecipesGetGMIDsButton";
            this.RecipesGetGMIDsButton.Size = new System.Drawing.Size(144, 28);
            this.RecipesGetGMIDsButton.TabIndex = 5;
            this.RecipesGetGMIDsButton.Text = "Get GMIDs";
            this.RecipesGetGMIDsButton.UseVisualStyleBackColor = true;
            this.RecipesGetGMIDsButton.Click += new System.EventHandler(this.GetGMIDsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Server";
            // 
            // RecipesServerComboBox
            // 
            this.RecipesServerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RecipesServerComboBox.DropDownWidth = 144;
            this.RecipesServerComboBox.FormattingEnabled = true;
            this.RecipesServerComboBox.Location = new System.Drawing.Point(77, 6);
            this.RecipesServerComboBox.Name = "RecipesServerComboBox";
            this.RecipesServerComboBox.Size = new System.Drawing.Size(144, 28);
            this.RecipesServerComboBox.TabIndex = 3;
            this.RecipesServerComboBox.SelectedIndexChanged += new System.EventHandler(this.RecipesServerBox_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.AWOStatusComboBox);
            this.tabPage1.Controls.Add(this.AWOUpdateDbButton);
            this.tabPage1.Controls.Add(this.AWOManufacturedTextBox);
            this.tabPage1.Controls.Add(this.AWOExpiryTextBox);
            this.tabPage1.Controls.Add(this.AWOQuantityTextBox);
            this.tabPage1.Controls.Add(this.AWOLineInfoTextBox);
            this.tabPage1.Controls.Add(this.AWOLotTextBox);
            this.tabPage1.Controls.Add(this.AWOWorkordersNameTextBox);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.AWOWorkordersListComboBox);
            this.tabPage1.Controls.Add(this.AWOGetWODetailButton);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.AWOGetWOsButton);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.AWOServerComboBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(755, 467);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Active Workorders";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // AWOStatusComboBox
            // 
            this.AWOStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AWOStatusComboBox.FormattingEnabled = true;
            this.AWOStatusComboBox.Location = new System.Drawing.Point(375, 170);
            this.AWOStatusComboBox.Name = "AWOStatusComboBox";
            this.AWOStatusComboBox.Size = new System.Drawing.Size(144, 28);
            this.AWOStatusComboBox.TabIndex = 27;
            // 
            // AWOUpdateDbButton
            // 
            this.AWOUpdateDbButton.Location = new System.Drawing.Point(605, 433);
            this.AWOUpdateDbButton.Name = "AWOUpdateDbButton";
            this.AWOUpdateDbButton.Size = new System.Drawing.Size(144, 28);
            this.AWOUpdateDbButton.TabIndex = 26;
            this.AWOUpdateDbButton.Text = "Update DB";
            this.AWOUpdateDbButton.UseVisualStyleBackColor = true;
            this.AWOUpdateDbButton.Click += new System.EventHandler(this.WOUpdateDbButton_Click);
            // 
            // AWOManufacturedTextBox
            // 
            this.AWOManufacturedTextBox.Location = new System.Drawing.Point(375, 214);
            this.AWOManufacturedTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.AWOManufacturedTextBox.Name = "AWOManufacturedTextBox";
            this.AWOManufacturedTextBox.Size = new System.Drawing.Size(144, 26);
            this.AWOManufacturedTextBox.TabIndex = 25;
            // 
            // AWOExpiryTextBox
            // 
            this.AWOExpiryTextBox.Location = new System.Drawing.Point(77, 214);
            this.AWOExpiryTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.AWOExpiryTextBox.Name = "AWOExpiryTextBox";
            this.AWOExpiryTextBox.Size = new System.Drawing.Size(144, 26);
            this.AWOExpiryTextBox.TabIndex = 24;
            // 
            // AWOQuantityTextBox
            // 
            this.AWOQuantityTextBox.Location = new System.Drawing.Point(645, 172);
            this.AWOQuantityTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.AWOQuantityTextBox.Name = "AWOQuantityTextBox";
            this.AWOQuantityTextBox.ReadOnly = true;
            this.AWOQuantityTextBox.Size = new System.Drawing.Size(100, 26);
            this.AWOQuantityTextBox.TabIndex = 23;
            // 
            // AWOLineInfoTextBox
            // 
            this.AWOLineInfoTextBox.Location = new System.Drawing.Point(77, 130);
            this.AWOLineInfoTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.AWOLineInfoTextBox.Name = "AWOLineInfoTextBox";
            this.AWOLineInfoTextBox.ReadOnly = true;
            this.AWOLineInfoTextBox.Size = new System.Drawing.Size(299, 26);
            this.AWOLineInfoTextBox.TabIndex = 21;
            // 
            // AWOLotTextBox
            // 
            this.AWOLotTextBox.Location = new System.Drawing.Point(77, 172);
            this.AWOLotTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.AWOLotTextBox.Name = "AWOLotTextBox";
            this.AWOLotTextBox.ReadOnly = true;
            this.AWOLotTextBox.Size = new System.Drawing.Size(144, 26);
            this.AWOLotTextBox.TabIndex = 20;
            // 
            // AWOWorkordersNameTextBox
            // 
            this.AWOWorkordersNameTextBox.Location = new System.Drawing.Point(78, 89);
            this.AWOWorkordersNameTextBox.Margin = new System.Windows.Forms.Padding(8);
            this.AWOWorkordersNameTextBox.Name = "AWOWorkordersNameTextBox";
            this.AWOWorkordersNameTextBox.ReadOnly = true;
            this.AWOWorkordersNameTextBox.Size = new System.Drawing.Size(667, 26);
            this.AWOWorkordersNameTextBox.TabIndex = 19;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(313, 175);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 20);
            this.label21.TabIndex = 18;
            this.label21.Text = "Status";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 217);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 20);
            this.label20.TabIndex = 17;
            this.label20.Text = "Expiry";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(261, 217);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 20);
            this.label19.TabIndex = 16;
            this.label19.Text = "Manufactured";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(571, 175);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 20);
            this.label18.TabIndex = 15;
            this.label18.Text = "Quantity";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 20);
            this.label17.TabIndex = 14;
            this.label17.Text = "Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 175);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 20);
            this.label16.TabIndex = 13;
            this.label16.Text = "Lot";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 20);
            this.label15.TabIndex = 12;
            this.label15.Text = "Line";
            // 
            // AWOWorkordersListComboBox
            // 
            this.AWOWorkordersListComboBox.DropDownWidth = 144;
            this.AWOWorkordersListComboBox.FormattingEnabled = true;
            this.AWOWorkordersListComboBox.Location = new System.Drawing.Point(77, 50);
            this.AWOWorkordersListComboBox.Name = "AWOWorkordersListComboBox";
            this.AWOWorkordersListComboBox.Size = new System.Drawing.Size(144, 28);
            this.AWOWorkordersListComboBox.TabIndex = 11;
            this.AWOWorkordersListComboBox.TextChanged += new System.EventHandler(this.WOListBox_TextChanged);
            // 
            // AWOGetWODetailButton
            // 
            this.AWOGetWODetailButton.Location = new System.Drawing.Point(232, 50);
            this.AWOGetWODetailButton.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.AWOGetWODetailButton.Name = "AWOGetWODetailButton";
            this.AWOGetWODetailButton.Size = new System.Drawing.Size(144, 28);
            this.AWOGetWODetailButton.TabIndex = 10;
            this.AWOGetWODetailButton.Text = "Get Info";
            this.AWOGetWODetailButton.UseVisualStyleBackColor = true;
            this.AWOGetWODetailButton.Click += new System.EventHandler(this.GetWODetailButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 20);
            this.label14.TabIndex = 9;
            this.label14.Text = "WO";
            // 
            // AWOGetWOsButton
            // 
            this.AWOGetWOsButton.Location = new System.Drawing.Point(232, 6);
            this.AWOGetWOsButton.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.AWOGetWOsButton.Name = "AWOGetWOsButton";
            this.AWOGetWOsButton.Size = new System.Drawing.Size(144, 28);
            this.AWOGetWOsButton.TabIndex = 8;
            this.AWOGetWOsButton.Text = "Get Workorders";
            this.AWOGetWOsButton.UseVisualStyleBackColor = true;
            this.AWOGetWOsButton.Click += new System.EventHandler(this.GetWOsButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Server";
            // 
            // AWOServerComboBox
            // 
            this.AWOServerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AWOServerComboBox.DropDownWidth = 144;
            this.AWOServerComboBox.FormattingEnabled = true;
            this.AWOServerComboBox.Location = new System.Drawing.Point(77, 6);
            this.AWOServerComboBox.Name = "AWOServerComboBox";
            this.AWOServerComboBox.Size = new System.Drawing.Size(144, 28);
            this.AWOServerComboBox.TabIndex = 6;
            this.AWOServerComboBox.SelectedIndexChanged += new System.EventHandler(this.WOServerBox_SelectedIndexChanged);
            // 
            // CaseCounterPage
            // 
            this.CaseCounterPage.Controls.Add(this.CountedAggregationTreeView);
            this.CaseCounterPage.Controls.Add(this.CCWorkordersListComboBox);
            this.CaseCounterPage.Controls.Add(this.CCCountCasesButton);
            this.CaseCounterPage.Controls.Add(this.label23);
            this.CaseCounterPage.Controls.Add(this.CCGetWorkordersButton);
            this.CaseCounterPage.Controls.Add(this.label22);
            this.CaseCounterPage.Controls.Add(this.CCServerComboBox);
            this.CaseCounterPage.Location = new System.Drawing.Point(4, 29);
            this.CaseCounterPage.Name = "CaseCounterPage";
            this.CaseCounterPage.Padding = new System.Windows.Forms.Padding(3);
            this.CaseCounterPage.Size = new System.Drawing.Size(755, 467);
            this.CaseCounterPage.TabIndex = 4;
            this.CaseCounterPage.Text = "Case Counters";
            this.CaseCounterPage.UseVisualStyleBackColor = true;
            // 
            // CountedAggregationTreeView
            // 
            this.CountedAggregationTreeView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CountedAggregationTreeView.Location = new System.Drawing.Point(3, 93);
            this.CountedAggregationTreeView.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.CountedAggregationTreeView.Name = "CountedAggregationTreeView";
            this.CountedAggregationTreeView.Size = new System.Drawing.Size(746, 368);
            this.CountedAggregationTreeView.TabIndex = 15;
            // 
            // CCWorkordersListComboBox
            // 
            this.CCWorkordersListComboBox.DropDownWidth = 144;
            this.CCWorkordersListComboBox.FormattingEnabled = true;
            this.CCWorkordersListComboBox.Location = new System.Drawing.Point(77, 50);
            this.CCWorkordersListComboBox.Margin = new System.Windows.Forms.Padding(8);
            this.CCWorkordersListComboBox.Name = "CCWorkordersListComboBox";
            this.CCWorkordersListComboBox.Size = new System.Drawing.Size(144, 28);
            this.CCWorkordersListComboBox.TabIndex = 14;
            this.CCWorkordersListComboBox.TextChanged += new System.EventHandler(this.CountedWorkorderListBox_TextChanged);
            // 
            // CCCountCasesButton
            // 
            this.CCCountCasesButton.Location = new System.Drawing.Point(232, 50);
            this.CCCountCasesButton.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.CCCountCasesButton.Name = "CCCountCasesButton";
            this.CCCountCasesButton.Size = new System.Drawing.Size(144, 28);
            this.CCCountCasesButton.TabIndex = 13;
            this.CCCountCasesButton.Text = "Count";
            this.CCCountCasesButton.UseVisualStyleBackColor = true;
            this.CCCountCasesButton.Click += new System.EventHandler(this.CountButton_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 20);
            this.label23.TabIndex = 12;
            this.label23.Text = "WO";
            // 
            // CCGetWorkordersButton
            // 
            this.CCGetWorkordersButton.Location = new System.Drawing.Point(232, 6);
            this.CCGetWorkordersButton.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.CCGetWorkordersButton.Name = "CCGetWorkordersButton";
            this.CCGetWorkordersButton.Size = new System.Drawing.Size(144, 28);
            this.CCGetWorkordersButton.TabIndex = 11;
            this.CCGetWorkordersButton.Text = "Get WO List";
            this.CCGetWorkordersButton.UseVisualStyleBackColor = true;
            this.CCGetWorkordersButton.Click += new System.EventHandler(this.GetWorkorderListButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 20);
            this.label22.TabIndex = 10;
            this.label22.Text = "Server";
            // 
            // CCServerComboBox
            // 
            this.CCServerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CCServerComboBox.DropDownWidth = 144;
            this.CCServerComboBox.FormattingEnabled = true;
            this.CCServerComboBox.Location = new System.Drawing.Point(77, 6);
            this.CCServerComboBox.Name = "CCServerComboBox";
            this.CCServerComboBox.Size = new System.Drawing.Size(144, 28);
            this.CCServerComboBox.TabIndex = 9;
            this.CCServerComboBox.SelectedIndexChanged += new System.EventHandler(this.CounterServerBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 524);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Antares Vision utilities by S.M.S.";
            this.MainTabControl.ResumeLayout(false);
            this.CryptoGetter.ResumeLayout(false);
            this.CryptoGetter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CGDataMatrixPictureBox)).EndInit();
            this.GeometriesPage.ResumeLayout(false);
            this.GeometriesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AGGridView)).EndInit();
            this.RecipePage.ResumeLayout(false);
            this.RecipePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecipesGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.CaseCounterPage.ResumeLayout(false);
            this.CaseCounterPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage GeometriesPage;
        private System.Windows.Forms.TabPage RecipePage;
        private System.Windows.Forms.ComboBox AGRecipesComboBox;
        private System.Windows.Forms.Button AGGetAgregationGeometryButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AGGetRecipesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AGServerComboBox;
        private System.Windows.Forms.DataGridView AGGridView;
        private System.Windows.Forms.Button AGSendAgregationToDbButton;
        private System.Windows.Forms.DataGridView RecipesGridView;
        private System.Windows.Forms.ComboBox RecipesGMIDComboBox;
        private System.Windows.Forms.Button RecipesGetRecipeListButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RecipesGetGMIDsButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RecipesServerComboBox;
        private System.Windows.Forms.Button RecipesUpdateDbButton;
        private System.Windows.Forms.Button RecipesLoadFromFileButton;
        private System.Windows.Forms.Button RecipesSaveToFileButton;
        private System.Windows.Forms.TabPage CryptoGetter;
        private System.Windows.Forms.TextBox CGSerialTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CGGtinTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CGSgtinTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CGGetCryptocodeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CGServerComboBox;
        private System.Windows.Forms.TextBox CGCryptoCodeTextBox;
        private System.Windows.Forms.TextBox CGCryptoKeyTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button CGSaveImageButton;
        private System.Windows.Forms.PictureBox CGDataMatrixPictureBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecipeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox AGRecipeNameTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox RecipesMaterialNameTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox AWOManufacturedTextBox;
        private System.Windows.Forms.TextBox AWOExpiryTextBox;
        private System.Windows.Forms.TextBox AWOQuantityTextBox;
        private System.Windows.Forms.TextBox AWOLineInfoTextBox;
        private System.Windows.Forms.TextBox AWOLotTextBox;
        private System.Windows.Forms.TextBox AWOWorkordersNameTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox AWOWorkordersListComboBox;
        private System.Windows.Forms.Button AWOGetWODetailButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button AWOGetWOsButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox AWOServerComboBox;
        private System.Windows.Forms.Button AWOUpdateDbButton;
        private System.Windows.Forms.TabPage CaseCounterPage;
        private System.Windows.Forms.TreeView CountedAggregationTreeView;
        private System.Windows.Forms.ComboBox CCWorkordersListComboBox;
        private System.Windows.Forms.Button CCCountCasesButton;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button CCGetWorkordersButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox CCServerComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.ComboBox AWOStatusComboBox;
    }
}


﻿
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.GeometriesPage = new System.Windows.Forms.TabPage();
            this.SendButton = new System.Windows.Forms.Button();
            this.GeometryGridView = new System.Windows.Forms.DataGridView();
            this.LineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecipesBox = new System.Windows.Forms.ComboBox();
            this.GetGeometryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GetRecipesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GeometryServerBox = new System.Windows.Forms.ComboBox();
            this.RecipePage = new System.Windows.Forms.TabPage();
            this.UpdateDbButton = new System.Windows.Forms.Button();
            this.LoadFromFileButton = new System.Windows.Forms.Button();
            this.SaveToFileButton = new System.Windows.Forms.Button();
            this.RecipesGridView = new System.Windows.Forms.DataGridView();
            this.RecipeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GMIDBox = new System.Windows.Forms.ComboBox();
            this.GetRecipeListButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.GetGMIDsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RecipesServerBox = new System.Windows.Forms.ComboBox();
            this.MainTabControl.SuspendLayout();
            this.GeometriesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeometryGridView)).BeginInit();
            this.RecipePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecipesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.GeometriesPage);
            this.MainTabControl.Controls.Add(this.RecipePage);
            this.MainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(763, 426);
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // GeometriesPage
            // 
            this.GeometriesPage.Controls.Add(this.SendButton);
            this.GeometriesPage.Controls.Add(this.GeometryGridView);
            this.GeometriesPage.Controls.Add(this.RecipesBox);
            this.GeometriesPage.Controls.Add(this.GetGeometryButton);
            this.GeometriesPage.Controls.Add(this.label2);
            this.GeometriesPage.Controls.Add(this.GetRecipesButton);
            this.GeometriesPage.Controls.Add(this.label1);
            this.GeometriesPage.Controls.Add(this.GeometryServerBox);
            this.GeometriesPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeometriesPage.Location = new System.Drawing.Point(4, 29);
            this.GeometriesPage.Name = "GeometriesPage";
            this.GeometriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeometriesPage.Size = new System.Drawing.Size(755, 393);
            this.GeometriesPage.TabIndex = 0;
            this.GeometriesPage.Text = "Aggregation Geometries";
            this.GeometriesPage.UseVisualStyleBackColor = true;
            // 
            // SendButton
            // 
            this.SendButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SendButton.Location = new System.Drawing.Point(682, 137);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(67, 207);
            this.SendButton.TabIndex = 8;
            this.SendButton.Text = "Send to DB";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // GeometryGridView
            // 
            this.GeometryGridView.AllowUserToAddRows = false;
            this.GeometryGridView.AllowUserToDeleteRows = false;
            this.GeometryGridView.AllowUserToResizeColumns = false;
            this.GeometryGridView.AllowUserToResizeRows = false;
            this.GeometryGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GeometryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GeometryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineId,
            this.ItemType,
            this.X,
            this.Y,
            this.Z,
            this.Total});
            this.GeometryGridView.Location = new System.Drawing.Point(10, 87);
            this.GeometryGridView.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.GeometryGridView.MultiSelect = false;
            this.GeometryGridView.Name = "GeometryGridView";
            this.GeometryGridView.RowHeadersVisible = false;
            this.GeometryGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GeometryGridView.Size = new System.Drawing.Size(664, 300);
            this.GeometryGridView.TabIndex = 7;
            this.GeometryGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GeometryGridView_CellEndEdit);
            // 
            // LineId
            // 
            this.LineId.HeaderText = "LineId";
            this.LineId.Name = "LineId";
            this.LineId.ReadOnly = true;
            this.LineId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LineId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LineId.Width = 110;
            // 
            // ItemType
            // 
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
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Total.Width = 110;
            // 
            // RecipesBox
            // 
            this.RecipesBox.FormattingEnabled = true;
            this.RecipesBox.Location = new System.Drawing.Point(76, 50);
            this.RecipesBox.Name = "RecipesBox";
            this.RecipesBox.Size = new System.Drawing.Size(121, 28);
            this.RecipesBox.TabIndex = 5;
            // 
            // GetGeometryButton
            // 
            this.GetGeometryButton.Location = new System.Drawing.Point(217, 50);
            this.GetGeometryButton.Name = "GetGeometryButton";
            this.GetGeometryButton.Size = new System.Drawing.Size(119, 28);
            this.GetGeometryButton.TabIndex = 4;
            this.GetGeometryButton.Text = "Get Geometry";
            this.GetGeometryButton.UseVisualStyleBackColor = true;
            this.GetGeometryButton.Click += new System.EventHandler(this.GetGeometryButton_Click);
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
            // GetRecipesButton
            // 
            this.GetRecipesButton.Location = new System.Drawing.Point(217, 6);
            this.GetRecipesButton.Name = "GetRecipesButton";
            this.GetRecipesButton.Size = new System.Drawing.Size(119, 28);
            this.GetRecipesButton.TabIndex = 2;
            this.GetRecipesButton.Text = "Get Recipes";
            this.GetRecipesButton.UseVisualStyleBackColor = true;
            this.GetRecipesButton.Click += new System.EventHandler(this.GetRecipesButton_Click);
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
            // GeometryServerBox
            // 
            this.GeometryServerBox.FormattingEnabled = true;
            this.GeometryServerBox.Location = new System.Drawing.Point(77, 6);
            this.GeometryServerBox.Name = "GeometryServerBox";
            this.GeometryServerBox.Size = new System.Drawing.Size(121, 28);
            this.GeometryServerBox.TabIndex = 0;
            // 
            // RecipePage
            // 
            this.RecipePage.Controls.Add(this.UpdateDbButton);
            this.RecipePage.Controls.Add(this.LoadFromFileButton);
            this.RecipePage.Controls.Add(this.SaveToFileButton);
            this.RecipePage.Controls.Add(this.RecipesGridView);
            this.RecipePage.Controls.Add(this.GMIDBox);
            this.RecipePage.Controls.Add(this.GetRecipeListButton);
            this.RecipePage.Controls.Add(this.label4);
            this.RecipePage.Controls.Add(this.GetGMIDsButton);
            this.RecipePage.Controls.Add(this.label3);
            this.RecipePage.Controls.Add(this.RecipesServerBox);
            this.RecipePage.Location = new System.Drawing.Point(4, 29);
            this.RecipePage.Name = "RecipePage";
            this.RecipePage.Padding = new System.Windows.Forms.Padding(3);
            this.RecipePage.Size = new System.Drawing.Size(755, 393);
            this.RecipePage.TabIndex = 1;
            this.RecipePage.Text = "Recipes";
            this.RecipePage.UseVisualStyleBackColor = true;
            // 
            // UpdateDbButton
            // 
            this.UpdateDbButton.Location = new System.Drawing.Point(630, 359);
            this.UpdateDbButton.Name = "UpdateDbButton";
            this.UpdateDbButton.Size = new System.Drawing.Size(119, 28);
            this.UpdateDbButton.TabIndex = 12;
            this.UpdateDbButton.Text = "Update DB";
            this.UpdateDbButton.UseVisualStyleBackColor = true;
            // 
            // LoadFromFileButton
            // 
            this.LoadFromFileButton.Location = new System.Drawing.Point(630, 199);
            this.LoadFromFileButton.Margin = new System.Windows.Forms.Padding(3, 34, 3, 3);
            this.LoadFromFileButton.Name = "LoadFromFileButton";
            this.LoadFromFileButton.Size = new System.Drawing.Size(119, 28);
            this.LoadFromFileButton.TabIndex = 11;
            this.LoadFromFileButton.Text = "Load from File";
            this.LoadFromFileButton.UseVisualStyleBackColor = true;
            this.LoadFromFileButton.Click += new System.EventHandler(this.LoadFromFileButton_Click);
            // 
            // SaveToFileButton
            // 
            this.SaveToFileButton.Location = new System.Drawing.Point(630, 134);
            this.SaveToFileButton.Name = "SaveToFileButton";
            this.SaveToFileButton.Size = new System.Drawing.Size(119, 28);
            this.SaveToFileButton.TabIndex = 10;
            this.SaveToFileButton.Text = "Save to File";
            this.SaveToFileButton.UseVisualStyleBackColor = true;
            this.SaveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
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
            this.RecipesGridView.Location = new System.Drawing.Point(10, 87);
            this.RecipesGridView.Name = "RecipesGridView";
            this.RecipesGridView.ReadOnly = true;
            this.RecipesGridView.RowHeadersVisible = false;
            this.RecipesGridView.Size = new System.Drawing.Size(614, 300);
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
            this.Column4.HeaderText = "Quntiy";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // GMIDBox
            // 
            this.GMIDBox.FormattingEnabled = true;
            this.GMIDBox.Location = new System.Drawing.Point(76, 50);
            this.GMIDBox.Name = "GMIDBox";
            this.GMIDBox.Size = new System.Drawing.Size(121, 28);
            this.GMIDBox.TabIndex = 8;
            // 
            // GetRecipeListButton
            // 
            this.GetRecipeListButton.Location = new System.Drawing.Point(217, 50);
            this.GetRecipeListButton.Name = "GetRecipeListButton";
            this.GetRecipeListButton.Size = new System.Drawing.Size(119, 28);
            this.GetRecipeListButton.TabIndex = 7;
            this.GetRecipeListButton.Text = "Get Recipes";
            this.GetRecipeListButton.UseVisualStyleBackColor = true;
            this.GetRecipeListButton.Click += new System.EventHandler(this.GetRecipeListButton_Click);
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
            // GetGMIDsButton
            // 
            this.GetGMIDsButton.Location = new System.Drawing.Point(217, 6);
            this.GetGMIDsButton.Name = "GetGMIDsButton";
            this.GetGMIDsButton.Size = new System.Drawing.Size(119, 28);
            this.GetGMIDsButton.TabIndex = 5;
            this.GetGMIDsButton.Text = "Get GMIDs";
            this.GetGMIDsButton.UseVisualStyleBackColor = true;
            this.GetGMIDsButton.Click += new System.EventHandler(this.GetGMIDsButton_Click);
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
            // RecipesServerBox
            // 
            this.RecipesServerBox.FormattingEnabled = true;
            this.RecipesServerBox.Location = new System.Drawing.Point(77, 6);
            this.RecipesServerBox.Name = "RecipesServerBox";
            this.RecipesServerBox.Size = new System.Drawing.Size(121, 28);
            this.RecipesServerBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 450);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Antares Vision utility by S.M.S.";
            this.MainTabControl.ResumeLayout(false);
            this.GeometriesPage.ResumeLayout(false);
            this.GeometriesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeometryGridView)).EndInit();
            this.RecipePage.ResumeLayout(false);
            this.RecipePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecipesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage GeometriesPage;
        private System.Windows.Forms.TabPage RecipePage;
        private System.Windows.Forms.ComboBox RecipesBox;
        private System.Windows.Forms.Button GetGeometryButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetRecipesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GeometryServerBox;
        private System.Windows.Forms.DataGridView GeometryGridView;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.DataGridView RecipesGridView;
        private System.Windows.Forms.ComboBox GMIDBox;
        private System.Windows.Forms.Button GetRecipeListButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GetGMIDsButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RecipesServerBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button UpdateDbButton;
        private System.Windows.Forms.Button LoadFromFileButton;
        private System.Windows.Forms.Button SaveToFileButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecipeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}


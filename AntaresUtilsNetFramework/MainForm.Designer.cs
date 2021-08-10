
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GeometriesPage = new System.Windows.Forms.TabPage();
            this.SendButton = new System.Windows.Forms.Button();
            this.GeometryGridView = new System.Windows.Forms.DataGridView();
            this.RecipesBox = new System.Windows.Forms.ComboBox();
            this.GetGeometryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GetRecipesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CitiesBox = new System.Windows.Forms.ComboBox();
            this.RecipePage = new System.Windows.Forms.TabPage();
            this.LineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.GeometriesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeometryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.GeometriesPage);
            this.tabControl1.Controls.Add(this.RecipePage);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 426);
            this.tabControl1.TabIndex = 0;
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
            this.GeometriesPage.Controls.Add(this.CitiesBox);
            this.GeometriesPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeometriesPage.Location = new System.Drawing.Point(4, 29);
            this.GeometriesPage.Name = "GeometriesPage";
            this.GeometriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeometriesPage.Size = new System.Drawing.Size(743, 393);
            this.GeometriesPage.TabIndex = 0;
            this.GeometriesPage.Text = "Aggregation Geometries";
            this.GeometriesPage.UseVisualStyleBackColor = true;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(674, 107);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(63, 258);
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
            this.GeometryGridView.Location = new System.Drawing.Point(10, 107);
            this.GeometryGridView.Name = "GeometryGridView";
            this.GeometryGridView.Size = new System.Drawing.Size(643, 258);
            this.GeometryGridView.TabIndex = 7;
            this.GeometryGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GeometryGridView_CellEndEdit);
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
            this.GetRecipesButton.Text = "Get recipes";
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
            // CitiesBox
            // 
            this.CitiesBox.FormattingEnabled = true;
            this.CitiesBox.Location = new System.Drawing.Point(77, 6);
            this.CitiesBox.Name = "CitiesBox";
            this.CitiesBox.Size = new System.Drawing.Size(121, 28);
            this.CitiesBox.TabIndex = 0;
            // 
            // RecipePage
            // 
            this.RecipePage.Location = new System.Drawing.Point(4, 29);
            this.RecipePage.Name = "RecipePage";
            this.RecipePage.Padding = new System.Windows.Forms.Padding(3);
            this.RecipePage.Size = new System.Drawing.Size(743, 393);
            this.RecipePage.TabIndex = 1;
            this.RecipePage.Text = "Recipes";
            this.RecipePage.UseVisualStyleBackColor = true;
            // 
            // LineId
            // 
            this.LineId.HeaderText = "LineId";
            this.LineId.Name = "LineId";
            this.LineId.ReadOnly = true;
            this.LineId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemType
            // 
            this.ItemType.HeaderText = "ItemType";
            this.ItemType.Name = "ItemType";
            this.ItemType.ReadOnly = true;
            this.ItemType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            this.Z.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Antares utility by S.M.S.";
            this.tabControl1.ResumeLayout(false);
            this.GeometriesPage.ResumeLayout(false);
            this.GeometriesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeometryGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GeometriesPage;
        private System.Windows.Forms.TabPage RecipePage;
        private System.Windows.Forms.ComboBox RecipesBox;
        private System.Windows.Forms.Button GetGeometryButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetRecipesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CitiesBox;
        private System.Windows.Forms.DataGridView GeometryGridView;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}


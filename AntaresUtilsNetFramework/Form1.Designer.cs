
namespace AntaresUtilsNetFramework
{
    partial class Form1
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
            this.RecipePage = new System.Windows.Forms.TabPage();
            this.CitiesBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GetRecipeButton = new System.Windows.Forms.Button();
            this.RecipesBox = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.TypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.XHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ZHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.GeometriesPage.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // GeometriesPage
            // 
            this.GeometriesPage.Controls.Add(this.listView1);
            this.GeometriesPage.Controls.Add(this.RecipesBox);
            this.GeometriesPage.Controls.Add(this.GetRecipeButton);
            this.GeometriesPage.Controls.Add(this.label2);
            this.GeometriesPage.Controls.Add(this.ConnectButton);
            this.GeometriesPage.Controls.Add(this.label1);
            this.GeometriesPage.Controls.Add(this.CitiesBox);
            this.GeometriesPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeometriesPage.Location = new System.Drawing.Point(4, 29);
            this.GeometriesPage.Name = "GeometriesPage";
            this.GeometriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeometriesPage.Size = new System.Drawing.Size(768, 393);
            this.GeometriesPage.TabIndex = 0;
            this.GeometriesPage.Text = "Aggregation Geometries";
            this.GeometriesPage.UseVisualStyleBackColor = true;
            // 
            // RecipePage
            // 
            this.RecipePage.Location = new System.Drawing.Point(4, 29);
            this.RecipePage.Name = "RecipePage";
            this.RecipePage.Padding = new System.Windows.Forms.Padding(3);
            this.RecipePage.Size = new System.Drawing.Size(768, 393);
            this.RecipePage.TabIndex = 1;
            this.RecipePage.Text = "Recipes";
            this.RecipePage.UseVisualStyleBackColor = true;
            // 
            // CitiesBox
            // 
            this.CitiesBox.FormattingEnabled = true;
            this.CitiesBox.Location = new System.Drawing.Point(77, 6);
            this.CitiesBox.Name = "CitiesBox";
            this.CitiesBox.Size = new System.Drawing.Size(121, 28);
            this.CitiesBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "City";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(217, 6);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(107, 28);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Recipe";
            // 
            // GetRecipeButton
            // 
            this.GetRecipeButton.Location = new System.Drawing.Point(217, 50);
            this.GetRecipeButton.Name = "GetRecipeButton";
            this.GetRecipeButton.Size = new System.Drawing.Size(107, 28);
            this.GetRecipeButton.TabIndex = 4;
            this.GetRecipeButton.Text = "GetRecipe";
            this.GetRecipeButton.UseVisualStyleBackColor = true;
            // 
            // RecipesBox
            // 
            this.RecipesBox.FormattingEnabled = true;
            this.RecipesBox.Location = new System.Drawing.Point(76, 50);
            this.RecipesBox.Name = "RecipesBox";
            this.RecipesBox.Size = new System.Drawing.Size(121, 28);
            this.RecipesBox.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TypeHeader,
            this.XHeader,
            this.YHeader,
            this.ZHeader,
            this.TotalHeader});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 125);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(314, 249);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // TypeHeader
            // 
            this.TypeHeader.Text = "Type";
            // 
            // XHeader
            // 
            this.XHeader.Text = "X";
            // 
            // YHeader
            // 
            this.YHeader.Text = "Y";
            // 
            // ZHeader
            // 
            this.ZHeader.Text = "Z";
            // 
            // TotalHeader
            // 
            this.TotalHeader.Text = "Total";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.GeometriesPage.ResumeLayout(false);
            this.GeometriesPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GeometriesPage;
        private System.Windows.Forms.TabPage RecipePage;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader TypeHeader;
        private System.Windows.Forms.ColumnHeader XHeader;
        private System.Windows.Forms.ColumnHeader YHeader;
        private System.Windows.Forms.ColumnHeader ZHeader;
        private System.Windows.Forms.ColumnHeader TotalHeader;
        private System.Windows.Forms.ComboBox RecipesBox;
        private System.Windows.Forms.Button GetRecipeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CitiesBox;
    }
}


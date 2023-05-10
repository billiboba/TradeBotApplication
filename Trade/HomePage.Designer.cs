namespace Trade
{
    partial class HomePage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveInstrumentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.DeleteDb = new System.Windows.Forms.Button();
            this.ViewDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveInstrumentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(93, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(715, 446);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load DB";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteDb
            // 
            this.DeleteDb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DeleteDb.Location = new System.Drawing.Point(12, 122);
            this.DeleteDb.Name = "DeleteDb";
            this.DeleteDb.Size = new System.Drawing.Size(75, 23);
            this.DeleteDb.TabIndex = 2;
            this.DeleteDb.Text = "Delete DB";
            this.DeleteDb.UseVisualStyleBackColor = false;
            this.DeleteDb.Click += new System.EventHandler(this.DeleteDb_Click);
            // 
            // ViewDb
            // 
            this.ViewDb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ViewDb.Location = new System.Drawing.Point(12, 68);
            this.ViewDb.Name = "ViewDb";
            this.ViewDb.Size = new System.Drawing.Size(75, 23);
            this.ViewDb.TabIndex = 3;
            this.ViewDb.Text = "View DB";
            this.ViewDb.UseVisualStyleBackColor = false;
            this.ViewDb.Click += new System.EventHandler(this.ViewDb_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(811, 450);
            this.Controls.Add(this.ViewDb);
            this.Controls.Add(this.DeleteDb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "HomePage";
            this.Text = "HomePage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveInstrumentsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource saveInstrumentsBindingSource;
        private Button button1;
        private Button DeleteDb;
        private Button ViewDb;
    }
}
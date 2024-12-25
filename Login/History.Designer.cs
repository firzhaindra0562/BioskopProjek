namespace Login
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.lvwHistory = new System.Windows.Forms.ListView();
            this.btnHapus = new System.Windows.Forms.Button();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwHistory
            // 
            this.lvwHistory.HideSelection = false;
            this.lvwHistory.Location = new System.Drawing.Point(65, 340);
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size(1376, 491);
            this.lvwHistory.TabIndex = 0;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            this.lvwHistory.SelectedIndexChanged += new System.EventHandler(this.lvwHistory_SelectedIndexChanged);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Transparent;
            this.btnHapus.BackgroundImage = global::Login.Properties.Resources.Artboard_18;
            this.btnHapus.Font = new System.Drawing.Font("Segoe UI Black", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Location = new System.Drawing.Point(65, 868);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(158, 41);
            this.btnHapus.TabIndex = 22;
            this.btnHapus.Text = "HAPUS USER";
            this.btnHapus.UseVisualStyleBackColor = false;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(291, 278);
            this.txtNama.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(985, 26);
            this.txtNama.TabIndex = 24;
            this.txtNama.TextChanged += new System.EventHandler(this.txtNama_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(61, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "SEACRH HISTORY";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = global::Login.Properties.Resources.Artboard_18;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Black", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1287, 266);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(158, 41);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "SEARCH USER";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Login.Properties.Resources.p2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1517, 968);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lvwHistory);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "History";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwHistory;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
    }
}
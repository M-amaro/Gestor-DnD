namespace Gestor_DnD
{
    partial class F_principal
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
            this.CharacterDG = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterDG)).BeginInit();
            this.SuspendLayout();
            // 
            // CharacterDG
            // 
            this.CharacterDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CharacterDG.Location = new System.Drawing.Point(239, 31);
            this.CharacterDG.Name = "CharacterDG";
            this.CharacterDG.Size = new System.Drawing.Size(501, 261);
            this.CharacterDG.TabIndex = 0;
            this.CharacterDG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CharacterDG_CellContentClick);
            // 
            // F_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CharacterDG);
            this.Name = "F_principal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.F_principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CharacterDG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CharacterDG;
    }
}


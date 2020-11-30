namespace GiocoDadiApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.bgw_nord = new System.ComponentModel.BackgroundWorker();
            this.bgw_est = new System.ComponentModel.BackgroundWorker();
            this.bgw_sud = new System.ComponentModel.BackgroundWorker();
            this.bgw_ovest = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // bgw_nord
            // 
            this.bgw_nord.WorkerReportsProgress = true;
            this.bgw_nord.WorkerSupportsCancellation = true;
            this.bgw_nord.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.bgw_nord.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.bgw_nord.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgw_nord;
        private System.ComponentModel.BackgroundWorker bgw_est;
        private System.ComponentModel.BackgroundWorker bgw_sud;
        private System.ComponentModel.BackgroundWorker bgw_ovest;
    }
}


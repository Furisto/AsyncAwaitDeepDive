namespace Internals.SynchronizationContext
{
    partial class Form1
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
            this.Await = new System.Windows.Forms.Button();
            this.Wait = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Await
            // 
            this.Await.Location = new System.Drawing.Point(100, 74);
            this.Await.Name = "Await";
            this.Await.Size = new System.Drawing.Size(75, 23);
            this.Await.TabIndex = 0;
            this.Await.Text = "Await";
            this.Await.UseVisualStyleBackColor = true;
            this.Await.Click += new System.EventHandler(this.OnAwaitButtonClicked);
            // 
            // Wait
            // 
            this.Wait.Location = new System.Drawing.Point(100, 150);
            this.Wait.Name = "Wait";
            this.Wait.Size = new System.Drawing.Size(75, 23);
            this.Wait.TabIndex = 1;
            this.Wait.Text = "Wait";
            this.Wait.UseVisualStyleBackColor = true;
            this.Wait.Click += new System.EventHandler(this.OnWaitButtonClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Wait);
            this.Controls.Add(this.Await);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Await;
        private System.Windows.Forms.Button Wait;
    }
}


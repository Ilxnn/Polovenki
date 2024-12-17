namespace Polovenki
{
    partial class UserControl2
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            this.customPanel1 = new Polovenki.CustomPanel();
            this.SuspendLayout();
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(73)))), ((int)(((byte)(185)))));
            this.customPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customPanel1.BackgroundImage")));
            this.customPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.customPanel1.BorderFocusColor = System.Drawing.Color.Transparent;
            this.customPanel1.BorderRadius = 13;
            this.customPanel1.BorderSize = 2;
            this.customPanel1.Location = new System.Drawing.Point(0, 0);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(115, 30);
            this.customPanel1.TabIndex = 9;
            this.customPanel1.UnderlinedStyle = false;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customPanel1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(115, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPanel customPanel1;
    }
}

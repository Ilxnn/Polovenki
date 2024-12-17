namespace Polovenki
{
    partial class findForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(findForm));
            this.btn_messenger = new System.Windows.Forms.Button();
            this.btn_profile = new System.Windows.Forms.Button();
            this.guideBanner = new System.Windows.Forms.Panel();
            this.btn_guide_no = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_guide_yes = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PhotoPanel = new Polovenki.CustomPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.city_text = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.hobby_text = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.name_age_text = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btn_dislike = new System.Windows.Forms.Button();
            this.btn_like = new System.Windows.Forms.Button();
            this.guideBanner.SuspendLayout();
            this.PhotoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_messenger
            // 
            this.btn_messenger.BackColor = System.Drawing.Color.Transparent;
            this.btn_messenger.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_messenger.BackgroundImage")));
            this.btn_messenger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_messenger.FlatAppearance.BorderSize = 0;
            this.btn_messenger.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_messenger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_messenger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_messenger.Location = new System.Drawing.Point(21, 624);
            this.btn_messenger.Name = "btn_messenger";
            this.btn_messenger.Size = new System.Drawing.Size(60, 60);
            this.btn_messenger.TabIndex = 4;
            this.btn_messenger.UseVisualStyleBackColor = false;
            this.btn_messenger.Click += new System.EventHandler(this.btn_messenger_Click);
            // 
            // btn_profile
            // 
            this.btn_profile.BackColor = System.Drawing.Color.Transparent;
            this.btn_profile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_profile.BackgroundImage")));
            this.btn_profile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_profile.FlatAppearance.BorderSize = 0;
            this.btn_profile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_profile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_profile.Location = new System.Drawing.Point(1215, 624);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Size = new System.Drawing.Size(60, 60);
            this.btn_profile.TabIndex = 5;
            this.btn_profile.UseVisualStyleBackColor = false;
            this.btn_profile.Click += new System.EventHandler(this.btn_profile_Click);
            // 
            // guideBanner
            // 
            this.guideBanner.BackColor = System.Drawing.Color.Transparent;
            this.guideBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guideBanner.BackgroundImage")));
            this.guideBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guideBanner.Controls.Add(this.btn_guide_no);
            this.guideBanner.Controls.Add(this.btn_guide_yes);
            this.guideBanner.Location = new System.Drawing.Point(36, 43);
            this.guideBanner.Name = "guideBanner";
            this.guideBanner.Size = new System.Drawing.Size(200, 100);
            this.guideBanner.TabIndex = 8;
            this.guideBanner.Visible = false;
            // 
            // btn_guide_no
            // 
            this.btn_guide_no.Location = new System.Drawing.Point(661, 415);
            this.btn_guide_no.Name = "btn_guide_no";
            this.btn_guide_no.OverrideDefault.Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_guide_no.OverrideDefault.Back.Image")));
            this.btn_guide_no.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btn_guide_no.Size = new System.Drawing.Size(275, 50);
            this.btn_guide_no.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.btn_guide_no.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.btn_guide_no.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_guide_no.StateCommon.Back.Image")));
            this.btn_guide_no.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.btn_guide_no.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.btn_guide_no.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(180)))), ((int)(((byte)(236)))));
            this.btn_guide_no.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(90)))), ((int)(((byte)(196)))));
            this.btn_guide_no.StateCommon.Border.ColorAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Form;
            this.btn_guide_no.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding3;
            this.btn_guide_no.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btn_guide_no.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_guide_no.StateCommon.Border.Rounding = 13;
            this.btn_guide_no.StateCommon.Border.Width = 2;
            this.btn_guide_no.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_guide_no.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_guide_no.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Montserrat SemiBold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_guide_no.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btn_guide_no.TabIndex = 6;
            this.btn_guide_no.Values.Image = ((System.Drawing.Image)(resources.GetObject("btn_guide_no.Values.Image")));
            this.btn_guide_no.Values.Text = "Нет";
            this.btn_guide_no.Click += new System.EventHandler(this.btn_guide_no_Click);
            // 
            // btn_guide_yes
            // 
            this.btn_guide_yes.Location = new System.Drawing.Point(343, 415);
            this.btn_guide_yes.Name = "btn_guide_yes";
            this.btn_guide_yes.OverrideDefault.Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_guide_yes.OverrideDefault.Back.Image")));
            this.btn_guide_yes.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btn_guide_yes.Size = new System.Drawing.Size(275, 50);
            this.btn_guide_yes.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.btn_guide_yes.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.btn_guide_yes.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_guide_yes.StateCommon.Back.Image")));
            this.btn_guide_yes.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.btn_guide_yes.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.btn_guide_yes.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(180)))), ((int)(((byte)(236)))));
            this.btn_guide_yes.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(90)))), ((int)(((byte)(196)))));
            this.btn_guide_yes.StateCommon.Border.ColorAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Form;
            this.btn_guide_yes.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounding3;
            this.btn_guide_yes.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btn_guide_yes.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_guide_yes.StateCommon.Border.Rounding = 13;
            this.btn_guide_yes.StateCommon.Border.Width = 2;
            this.btn_guide_yes.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_guide_yes.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_guide_yes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Montserrat SemiBold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_guide_yes.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btn_guide_yes.TabIndex = 5;
            this.btn_guide_yes.Values.Image = ((System.Drawing.Image)(resources.GetObject("btn_guide_yes.Values.Image")));
            this.btn_guide_yes.Values.Text = "Да";
            this.btn_guide_yes.Click += new System.EventHandler(this.btn_guide_yes_Click);
            // 
            // PhotoPanel
            // 
            this.PhotoPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PhotoPanel.BackgroundImage")));
            this.PhotoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PhotoPanel.BorderColor = System.Drawing.Color.Transparent;
            this.PhotoPanel.BorderFocusColor = System.Drawing.Color.Transparent;
            this.PhotoPanel.BorderRadius = 15;
            this.PhotoPanel.BorderSize = 1;
            this.PhotoPanel.Controls.Add(this.pictureBox1);
            this.PhotoPanel.Controls.Add(this.city_text);
            this.PhotoPanel.Controls.Add(this.hobby_text);
            this.PhotoPanel.Controls.Add(this.name_age_text);
            this.PhotoPanel.Controls.Add(this.btn_dislike);
            this.PhotoPanel.Controls.Add(this.btn_like);
            this.PhotoPanel.Location = new System.Drawing.Point(393, 87);
            this.PhotoPanel.Name = "PhotoPanel";
            this.PhotoPanel.Size = new System.Drawing.Size(500, 500);
            this.PhotoPanel.TabIndex = 7;
            this.PhotoPanel.UnderlinedStyle = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(5, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // city_text
            // 
            this.city_text.Location = new System.Drawing.Point(31, 8);
            this.city_text.Name = "city_text";
            this.city_text.Size = new System.Drawing.Size(61, 30);
            this.city_text.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.city_text.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.city_text.StateCommon.ShortText.Font = new System.Drawing.Font("Montserrat", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.city_text.TabIndex = 11;
            this.city_text.Values.Text = "0 км";
            // 
            // hobby_text
            // 
            this.hobby_text.Location = new System.Drawing.Point(40, 347);
            this.hobby_text.Name = "hobby_text";
            this.hobby_text.Size = new System.Drawing.Size(229, 32);
            this.hobby_text.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.hobby_text.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.hobby_text.StateCommon.ShortText.Font = new System.Drawing.Font("Montserrat Medium", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.hobby_text.TabIndex = 10;
            this.hobby_text.Values.Text = "Увлечения, хобби";
            // 
            // name_age_text
            // 
            this.name_age_text.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.name_age_text.Location = new System.Drawing.Point(186, 408);
            this.name_age_text.Name = "name_age_text";
            this.name_age_text.Size = new System.Drawing.Size(133, 36);
            this.name_age_text.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.name_age_text.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.name_age_text.StateCommon.ShortText.Font = new System.Drawing.Font("Montserrat", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.name_age_text.TabIndex = 8;
            this.name_age_text.Values.Text = "Даша, 18";
            // 
            // btn_dislike
            // 
            this.btn_dislike.BackColor = System.Drawing.Color.Transparent;
            this.btn_dislike.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_dislike.BackgroundImage")));
            this.btn_dislike.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_dislike.FlatAppearance.BorderSize = 0;
            this.btn_dislike.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_dislike.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_dislike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dislike.Location = new System.Drawing.Point(385, 385);
            this.btn_dislike.Name = "btn_dislike";
            this.btn_dislike.Size = new System.Drawing.Size(75, 75);
            this.btn_dislike.TabIndex = 9;
            this.btn_dislike.UseVisualStyleBackColor = false;
            this.btn_dislike.Click += new System.EventHandler(this.btn_dislike_Click);
            // 
            // btn_like
            // 
            this.btn_like.BackColor = System.Drawing.Color.Transparent;
            this.btn_like.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_like.BackgroundImage")));
            this.btn_like.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_like.FlatAppearance.BorderSize = 0;
            this.btn_like.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_like.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_like.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_like.Location = new System.Drawing.Point(40, 385);
            this.btn_like.Name = "btn_like";
            this.btn_like.Size = new System.Drawing.Size(75, 75);
            this.btn_like.TabIndex = 8;
            this.btn_like.UseVisualStyleBackColor = false;
            this.btn_like.Click += new System.EventHandler(this.btn_like_Click);
            // 
            // findForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1296, 696);
            this.Controls.Add(this.guideBanner);
            this.Controls.Add(this.PhotoPanel);
            this.Controls.Add(this.btn_profile);
            this.Controls.Add(this.btn_messenger);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "findForm";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.findForm_Load);
            this.Shown += new System.EventHandler(this.findForm_Shown);
            this.guideBanner.ResumeLayout(false);
            this.PhotoPanel.ResumeLayout(false);
            this.PhotoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_messenger;
        private System.Windows.Forms.Button btn_profile;
        private CustomPanel PhotoPanel;
        private System.Windows.Forms.Button btn_dislike;
        private System.Windows.Forms.Button btn_like;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel name_age_text;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel city_text;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel hobby_text;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel guideBanner;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_guide_no;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_guide_yes;
    }
}
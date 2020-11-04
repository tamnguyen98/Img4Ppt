namespace Windows_Form_Solution
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
            this.components = new System.ComponentModel.Container();
            this.TitleInput = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BodyText = new System.Windows.Forms.RichTextBox();
            this.imgListView = new System.Windows.Forms.ListView();
            this.searchImgButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.body = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.generate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleInput
            // 
            this.TitleInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleInput.Location = new System.Drawing.Point(200, 25);
            this.TitleInput.Name = "TitleInput";
            this.TitleInput.Size = new System.Drawing.Size(409, 20);
            this.TitleInput.TabIndex = 0;
            this.TitleInput.Text = "Enter Title";
            this.TitleInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TitleInput.Enter += new System.EventHandler(this.TitleInput_Enter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // BodyText
            // 
            this.BodyText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BodyText.Location = new System.Drawing.Point(200, 91);
            this.BodyText.Name = "BodyText";
            this.BodyText.Size = new System.Drawing.Size(409, 140);
            this.BodyText.TabIndex = 3;
            this.BodyText.Text = "Enter slide\'s body";
            this.BodyText.Enter += new System.EventHandler(this.BodyText_Enter);
            // 
            // imgListView
            // 
            this.imgListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.imgListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgListView.CheckBoxes = true;
            this.imgListView.HideSelection = false;
            this.imgListView.Location = new System.Drawing.Point(12, 277);
            this.imgListView.Name = "imgListView";
            this.imgListView.Size = new System.Drawing.Size(776, 121);
            this.imgListView.TabIndex = 4;
            this.imgListView.UseCompatibleStateImageBehavior = false;
            this.imgListView.SelectedIndexChanged += new System.EventHandler(this.imgListView_SelectedIndexChanged);
            this.imgListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imgListView_MouseDoubleClick);
            // 
            // searchImgButton
            // 
            this.searchImgButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchImgButton.Location = new System.Drawing.Point(12, 248);
            this.searchImgButton.Name = "searchImgButton";
            this.searchImgButton.Size = new System.Drawing.Size(111, 23);
            this.searchImgButton.TabIndex = 5;
            this.searchImgButton.Text = "Suggest Images";
            this.searchImgButton.UseVisualStyleBackColor = true;
            this.searchImgButton.Click += new System.EventHandler(this.searchImgButton_Click);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(387, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(27, 13);
            this.title.TabIndex = 6;
            this.title.Text = "Title";
            // 
            // body
            // 
            this.body.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.body.AutoSize = true;
            this.body.Location = new System.Drawing.Point(387, 75);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(31, 13);
            this.body.TabIndex = 7;
            this.body.Text = "Body";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Use ctrl+b on the keyboard to switch between regular and bold fonts.";
            // 
            // generate
            // 
            this.generate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.generate.Location = new System.Drawing.Point(320, 439);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(133, 23);
            this.generate.TabIndex = 12;
            this.generate.Text = "Generate PPT";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.body);
            this.Controls.Add(this.title);
            this.Controls.Add(this.searchImgButton);
            this.Controls.Add(this.imgListView);
            this.Controls.Add(this.BodyText);
            this.Controls.Add(this.TitleInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Img4Ppt";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TitleInput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox BodyText;
        private System.Windows.Forms.ListView imgListView;
        private System.Windows.Forms.Button searchImgButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label body;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generate;
    }
}


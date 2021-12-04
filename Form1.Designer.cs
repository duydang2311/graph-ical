
namespace graphical
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.helpPanel = new System.Windows.Forms.Panel();
			this.helpLabel = new System.Windows.Forms.Label();
			this.labelAuthor = new System.Windows.Forms.Label();
			this.labelGraphical = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.helpPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.White;
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Location = new System.Drawing.Point(235, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(709, 601);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// helpPanel
			// 
			this.helpPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.helpPanel.Controls.Add(this.helpLabel);
			this.helpPanel.Controls.Add(this.labelAuthor);
			this.helpPanel.Controls.Add(this.labelGraphical);
			this.helpPanel.Controls.Add(this.pictureBox1);
			this.helpPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.helpPanel.Location = new System.Drawing.Point(0, 0);
			this.helpPanel.Name = "helpPanel";
			this.helpPanel.Size = new System.Drawing.Size(235, 601);
			this.helpPanel.TabIndex = 1;
			// 
			// helpLabel
			// 
			this.helpLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.helpLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.helpLabel.Location = new System.Drawing.Point(3, 218);
			this.helpLabel.Name = "helpLabel";
			this.helpLabel.Size = new System.Drawing.Size(229, 200);
			this.helpLabel.TabIndex = 3;
			this.helpLabel.Text = "F1─About\r\n__________________\r\nCTRL─Enter select state\r\n__________________\r\nLMB─Cr" +
    "eate, adjust vertex, edge, loop\r\n__________________\r\nRMB─Delete vertex, edge, lo" +
    "op";
			this.helpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelAuthor
			// 
			this.labelAuthor.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelAuthor.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.labelAuthor.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.labelAuthor.Location = new System.Drawing.Point(0, 543);
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Size = new System.Drawing.Size(235, 58);
			this.labelAuthor.TabIndex = 2;
			this.labelAuthor.Text = "Authors\r\nDang Quoc Duy\r\nNgo Nguyen Quoc Anh\r\nAssisted by Assoc. Prof. Hoang Van D" +
    "ung";
			this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelGraphical
			// 
			this.labelGraphical.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.labelGraphical.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.labelGraphical.Location = new System.Drawing.Point(3, 177);
			this.labelGraphical.Name = "labelGraphical";
			this.labelGraphical.Size = new System.Drawing.Size(229, 29);
			this.labelGraphical.TabIndex = 1;
			this.labelGraphical.Text = "graph-ical";
			this.labelGraphical.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pictureBox1.BackgroundImage = global::graphical.Properties.Resources.hcmute_logo;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(229, 171);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(944, 601);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.helpPanel);
			this.MinimumSize = new System.Drawing.Size(960, 640);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "graph-ical";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.helpPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Panel helpPanel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label labelGraphical;
		private System.Windows.Forms.Label labelAuthor;
		private System.Windows.Forms.Label helpLabel;
	}
}


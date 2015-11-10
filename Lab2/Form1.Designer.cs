namespace Lab2
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
			this.rbTest = new System.Windows.Forms.RadioButton();
			this.rbTask211 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbGZ = new System.Windows.Forms.RadioButton();
			this.rbHJ = new System.Windows.Forms.RadioButton();
			this.btnCalc = new System.Windows.Forms.Button();
			this.txtOut = new System.Windows.Forms.TextBox();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtX0X = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtX0Y = new System.Windows.Forms.TextBox();
			this.txtHY = new System.Windows.Forms.TextBox();
			this.txtHX = new System.Windows.Forms.TextBox();
			this.txtEps = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// rbTest
			// 
			this.rbTest.AutoSize = true;
			this.rbTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.rbTest.Checked = true;
			this.rbTest.Location = new System.Drawing.Point(14, 26);
			this.rbTest.Name = "rbTest";
			this.rbTest.Size = new System.Drawing.Size(14, 13);
			this.rbTest.TabIndex = 0;
			this.rbTest.TabStop = true;
			this.rbTest.UseVisualStyleBackColor = true;
			// 
			// rbTask211
			// 
			this.rbTask211.AutoSize = true;
			this.rbTask211.Location = new System.Drawing.Point(14, 58);
			this.rbTask211.Name = "rbTask211";
			this.rbTask211.Size = new System.Drawing.Size(14, 13);
			this.rbTask211.TabIndex = 1;
			this.rbTask211.TabStop = true;
			this.rbTask211.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pictureBox2);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.rbTask211);
			this.groupBox1.Controls.Add(this.rbTest);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(340, 81);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Функция";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::Lab2.Properties.Resources.test_task;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Location = new System.Drawing.Point(34, 19);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(295, 20);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::Lab2.Properties.Resources.task_211;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox2.Location = new System.Drawing.Point(34, 51);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(295, 20);
			this.pictureBox2.TabIndex = 3;
			this.pictureBox2.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbHJ);
			this.groupBox2.Controls.Add(this.rbGZ);
			this.groupBox2.Location = new System.Drawing.Point(13, 101);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(340, 69);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Метод";
			// 
			// rbGZ
			// 
			this.rbGZ.AutoSize = true;
			this.rbGZ.Checked = true;
			this.rbGZ.Location = new System.Drawing.Point(14, 20);
			this.rbGZ.Name = "rbGZ";
			this.rbGZ.Size = new System.Drawing.Size(112, 17);
			this.rbGZ.TabIndex = 0;
			this.rbGZ.TabStop = true;
			this.rbGZ.Text = "Гаусса - Зейделя";
			this.rbGZ.UseVisualStyleBackColor = true;
			// 
			// rbHJ
			// 
			this.rbHJ.AutoSize = true;
			this.rbHJ.Location = new System.Drawing.Point(14, 43);
			this.rbHJ.Name = "rbHJ";
			this.rbHJ.Size = new System.Drawing.Size(93, 17);
			this.rbHJ.TabIndex = 1;
			this.rbHJ.TabStop = true;
			this.rbHJ.Text = "Хука-Дживса";
			this.rbHJ.UseVisualStyleBackColor = true;
			// 
			// btnCalc
			// 
			this.btnCalc.Location = new System.Drawing.Point(12, 297);
			this.btnCalc.Name = "btnCalc";
			this.btnCalc.Size = new System.Drawing.Size(161, 20);
			this.btnCalc.TabIndex = 4;
			this.btnCalc.Text = "Минимизировать";
			this.btnCalc.UseVisualStyleBackColor = true;
			this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
			// 
			// txtOut
			// 
			this.txtOut.Location = new System.Drawing.Point(182, 297);
			this.txtOut.Name = "txtOut";
			this.txtOut.ReadOnly = true;
			this.txtOut.Size = new System.Drawing.Size(172, 20);
			this.txtOut.TabIndex = 5;
			// 
			// txtLog
			// 
			this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLog.Location = new System.Drawing.Point(360, 23);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLog.Size = new System.Drawing.Size(570, 295);
			this.txtLog.TabIndex = 6;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtEps);
			this.groupBox3.Controls.Add(this.txtHY);
			this.groupBox3.Controls.Add(this.txtHX);
			this.groupBox3.Controls.Add(this.txtX0Y);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.txtX0X);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(13, 177);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(340, 114);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Параметры";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Начальное приближение";
			// 
			// txtX0X
			// 
			this.txtX0X.Location = new System.Drawing.Point(169, 23);
			this.txtX0X.Name = "txtX0X";
			this.txtX0X.Size = new System.Drawing.Size(77, 20);
			this.txtX0X.TabIndex = 1;
			this.txtX0X.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Начальный шаг";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Точность";
			// 
			// txtX0Y
			// 
			this.txtX0Y.Location = new System.Drawing.Point(252, 23);
			this.txtX0Y.Name = "txtX0Y";
			this.txtX0Y.Size = new System.Drawing.Size(77, 20);
			this.txtX0Y.TabIndex = 4;
			this.txtX0Y.Text = "0";
			// 
			// txtHY
			// 
			this.txtHY.Location = new System.Drawing.Point(252, 49);
			this.txtHY.Name = "txtHY";
			this.txtHY.Size = new System.Drawing.Size(77, 20);
			this.txtHY.TabIndex = 6;
			this.txtHY.Text = "1";
			// 
			// txtHX
			// 
			this.txtHX.Location = new System.Drawing.Point(169, 49);
			this.txtHX.Name = "txtHX";
			this.txtHX.Size = new System.Drawing.Size(77, 20);
			this.txtHX.TabIndex = 5;
			this.txtHX.Text = "1";
			// 
			// txtEps
			// 
			this.txtEps.Location = new System.Drawing.Point(169, 75);
			this.txtEps.Name = "txtEps";
			this.txtEps.Size = new System.Drawing.Size(160, 20);
			this.txtEps.TabIndex = 7;
			this.txtEps.Text = "0,1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(942, 336);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.txtOut);
			this.Controls.Add(this.btnCalc);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rbTest;
		private System.Windows.Forms.RadioButton rbTask211;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbHJ;
		private System.Windows.Forms.RadioButton rbGZ;
		private System.Windows.Forms.Button btnCalc;
		private System.Windows.Forms.TextBox txtOut;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtX0X;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEps;
		private System.Windows.Forms.TextBox txtHY;
		private System.Windows.Forms.TextBox txtHX;
		private System.Windows.Forms.TextBox txtX0Y;
		private System.Windows.Forms.Label label3;
	}
}


namespace GenClass
{
    partial class frmmain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btng = new System.Windows.Forms.Button();
            this.txbconstr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnJpa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btng
            // 
            this.btng.Location = new System.Drawing.Point(566, 258);
            this.btng.Margin = new System.Windows.Forms.Padding(4);
            this.btng.Name = "btng";
            this.btng.Size = new System.Drawing.Size(147, 29);
            this.btng.TabIndex = 0;
            this.btng.Text = "生成Android类";
            this.btng.UseVisualStyleBackColor = true;
            this.btng.Click += new System.EventHandler(this.btng_Click);
            // 
            // txbconstr
            // 
            this.txbconstr.Location = new System.Drawing.Point(132, 15);
            this.txbconstr.Margin = new System.Windows.Forms.Padding(4);
            this.txbconstr.Name = "txbconstr";
            this.txbconstr.Size = new System.Drawing.Size(581, 25);
            this.txbconstr.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "连接字符串:";
            // 
            // btnJpa
            // 
            this.btnJpa.Location = new System.Drawing.Point(390, 258);
            this.btnJpa.Name = "btnJpa";
            this.btnJpa.Size = new System.Drawing.Size(152, 29);
            this.btnJpa.TabIndex = 3;
            this.btnJpa.Text = "生成JavaJPA类";
            this.btnJpa.UseVisualStyleBackColor = true;
            this.btnJpa.Click += new System.EventHandler(this.btnJpa_Click);
            // 
            // frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 301);
            this.Controls.Add(this.btnJpa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbconstr);
            this.Controls.Add(this.btng);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmmain";
            this.Text = "生成类";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btng;
        private System.Windows.Forms.TextBox txbconstr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnJpa;
    }
}


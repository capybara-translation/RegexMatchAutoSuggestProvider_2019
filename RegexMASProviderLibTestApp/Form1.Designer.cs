namespace RegexMASProviderLibTestApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tblRoot = new System.Windows.Forms.TableLayoutPanel();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.popupWindow = new RegexMASProviderLib.View.EvaluationPopupWindow();
            this.regexDgv = new RegexMASProviderLib.View.RegexDataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnShowRegexTester = new System.Windows.Forms.Button();
            this.tblRoot.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblRoot
            // 
            this.tblRoot.ColumnCount = 2;
            this.tblRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblRoot.Controls.Add(this.popupWindow, 0, 1);
            this.tblRoot.Controls.Add(this.txtSource, 0, 2);
            this.tblRoot.Controls.Add(this.regexDgv, 0, 0);
            this.tblRoot.Controls.Add(this.tableLayoutPanel1, 1, 2);
            this.tblRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRoot.Location = new System.Drawing.Point(0, 0);
            this.tblRoot.Name = "tblRoot";
            this.tblRoot.RowCount = 3;
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblRoot.Size = new System.Drawing.Size(1088, 1144);
            this.tblRoot.TabIndex = 0;
            // 
            // txtSource
            // 
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.Location = new System.Drawing.Point(3, 861);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(876, 280);
            this.txtSource.TabIndex = 2;
            // 
            // popupWindow
            // 
            this.tblRoot.SetColumnSpan(this.popupWindow, 2);
            this.popupWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupWindow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupWindow.Location = new System.Drawing.Point(3, 290);
            this.popupWindow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.popupWindow.Name = "popupWindow";
            this.popupWindow.Size = new System.Drawing.Size(1082, 564);
            this.popupWindow.TabIndex = 0;
            // 
            // regexDgv
            // 
            this.tblRoot.SetColumnSpan(this.regexDgv, 2);
            this.regexDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regexDgv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regexDgv.Location = new System.Drawing.Point(3, 4);
            this.regexDgv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.regexDgv.Name = "regexDgv";
            this.regexDgv.Size = new System.Drawing.Size(1082, 278);
            this.regexDgv.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnRun, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnShowRegexTester, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(885, 861);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 280);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRun.Location = new System.Drawing.Point(3, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(194, 134);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnShowRegexTester
            // 
            this.btnShowRegexTester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowRegexTester.Location = new System.Drawing.Point(3, 143);
            this.btnShowRegexTester.Name = "btnShowRegexTester";
            this.btnShowRegexTester.Size = new System.Drawing.Size(194, 134);
            this.btnShowRegexTester.TabIndex = 1;
            this.btnShowRegexTester.Text = "Show Regex Tester";
            this.btnShowRegexTester.UseVisualStyleBackColor = true;
            this.btnShowRegexTester.Click += new System.EventHandler(this.btnShowRegexTester_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 1144);
            this.Controls.Add(this.tblRoot);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tblRoot.ResumeLayout(false);
            this.tblRoot.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblRoot;
        private RegexMASProviderLib.View.EvaluationPopupWindow popupWindow;
        private System.Windows.Forms.TextBox txtSource;
        private RegexMASProviderLib.View.RegexDataGridView regexDgv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnShowRegexTester;
    }
}


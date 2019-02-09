namespace RegexMASProviderLib.View
{
    partial class EvaluationPopupWindow
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lstEntries = new System.Windows.Forms.ListBox();
            this.browserMain = new System.Windows.Forms.WebBrowser();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // lstEntries
            // 
            this.lstEntries.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstEntries.FormattingEnabled = true;
            this.lstEntries.ItemHeight = 25;
            this.lstEntries.Location = new System.Drawing.Point(0, 0);
            this.lstEntries.Name = "lstEntries";
            this.lstEntries.Size = new System.Drawing.Size(205, 672);
            this.lstEntries.TabIndex = 0;
            this.lstEntries.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectedIndexChanged);
            // 
            // browserMain
            // 
            this.browserMain.AllowNavigation = false;
            this.browserMain.AllowWebBrowserDrop = false;
            this.browserMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserMain.Location = new System.Drawing.Point(0, 0);
            this.browserMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserMain.Name = "browserMain";
            this.browserMain.Size = new System.Drawing.Size(938, 672);
            this.browserMain.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(205, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 672);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // EvaluationPopupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lstEntries);
            this.Controls.Add(this.browserMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EvaluationPopupWindow";
            this.Size = new System.Drawing.Size(938, 672);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstEntries;
        private System.Windows.Forms.WebBrowser browserMain;
        private System.Windows.Forms.Splitter splitter1;
    }
}

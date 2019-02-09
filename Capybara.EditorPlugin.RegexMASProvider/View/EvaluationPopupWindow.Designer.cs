namespace Capybara.EditorPlugin.RegexMASProvider.View
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstEntries
            // 
            this.lstEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEntries.FormattingEnabled = true;
            this.lstEntries.ItemHeight = 25;
            this.lstEntries.Location = new System.Drawing.Point(0, 0);
            this.lstEntries.Name = "lstEntries";
            this.lstEntries.Size = new System.Drawing.Size(302, 672);
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
            this.browserMain.Size = new System.Drawing.Size(630, 672);
            this.browserMain.TabIndex = 2;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lstEntries);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.browserMain);
            this.splitContainer.Size = new System.Drawing.Size(938, 672);
            this.splitContainer.SplitterDistance = 302;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 3;
            // 
            // EvaluationPopupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EvaluationPopupWindow";
            this.Size = new System.Drawing.Size(938, 672);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstEntries;
        private System.Windows.Forms.WebBrowser browserMain;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}

namespace Capybara.EditorPlugin.RegexMASProvider
{
    partial class PopupWindow
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.suggestionsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // suggestionsListBox
            // 
            this.suggestionsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suggestionsListBox.FormattingEnabled = true;
            this.suggestionsListBox.HorizontalScrollbar = true;
            this.suggestionsListBox.ItemHeight = 12;
            this.suggestionsListBox.Location = new System.Drawing.Point(0, 0);
            this.suggestionsListBox.Name = "suggestionsListBox";
            this.suggestionsListBox.Size = new System.Drawing.Size(219, 113);
            this.suggestionsListBox.TabIndex = 0;
            this.suggestionsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.suggestionsListBox_MouseDoubleClick);
            this.suggestionsListBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.suggestionsListBox_PreviewKeyDown);
            // 
            // PopupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.suggestionsListBox);
            this.Name = "PopupWindow";
            this.Size = new System.Drawing.Size(219, 113);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox suggestionsListBox;

    }
}

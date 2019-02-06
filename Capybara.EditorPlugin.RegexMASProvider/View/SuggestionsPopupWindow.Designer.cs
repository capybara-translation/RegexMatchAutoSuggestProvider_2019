namespace Capybara.EditorPlugin.RegexMASProvider.View
{
    partial class SuggestionsPopupWindow
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
            this.suggestionsListBox.ItemHeight = 18;
            this.suggestionsListBox.Location = new System.Drawing.Point(0, 0);
            this.suggestionsListBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.suggestionsListBox.Name = "suggestionsListBox";
            this.suggestionsListBox.Size = new System.Drawing.Size(365, 170);
            this.suggestionsListBox.TabIndex = 0;
            this.suggestionsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.suggestionsListBox_MouseDoubleClick);
            this.suggestionsListBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.suggestionsListBox_PreviewKeyDown);
            // 
            // SuggestionsPopupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.suggestionsListBox);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SuggestionsPopupWindow";
            this.Size = new System.Drawing.Size(365, 170);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox suggestionsListBox;

    }
}

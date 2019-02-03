namespace Capybara.EditorPlugin.RegexMASProvider
{
    partial class RegexMatchAutoSuggestProviderViewPartControl
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
            this.components = new System.ComponentModel.Container();
            this.regexPatternsDataGridView = new System.Windows.Forms.DataGridView();
            this.isEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regexPatternDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replacePatternDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regexPatternEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.regexEntriesPage = new System.Windows.Forms.TabPage();
            this.variablesPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.variablesDataGridView = new System.Windows.Forms.DataGridView();
            this.isEnabledDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.translationPairsDataGridView = new System.Windows.Forms.DataGridView();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.translationPairBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.regexPatternsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regexPatternEntryBindingSource)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.regexEntriesPage.SuspendLayout();
            this.variablesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variablesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationPairsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationPairBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // regexPatternsDataGridView
            // 
            this.regexPatternsDataGridView.AutoGenerateColumns = false;
            this.regexPatternsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.regexPatternsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.regexPatternsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isEnabledDataGridViewCheckBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.regexPatternDataGridViewTextBoxColumn,
            this.replacePatternDataGridViewTextBoxColumn});
            this.regexPatternsDataGridView.DataSource = this.regexPatternEntryBindingSource;
            this.regexPatternsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regexPatternsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.regexPatternsDataGridView.Name = "regexPatternsDataGridView";
            this.regexPatternsDataGridView.RowTemplate.Height = 21;
            this.regexPatternsDataGridView.Size = new System.Drawing.Size(789, 307);
            this.regexPatternsDataGridView.TabIndex = 0;
            this.regexPatternsDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.regexPatternsDataGridView_PreviewKeyDown);
            // 
            // isEnabledDataGridViewCheckBoxColumn
            // 
            this.isEnabledDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.isEnabledDataGridViewCheckBoxColumn.DataPropertyName = "IsEnabled";
            this.isEnabledDataGridViewCheckBoxColumn.Frozen = true;
            this.isEnabledDataGridViewCheckBoxColumn.HeaderText = "Enabled";
            this.isEnabledDataGridViewCheckBoxColumn.Name = "isEnabledDataGridViewCheckBoxColumn";
            this.isEnabledDataGridViewCheckBoxColumn.Width = 55;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // regexPatternDataGridViewTextBoxColumn
            // 
            this.regexPatternDataGridViewTextBoxColumn.DataPropertyName = "RegexPattern";
            this.regexPatternDataGridViewTextBoxColumn.HeaderText = "Regex Pattern";
            this.regexPatternDataGridViewTextBoxColumn.Name = "regexPatternDataGridViewTextBoxColumn";
            // 
            // replacePatternDataGridViewTextBoxColumn
            // 
            this.replacePatternDataGridViewTextBoxColumn.DataPropertyName = "ReplacePattern";
            this.replacePatternDataGridViewTextBoxColumn.HeaderText = "Replace Pattern";
            this.replacePatternDataGridViewTextBoxColumn.Name = "replacePatternDataGridViewTextBoxColumn";
            // 
            // regexPatternEntryBindingSource
            // 
            this.regexPatternEntryBindingSource.DataSource = typeof(Capybara.EditorPlugin.RegexMASProvider.Models.RegexPatternEntry);
            this.regexPatternEntryBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.regexPatternEntryBindingSource_AddingNew);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.regexEntriesPage);
            this.mainTabControl.Controls.Add(this.variablesPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(803, 341);
            this.mainTabControl.TabIndex = 1;
            // 
            // regexEntriesPage
            // 
            this.regexEntriesPage.Controls.Add(this.regexPatternsDataGridView);
            this.regexEntriesPage.Location = new System.Drawing.Point(4, 24);
            this.regexEntriesPage.Name = "regexEntriesPage";
            this.regexEntriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.regexEntriesPage.Size = new System.Drawing.Size(795, 313);
            this.regexEntriesPage.TabIndex = 0;
            this.regexEntriesPage.Text = "Regex Entries";
            this.regexEntriesPage.UseVisualStyleBackColor = true;
            // 
            // variablesPage
            // 
            this.variablesPage.Controls.Add(this.splitContainer1);
            this.variablesPage.Location = new System.Drawing.Point(4, 24);
            this.variablesPage.Name = "variablesPage";
            this.variablesPage.Padding = new System.Windows.Forms.Padding(3);
            this.variablesPage.Size = new System.Drawing.Size(795, 313);
            this.variablesPage.TabIndex = 1;
            this.variablesPage.Text = "Variables";
            this.variablesPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.variablesDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.translationPairsDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(789, 307);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 0;
            // 
            // variablesDataGridView
            // 
            this.variablesDataGridView.AutoGenerateColumns = false;
            this.variablesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.variablesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.variablesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isEnabledDataGridViewCheckBoxColumn1,
            this.nameDataGridViewTextBoxColumn});
            this.variablesDataGridView.DataSource = this.variableBindingSource;
            this.variablesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variablesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.variablesDataGridView.Name = "variablesDataGridView";
            this.variablesDataGridView.RowTemplate.Height = 21;
            this.variablesDataGridView.Size = new System.Drawing.Size(263, 307);
            this.variablesDataGridView.TabIndex = 0;
            this.variablesDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.variablesDataGridView_PreviewKeyDown);
            // 
            // isEnabledDataGridViewCheckBoxColumn1
            // 
            this.isEnabledDataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.isEnabledDataGridViewCheckBoxColumn1.DataPropertyName = "IsEnabled";
            this.isEnabledDataGridViewCheckBoxColumn1.Frozen = true;
            this.isEnabledDataGridViewCheckBoxColumn1.HeaderText = "Enabled";
            this.isEnabledDataGridViewCheckBoxColumn1.Name = "isEnabledDataGridViewCheckBoxColumn1";
            this.isEnabledDataGridViewCheckBoxColumn1.Width = 55;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // variableBindingSource
            // 
            this.variableBindingSource.DataSource = typeof(Capybara.EditorPlugin.RegexMASProvider.Models.Variable);
            this.variableBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.variableBindingSource_AddingNew);
            // 
            // translationPairsDataGridView
            // 
            this.translationPairsDataGridView.AutoGenerateColumns = false;
            this.translationPairsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.translationPairsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.translationPairsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sourceDataGridViewTextBoxColumn,
            this.targetDataGridViewTextBoxColumn});
            this.translationPairsDataGridView.DataSource = this.translationPairBindingSource;
            this.translationPairsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.translationPairsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.translationPairsDataGridView.Name = "translationPairsDataGridView";
            this.translationPairsDataGridView.RowTemplate.Height = 21;
            this.translationPairsDataGridView.Size = new System.Drawing.Size(522, 307);
            this.translationPairsDataGridView.TabIndex = 0;
            this.translationPairsDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.translationPairsDataGridView_PreviewKeyDown);
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            // 
            // targetDataGridViewTextBoxColumn
            // 
            this.targetDataGridViewTextBoxColumn.DataPropertyName = "Target";
            this.targetDataGridViewTextBoxColumn.HeaderText = "Target";
            this.targetDataGridViewTextBoxColumn.Name = "targetDataGridViewTextBoxColumn";
            // 
            // translationPairBindingSource
            // 
            this.translationPairBindingSource.DataSource = typeof(Capybara.EditorPlugin.RegexMASProvider.Models.TranslationPair);
            this.translationPairBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.translationPairBindingSource_AddingNew);
            // 
            // RegexMatchAutoSuggestProviderViewPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RegexMatchAutoSuggestProviderViewPartControl";
            this.Size = new System.Drawing.Size(803, 341);
            ((System.ComponentModel.ISupportInitialize)(this.regexPatternsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regexPatternEntryBindingSource)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.regexEntriesPage.ResumeLayout(false);
            this.variablesPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.variablesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationPairsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationPairBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView regexPatternsDataGridView;
        private System.Windows.Forms.BindingSource regexPatternEntryBindingSource;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage regexEntriesPage;
        private System.Windows.Forms.TabPage variablesPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView variablesDataGridView;
        private System.Windows.Forms.DataGridView translationPairsDataGridView;
        private System.Windows.Forms.BindingSource variableBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource translationPairBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regexPatternDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn replacePatternDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}

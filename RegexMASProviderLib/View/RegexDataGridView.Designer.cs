namespace RegexMASProviderLib.View
{
    partial class RegexDataGridView
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
            this.variablesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.variablesDataGridView = new System.Windows.Forms.DataGridView();
            this.isEnabledDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.translationPairsDataGridView = new System.Windows.Forms.DataGridView();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.translationPairBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.regexTesterPage = new System.Windows.Forms.TabPage();
            this.regexTesterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.regexTesterTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.regexTesterButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.testButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.evaluationPopupWindow = new RegexMASProviderLib.View.EvaluationPopupWindow();
            this.regexContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableSelectedRegexEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableSelectedRegexEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variableContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableSelectedVariableEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableSelectedVariableEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.regexPatternsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regexPatternEntryBindingSource)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.regexEntriesPage.SuspendLayout();
            this.variablesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variablesSplitContainer)).BeginInit();
            this.variablesSplitContainer.Panel1.SuspendLayout();
            this.variablesSplitContainer.Panel2.SuspendLayout();
            this.variablesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variablesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationPairsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationPairBindingSource)).BeginInit();
            this.regexTesterPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regexTesterSplitContainer)).BeginInit();
            this.regexTesterSplitContainer.Panel1.SuspendLayout();
            this.regexTesterSplitContainer.Panel2.SuspendLayout();
            this.regexTesterSplitContainer.SuspendLayout();
            this.regexTesterTableLayoutPanel.SuspendLayout();
            this.regexTesterButtonsTableLayoutPanel.SuspendLayout();
            this.regexContextMenuStrip.SuspendLayout();
            this.variableContextMenuStrip.SuspendLayout();
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
            this.regexPatternsDataGridView.Size = new System.Drawing.Size(1105, 554);
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
            this.isEnabledDataGridViewCheckBoxColumn.Width = 81;
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
            this.regexPatternEntryBindingSource.DataSource = typeof(RegexMASProviderLib.Models.RegexPatternEntry);
            this.regexPatternEntryBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.regexPatternEntryBindingSource_AddingNew);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.regexEntriesPage);
            this.mainTabControl.Controls.Add(this.variablesPage);
            this.mainTabControl.Controls.Add(this.regexTesterPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1119, 598);
            this.mainTabControl.TabIndex = 1;
            // 
            // regexEntriesPage
            // 
            this.regexEntriesPage.Controls.Add(this.regexPatternsDataGridView);
            this.regexEntriesPage.Location = new System.Drawing.Point(4, 34);
            this.regexEntriesPage.Name = "regexEntriesPage";
            this.regexEntriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.regexEntriesPage.Size = new System.Drawing.Size(1111, 560);
            this.regexEntriesPage.TabIndex = 0;
            this.regexEntriesPage.Text = "Regex Entries";
            this.regexEntriesPage.UseVisualStyleBackColor = true;
            // 
            // variablesPage
            // 
            this.variablesPage.Controls.Add(this.variablesSplitContainer);
            this.variablesPage.Location = new System.Drawing.Point(4, 34);
            this.variablesPage.Name = "variablesPage";
            this.variablesPage.Padding = new System.Windows.Forms.Padding(3);
            this.variablesPage.Size = new System.Drawing.Size(1111, 560);
            this.variablesPage.TabIndex = 1;
            this.variablesPage.Text = "Variables";
            this.variablesPage.UseVisualStyleBackColor = true;
            // 
            // variablesSplitContainer
            // 
            this.variablesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variablesSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.variablesSplitContainer.Name = "variablesSplitContainer";
            // 
            // variablesSplitContainer.Panel1
            // 
            this.variablesSplitContainer.Panel1.Controls.Add(this.variablesDataGridView);
            // 
            // variablesSplitContainer.Panel2
            // 
            this.variablesSplitContainer.Panel2.Controls.Add(this.translationPairsDataGridView);
            this.variablesSplitContainer.Size = new System.Drawing.Size(1105, 554);
            this.variablesSplitContainer.SplitterDistance = 368;
            this.variablesSplitContainer.TabIndex = 0;
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
            this.variablesDataGridView.Size = new System.Drawing.Size(368, 554);
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
            this.isEnabledDataGridViewCheckBoxColumn1.Width = 81;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // variableBindingSource
            // 
            this.variableBindingSource.DataSource = typeof(RegexMASProviderLib.Models.Variable);
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
            this.translationPairsDataGridView.Size = new System.Drawing.Size(733, 554);
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
            this.translationPairBindingSource.DataSource = typeof(RegexMASProviderLib.Models.TranslationPair);
            this.translationPairBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.translationPairBindingSource_AddingNew);
            // 
            // regexTesterPage
            // 
            this.regexTesterPage.Controls.Add(this.regexTesterSplitContainer);
            this.regexTesterPage.Location = new System.Drawing.Point(4, 34);
            this.regexTesterPage.Name = "regexTesterPage";
            this.regexTesterPage.Padding = new System.Windows.Forms.Padding(3);
            this.regexTesterPage.Size = new System.Drawing.Size(1111, 560);
            this.regexTesterPage.TabIndex = 2;
            this.regexTesterPage.Text = "Regex Tester";
            this.regexTesterPage.UseVisualStyleBackColor = true;
            // 
            // regexTesterSplitContainer
            // 
            this.regexTesterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regexTesterSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.regexTesterSplitContainer.Name = "regexTesterSplitContainer";
            this.regexTesterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // regexTesterSplitContainer.Panel1
            // 
            this.regexTesterSplitContainer.Panel1.Controls.Add(this.regexTesterTableLayoutPanel);
            // 
            // regexTesterSplitContainer.Panel2
            // 
            this.regexTesterSplitContainer.Panel2.Controls.Add(this.evaluationPopupWindow);
            this.regexTesterSplitContainer.Size = new System.Drawing.Size(1105, 554);
            this.regexTesterSplitContainer.SplitterDistance = 201;
            this.regexTesterSplitContainer.SplitterWidth = 8;
            this.regexTesterSplitContainer.TabIndex = 0;
            // 
            // regexTesterTableLayoutPanel
            // 
            this.regexTesterTableLayoutPanel.ColumnCount = 2;
            this.regexTesterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.regexTesterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.regexTesterTableLayoutPanel.Controls.Add(this.sourceTextBox, 0, 0);
            this.regexTesterTableLayoutPanel.Controls.Add(this.regexTesterButtonsTableLayoutPanel, 1, 0);
            this.regexTesterTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regexTesterTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.regexTesterTableLayoutPanel.Name = "regexTesterTableLayoutPanel";
            this.regexTesterTableLayoutPanel.RowCount = 1;
            this.regexTesterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.regexTesterTableLayoutPanel.Size = new System.Drawing.Size(1105, 201);
            this.regexTesterTableLayoutPanel.TabIndex = 0;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceTextBox.Location = new System.Drawing.Point(3, 3);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sourceTextBox.Size = new System.Drawing.Size(893, 195);
            this.sourceTextBox.TabIndex = 0;
            // 
            // regexTesterButtonsTableLayoutPanel
            // 
            this.regexTesterButtonsTableLayoutPanel.ColumnCount = 1;
            this.regexTesterButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.regexTesterButtonsTableLayoutPanel.Controls.Add(this.testButton, 0, 0);
            this.regexTesterButtonsTableLayoutPanel.Controls.Add(this.clearButton, 0, 1);
            this.regexTesterButtonsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regexTesterButtonsTableLayoutPanel.Location = new System.Drawing.Point(902, 3);
            this.regexTesterButtonsTableLayoutPanel.Name = "regexTesterButtonsTableLayoutPanel";
            this.regexTesterButtonsTableLayoutPanel.RowCount = 3;
            this.regexTesterButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.regexTesterButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.regexTesterButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.regexTesterButtonsTableLayoutPanel.Size = new System.Drawing.Size(200, 195);
            this.regexTesterButtonsTableLayoutPanel.TabIndex = 1;
            // 
            // testButton
            // 
            this.testButton.AutoSize = true;
            this.testButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testButton.Location = new System.Drawing.Point(3, 3);
            this.testButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(194, 35);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Location = new System.Drawing.Point(3, 51);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(194, 35);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // evaluationPopupWindow
            // 
            this.evaluationPopupWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluationPopupWindow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evaluationPopupWindow.Location = new System.Drawing.Point(0, 0);
            this.evaluationPopupWindow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.evaluationPopupWindow.Name = "evaluationPopupWindow";
            this.evaluationPopupWindow.Size = new System.Drawing.Size(1105, 345);
            this.evaluationPopupWindow.TabIndex = 0;
            // 
            // regexContextMenuStrip
            // 
            this.regexContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.regexContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableSelectedRegexEntriesToolStripMenuItem,
            this.disableSelectedRegexEntriesToolStripMenuItem});
            this.regexContextMenuStrip.Name = "regexContextMenuStrip";
            this.regexContextMenuStrip.Size = new System.Drawing.Size(269, 64);
            // 
            // enableSelectedRegexEntriesToolStripMenuItem
            // 
            this.enableSelectedRegexEntriesToolStripMenuItem.Name = "enableSelectedRegexEntriesToolStripMenuItem";
            this.enableSelectedRegexEntriesToolStripMenuItem.Size = new System.Drawing.Size(268, 30);
            this.enableSelectedRegexEntriesToolStripMenuItem.Tag = "";
            this.enableSelectedRegexEntriesToolStripMenuItem.Text = "Enable selected entries";
            this.enableSelectedRegexEntriesToolStripMenuItem.Click += new System.EventHandler(this.enableSelectedRegexEntriesToolStripMenuItem_Click);
            // 
            // disableSelectedRegexEntriesToolStripMenuItem
            // 
            this.disableSelectedRegexEntriesToolStripMenuItem.Name = "disableSelectedRegexEntriesToolStripMenuItem";
            this.disableSelectedRegexEntriesToolStripMenuItem.Size = new System.Drawing.Size(268, 30);
            this.disableSelectedRegexEntriesToolStripMenuItem.Tag = "";
            this.disableSelectedRegexEntriesToolStripMenuItem.Text = "Disable selected entries";
            this.disableSelectedRegexEntriesToolStripMenuItem.Click += new System.EventHandler(this.enableSelectedRegexEntriesToolStripMenuItem_Click);
            // 
            // variableContextMenuStrip
            // 
            this.variableContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.variableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableSelectedVariableEntriesToolStripMenuItem,
            this.disableSelectedVariableEntriesToolStripMenuItem});
            this.variableContextMenuStrip.Name = "variableContextMenuStrip";
            this.variableContextMenuStrip.Size = new System.Drawing.Size(269, 64);
            // 
            // enableSelectedVariableEntriesToolStripMenuItem
            // 
            this.enableSelectedVariableEntriesToolStripMenuItem.Name = "enableSelectedVariableEntriesToolStripMenuItem";
            this.enableSelectedVariableEntriesToolStripMenuItem.Size = new System.Drawing.Size(268, 30);
            this.enableSelectedVariableEntriesToolStripMenuItem.Text = "Enable selected entries";
            this.enableSelectedVariableEntriesToolStripMenuItem.Click += new System.EventHandler(this.enableSelectedVariableEntriesToolStripMenuItem_Click);
            // 
            // disableSelectedVariableEntriesToolStripMenuItem
            // 
            this.disableSelectedVariableEntriesToolStripMenuItem.Name = "disableSelectedVariableEntriesToolStripMenuItem";
            this.disableSelectedVariableEntriesToolStripMenuItem.Size = new System.Drawing.Size(268, 30);
            this.disableSelectedVariableEntriesToolStripMenuItem.Text = "Disable selected entries";
            this.disableSelectedVariableEntriesToolStripMenuItem.Click += new System.EventHandler(this.enableSelectedVariableEntriesToolStripMenuItem_Click);
            // 
            // RegexDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RegexDataGridView";
            this.Size = new System.Drawing.Size(1119, 598);
            ((System.ComponentModel.ISupportInitialize)(this.regexPatternsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regexPatternEntryBindingSource)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.regexEntriesPage.ResumeLayout(false);
            this.variablesPage.ResumeLayout(false);
            this.variablesSplitContainer.Panel1.ResumeLayout(false);
            this.variablesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.variablesSplitContainer)).EndInit();
            this.variablesSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.variablesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationPairsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationPairBindingSource)).EndInit();
            this.regexTesterPage.ResumeLayout(false);
            this.regexTesterSplitContainer.Panel1.ResumeLayout(false);
            this.regexTesterSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.regexTesterSplitContainer)).EndInit();
            this.regexTesterSplitContainer.ResumeLayout(false);
            this.regexTesterTableLayoutPanel.ResumeLayout(false);
            this.regexTesterTableLayoutPanel.PerformLayout();
            this.regexTesterButtonsTableLayoutPanel.ResumeLayout(false);
            this.regexTesterButtonsTableLayoutPanel.PerformLayout();
            this.regexContextMenuStrip.ResumeLayout(false);
            this.variableContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView regexPatternsDataGridView;
        private System.Windows.Forms.BindingSource regexPatternEntryBindingSource;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage regexEntriesPage;
        private System.Windows.Forms.TabPage variablesPage;
        private System.Windows.Forms.SplitContainer variablesSplitContainer;
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
        private System.Windows.Forms.TabPage regexTesterPage;
        private System.Windows.Forms.SplitContainer regexTesterSplitContainer;
        private System.Windows.Forms.TableLayoutPanel regexTesterTableLayoutPanel;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TableLayoutPanel regexTesterButtonsTableLayoutPanel;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button clearButton;
        private EvaluationPopupWindow evaluationPopupWindow;
        private System.Windows.Forms.ContextMenuStrip regexContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem enableSelectedRegexEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableSelectedRegexEntriesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip variableContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem enableSelectedVariableEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableSelectedVariableEntriesToolStripMenuItem;
    }
}

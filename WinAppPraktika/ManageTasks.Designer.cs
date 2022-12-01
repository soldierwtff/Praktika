
namespace WinAppPraktika
{
    partial class ManageTasks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gvTasks = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // gvTasks
            // 
            this.gvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTasks.Location = new System.Drawing.Point(12, 30);
            this.gvTasks.Name = "gvTasks";
            this.gvTasks.RowHeadersWidth = 51;
            this.gvTasks.RowTemplate.Height = 24;
            this.gvTasks.Size = new System.Drawing.Size(371, 199);
            this.gvTasks.TabIndex = 0;
            this.gvTasks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTasks_CellContentClick);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 266);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(118, 43);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add New Task";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(236, 266);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(115, 43);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit selected";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(466, 266);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(119, 43);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = " Delete selected";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(466, 44);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(134, 74);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh Listing";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ManageTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 364);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.gvTasks);
            this.Name = "ManageTasks";
            this.Text = "ManageTasks";
            this.Load += new System.EventHandler(this.ManageTasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvTasks;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button btnRefresh;
    }
}
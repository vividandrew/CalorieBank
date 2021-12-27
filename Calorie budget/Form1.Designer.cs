
namespace Calorie_budget
{
    partial class Form1
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
            this.btnDebug = new System.Windows.Forms.Button();
            this.lblCalorieBalance = new System.Windows.Forms.Label();
            this.txtAddDeficet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCalories = new System.Windows.Forms.Button();
            this.lblNotification = new System.Windows.Forms.Label();
            this.btnLibraryAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(12, 77);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(55, 36);
            this.btnDebug.TabIndex = 0;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Visible = false;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // lblCalorieBalance
            // 
            this.lblCalorieBalance.AutoSize = true;
            this.lblCalorieBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalorieBalance.Location = new System.Drawing.Point(12, 9);
            this.lblCalorieBalance.Name = "lblCalorieBalance";
            this.lblCalorieBalance.Size = new System.Drawing.Size(162, 25);
            this.lblCalorieBalance.TabIndex = 2;
            this.lblCalorieBalance.Text = "Calorie balance";
            // 
            // txtAddDeficet
            // 
            this.txtAddDeficet.Location = new System.Drawing.Point(237, 49);
            this.txtAddDeficet.Name = "txtAddDeficet";
            this.txtAddDeficet.Size = new System.Drawing.Size(100, 20);
            this.txtAddDeficet.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Calories consumed:";
            // 
            // btnAddCalories
            // 
            this.btnAddCalories.Location = new System.Drawing.Point(237, 75);
            this.btnAddCalories.Name = "btnAddCalories";
            this.btnAddCalories.Size = new System.Drawing.Size(100, 21);
            this.btnAddCalories.TabIndex = 5;
            this.btnAddCalories.Text = "Add Calories";
            this.btnAddCalories.UseVisualStyleBackColor = true;
            this.btnAddCalories.Click += new System.EventHandler(this.btnAddCalories_Click);
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Location = new System.Drawing.Point(14, 49);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(84, 13);
            this.lblNotification.TabIndex = 6;
            this.lblNotification.Text = "Last Added Item";
            // 
            // btnLibraryAdd
            // 
            this.btnLibraryAdd.Location = new System.Drawing.Point(115, 74);
            this.btnLibraryAdd.Name = "btnLibraryAdd";
            this.btnLibraryAdd.Size = new System.Drawing.Size(116, 23);
            this.btnLibraryAdd.TabIndex = 7;
            this.btnLibraryAdd.Text = ">> Add from Library";
            this.btnLibraryAdd.UseVisualStyleBackColor = true;
            this.btnLibraryAdd.Click += new System.EventHandler(this.btnLibraryAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 128);
            this.Controls.Add(this.btnLibraryAdd);
            this.Controls.Add(this.lblNotification);
            this.Controls.Add(this.btnAddCalories);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddDeficet);
            this.Controls.Add(this.lblCalorieBalance);
            this.Controls.Add(this.btnDebug);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Label lblCalorieBalance;
        private System.Windows.Forms.TextBox txtAddDeficet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCalories;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Button btnLibraryAdd;
    }

    public class CalorieData
    {
        public System.DateTime date
        {
            get;
            set;
        }
        public int calories
        {
            get;
            set;
        }

        public CalorieData(System.DateTime date, int calories)
        {
            this.date = date;
            this.calories = calories;
        }
    }
}


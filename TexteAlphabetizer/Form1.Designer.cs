using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace TexteAlphabetizer
{
    partial class Form
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
            this.input = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.AcceptsReturn = true;
            this.input.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input.Location = new System.Drawing.Point(13, 13);
            this.input.MaxLength = 60000;
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.input.Size = new System.Drawing.Size(619, 346);
            this.input.TabIndex = 0;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(285, 365);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Alphabetize";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 396);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.input);
            this.Name = "Form";
            this.Text = "Alphabetizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button goButton;

        void buttonClick()
        {
            string output = "";

            ArrayList toSort = new ArrayList();

            string[] lines = input.Text.Split("\r\n".ToCharArray());

            foreach (string line in lines)
            {
                if (line != "")
                {
                    toSort.Add(line);
                }
            }

            toSort = sortDictionary(toSort);

            foreach (string entry in toSort)
            {
                output += entry + "\r\n";
            }

            input.Text = output.Substring(0, output.Length - "\r\n".Length);

            //Debug.WriteLine(alphabetize("Яāwłāиz", "Dłøяиwnaklчи")); //Should return false
            //Debug.WriteLine(alphabetize("Ānawreftīиānωāktē", "Цзиωeиrī")); //Should return true
            //Debug.WriteLine(alphabetize("Fg", "fga")); //Should return true
        }

        /**
         * Sorts the dictionary by textē's alphabet.
         * @param dictionary The dictionary, already alphabetized.
         * @return The dictionary, with the word added.
         */
        ArrayList sortDictionary(ArrayList dictionary)
        {
            IComparer alphabetizer = new Alphabetizer();
            dictionary.Sort(alphabetizer);
            return dictionary;
        }
    }
}


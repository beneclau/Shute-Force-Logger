 private void buttonSaveLog_Click(object sender, EventArgs e)
            {
           
            if (peaksTable.RowCount < 2)
                {
                MessageBox.Show($"Please press initialize button first");
                }
            if (writingFileTest2 != null)
                {
                writingFileTest2.Close();
                time.Dispose();
               // Debug.WriteLine($"DEBUG TIME ******* 4 {time.Enabled}");

                }
             //if (time.Enabled)
             //  {

             //   time.Dispose();
             //   }

            DialogResult savingQuestion = MessageBox.Show("Do you want to save the reuslts?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (savingQuestion == DialogResult.Yes)
                {
                time.Stop();

                sfd.Filter = "Text |*.txt";
                sfd.Title = "Save a Text File";

                if (sfd.ShowDialog() == DialogResult.Cancel)
                    {

                    }

                else
                    {
                    

                    string inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                    //char[] inputCharInterval = inputStringInterval.ToCharArray();
                    
                    /*while (inputCharInterval[0] == 0 && inputCharInterval[inputCharInterval.Length - 1] == 0)
                        {
                        MessageBox.Show("Invalid value");
                        inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                        }
                   */
                        
                        while (!inputStringInterval.All(char.IsDigit) && button1.Text == "STOP")
                            {
                            MessageBox.Show("Please insert only numeric values");
                            inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                            //if you stop and run again goes into an infinte loop --- INSTABLE CODE HERE
                            }
                        int inputIntInterval = Int32.Parse(inputStringInterval);
                        
                   // if (Decimal.TryParse(inputStringInterval, out inputInterval))
                       // {
                       // if (!time.Enabled)
                          //  {
                        while (inputIntInterval ==0)
                            {
                            MessageBox.Show("Please insert values bigger than 0");
                            inputStringInterval = Microsoft.VisualBasic.Interaction.InputBox("Insert a time interval (in s)", "Time", "10", 600, 300);
                            //if you stop and run again goes into an infinte loop --- INSTABLE CODE HERE
                            inputIntInterval = Int32.Parse(inputStringInterval);
                            }
                        

                          time.Interval = inputIntInterval * 1000;
                          time.Tick += new EventHandler(time_Tick);
                        //time.Enabled = true;
                        Debug.WriteLine($"DEBUG TIME ******* 1 {time.Enabled}");
                            time.Stop();
                            time.Start();
                        Debug.WriteLine($"DEBUG TIME ******* 2 {time.Enabled}");
                        writingFileTest2 = new StreamWriter(sfd.FileName);
                            writingFileTest2.AutoFlush = true;
                            //workerThread.RunWorkerAsync();
                            }
                        //}


                    //}
                }

            }

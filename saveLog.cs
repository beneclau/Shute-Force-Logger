  private void button1_Click(object sender, EventArgs e)
            {

            if (button1.Text == "RUN")
                {

                if (peaksTable.RowCount < 2)
                    {
                    MessageBox.Show($"Please press initialize button first");
                    button1.Text = "RUN";
                    button1.BackColor = Color.Green;
                    }
                else
                    {
                    button1.Text = "STOP";
                    button1.BackColor = Color.Red;
                    workerThread.RunWorkerAsync();
                    /*if (!workerThread.IsBusy)

                       x
                    else
                        MessageBox.Show("Can't run the worker twice!");
                        */
                    timer1.Start();

                    }
                }
            else
                {
                button1.Text = "RUN";
                button1.BackColor = Color.Green;
                time.Stop();
                // time.Enabled = false;
                if (writingFileTest2 != null)
                    {
                    Debug.WriteLine($"****** THREAD DEBUG 1");
                    writingFileTest2.Close();
                    Debug.WriteLine($"****** THREAD DEBUG 2");
                    }
                Debug.WriteLine($"****** THREAD DEBUG 3");
                workerThread.CancelAsync();
                Debug.WriteLine($"****** THREAD DEBUG 4");
                }
            }
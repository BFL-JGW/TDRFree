using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TDRFree
{
  public partial class MainForm : Form
  {
    private TControl MyControl;
    private Boolean Initial;


    //
    //**********************************************************************************************
    //
    // Class MainForm
    //   Part of  : TDRFree
    //   Function : Reacts when user presses a button or other events
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //
    
    public MainForm()
    {
      InitializeComponent();
      Initial = true;
      MyControl = new TControl();
      MyControl.ShowInitialValues(txtExcelFile, txtbxPrecipitation, txtbxIrrigationFile, txtbxOutputDir,
        chckbxIrrigation, chckbxPPT, txtbxPPT);
    }

    //
    //**********************************************************************************************
    //

    private void btnExit_Click(object sender, EventArgs e)
    {
       Close();
    }

    //
    //**********************************************************************************************
    //

    private void btnRun_Click(object sender, EventArgs e)
    {
      if (MyControl.Running)
      {
        MyControl.Running = false;
        btnRun.Text = "Run";
     }
      else
      {
        MyControl.SetColors(btnBackgroundColor, btnAxesColor, btnPrecipitationColor, btnIrrigationColor);
        MyControl.Running = true;
        btnRun.Text = "Stop";
        MyControl.ShowDataForEachDay(pctrbxShow, btnBackgroundColor.BackColor, btnAxesColor.BackColor, btnExit);
        if (MyControl.Running)
        {
          MyControl.Running = false;
          btnRun.Text = "Run";
        }
      }
    }

    //
    //**********************************************************************************************
    //

    private void chckbxPPT_CheckedChanged(object sender, EventArgs e)
    {
      txtbxPPT.Enabled = chckbxPPT.Checked;
      btnBrowse5.Enabled = chckbxPPT.Checked;
    }

    //
    //**********************************************************************************************
    //

    private void btnBrowse1_Click(object sender, EventArgs e)
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Title = "Select file";
      dlg.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx|All files|*.*";
      dlg.Multiselect = false;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        txtExcelFile.Text = dlg.FileName;
      }
      dlg.Dispose();
    }

    //
    //**********************************************************************************************
    //

    private void btnBrowse2_Click(object sender, EventArgs e)
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Title = "Select file";
      dlg.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx|All files|*.*";
      dlg.Multiselect = false;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        txtbxPrecipitation.Text = dlg.FileName;
      }
      dlg.Dispose();
    }

    //
    //**********************************************************************************************
    //

    private void chrtPrec1_MouseClick(object sender, MouseEventArgs e)
    {
      Double Fraction;
      Int32 X = e.X;
      if ((X >= chrtPrec1.Axes.Bottom.IStartPos) & (X < chrtPrec1.Axes.Bottom.IEndPos))
      {
        Double Left = chrtPrec1.Axes.Bottom.IStartPos;
        Double Right = chrtPrec1.Axes.Bottom.IEndPos;
        Fraction = (X - Left) / (Right - Left);
      }
      else
      {
        Fraction = -1.0;
      }
      MyControl.FindNewStartAndEnd(Fraction);
      MyControl.ShowPrecipitation(1);
      MyControl.ShowPrecipitation(2);
      chrtPrec1.Update();
      clndrFirst.Value = MyControl.FirstDay;
      clndrLast.Value = MyControl.LastDay;
    }

    //
    //**********************************************************************************************
    //

    private void clndrFirst_ValueChanged(object sender, EventArgs e)
    {
      if (!Initial)
      {
        MyControl.FirstDay = clndrFirst.Value;
        MyControl.ShowPrecipitation(1);
        MyControl.ShowPrecipitation(2);
      }
    }

    //
    //**********************************************************************************************
    //

    private void clndrLast_ValueChanged(object sender, EventArgs e)
    {
      if (!Initial)
      {
        MyControl.LastDay = clndrLast.Value;
        MyControl.ShowPrecipitation(1);
        MyControl.ShowPrecipitation(2);
      }
    }

    //
    //**********************************************************************************************
    //

    private void btnLoad_Click(object sender, EventArgs e)
    {
      Int32 Resolution = 300;
      if (Resolution > 0)
      {
        Boolean IrrigOK = true;
        this.Cursor = Cursors.WaitCursor;
        if (chckbxIrrigation.Checked)
        {
          if (!File.Exists(txtbxIrrigationFile.Text))
          {
            IrrigOK = false;
          }
        }
        if ((File.Exists(txtExcelFile.Text)) & (IrrigOK))
        {
          if (MyControl.InitializeControl(pctrbxShow, rchdtLog, brTimes, brPoints, btnBackgroundColor, btnAxesColor,
                                   btnPrecipitationColor, btnIrrigationColor,
                                   txtExcelFile.Text, txtbxPrecipitation.Text, chckbxIrrigation.Checked,
                                   txtbxIrrigationFile.Text, txtbxPPT.Text, chckbxPPT.Checked, txtbxOutputDir.Text,
                                   chrtPrec1))
          {

            clndrFirst.Value = MyControl.FirstDay;
            clndrFirst.MinDate = MyControl.FirstDay;
            clndrLast.Value = MyControl.LastDay;
            clndrLast.MaxDate = MyControl.LastDay;
            pnlShow.Visible = true;
            Initial = false;
          }
        }
        else
        {
          rchdtLog.AppendText("One or more input files do not exist!");
        }
        this.Cursor = Cursors.Default;
      }
    }

    //
    //**********************************************************************************************
    //

    private void chckbxIrrigation_CheckedChanged(object sender, EventArgs e)
    {
      txtbxIrrigationFile.Enabled = chckbxIrrigation.Checked;
      btnBrowse3.Enabled = chckbxIrrigation.Checked;
    }

    //
    //**********************************************************************************************
    //

    private void btnBrowse3_Click(object sender, EventArgs e)
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Title = "Select file";
      dlg.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx|All files|*.*";
      dlg.Multiselect = false;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        txtbxIrrigationFile.Text = dlg.FileName;
      }
      dlg.Dispose();
    }

    //
    //**********************************************************************************************
    //

    private void btnBrowse5_Click(object sender, EventArgs e)
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Title = "Select file";
      dlg.Filter = "Powerpoint files (*.ppt)|*.ppt|All files|*.*";
      dlg.Multiselect = false;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        txtbxPPT.Text = dlg.FileName;
      }
      dlg.Dispose();

    }

    //
    //**********************************************************************************************
    //

    private void btnBrowse4_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog dlg = new FolderBrowserDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        txtbxOutputDir.Text = dlg.SelectedPath + @"\";
      }
      dlg.Dispose();
    }

    //
    //**********************************************************************************************
    //

    private void btnBackgroundColor_Click(object sender, EventArgs e)
    {
      ColorDialog MyDialog = new ColorDialog();
      MyDialog.AllowFullOpen = true;
      MyDialog.Color = btnBackgroundColor.BackColor;

      // Update the text box color if the user clicks OK 
      if (MyDialog.ShowDialog() == DialogResult.OK)
      {
        btnBackgroundColor.BackColor = MyDialog.Color;
      }
    }

    //
    //**********************************************************************************************
    //

    private void btnAxesColor_Click(object sender, EventArgs e)
    {
      ColorDialog MyDialog = new ColorDialog();
      MyDialog.AllowFullOpen = true;
      MyDialog.Color = btnAxesColor.BackColor;

      // Update the text box color if the user clicks OK 
      if (MyDialog.ShowDialog() == DialogResult.OK)
      {
        btnAxesColor.BackColor = MyDialog.Color;
      }
    }

    //
    //**********************************************************************************************
    //
    
    private void btnPrecipitationColor_Click(object sender, EventArgs e)
    {

      ColorDialog MyDialog = new ColorDialog();
      MyDialog.AllowFullOpen = true;
      MyDialog.Color = btnPrecipitationColor.BackColor;

      // Update the text box color if the user clicks OK 
      if (MyDialog.ShowDialog() == DialogResult.OK)
      {
        btnPrecipitationColor.BackColor = MyDialog.Color;
      }
    }

    //
    //**********************************************************************************************
    //

    private void btnIrrigationColor_Click(object sender, EventArgs e)
    {
      ColorDialog MyDialog = new ColorDialog();
      MyDialog.AllowFullOpen = true;
      MyDialog.Color = btnIrrigationColor.BackColor;

      // Update the text box color if the user clicks OK 
      if (MyDialog.ShowDialog() == DialogResult.OK)
      {
        btnIrrigationColor.BackColor = MyDialog.Color;
      }
    }

  }
}
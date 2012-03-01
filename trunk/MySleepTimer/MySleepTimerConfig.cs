#region Copyright (C) 2005-2010 Team MediaPortal

// Copyright (C) 2005-2010 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaPortal.GUI.Library;
using MediaPortal.Util;
using Action = MediaPortal.GUI.Library.Action;

namespace MySleepTimer
{
  public partial class MySleepTimerConfig : Form
  {
    public MySleepTimerConfig()
    {
      InitializeComponent();
      LoadSettings();
    }

    #region Settings

    private void LoadSettings()
    {
      try
      {
        comboBoxActionType.DataSource = GenerateActionList();
        comboBoxActionType.DisplayMember = "ActionName";
        comboBoxActionType.ValueMember = "ActionType";
        comboBoxShutDownType.DataSource = GenerateShutdownList();
        comboBoxShutDownType.DisplayMember = "ShutdownName";
        comboBoxShutDownType.ValueMember = "ShutdownType";

        Settings.Load();
        comboBoxActionType.SelectedValue = Settings.ActionType;
        comboBoxSleepBehavior.Text = Settings.SleepBehavior;

        checkBoxUsePSSettings.Checked = Settings.UsePowerSchedulerSettings;
        comboBoxShutDownType.SelectedValue = Settings.ShutdownType;
        checkBoxShutDownForce.Checked = Settings.ShutdownForce;

        numericUpDownSleepTimeMax.Value = Settings.SleepTimeMaxium;
        numericUpDownSleepTimeStep.Value = Settings.SleepTimeStep;
        numericUpDownTimeOutB.Value = Settings.ActionTimeOutMs;
        numericUpDownNotifyBeforeSleep.Value = Settings.NotifyBeforeSleep;
        numericUpDownNotifyInterval.Value = Settings.NotifyInterval;
        numericUpDownTimeOutN.Value = Settings.NotifyTimeOutMs;

        SetUpShutDownTypeControls();
        SetUpNotifyControls();
      }
      catch (Exception ex)
      {
        Log.Error(ex);
      }
    }

    private void SaveSettings()
    {
      Settings.ActionType = (Action.ActionType)comboBoxActionType.SelectedValue;
      Settings.SleepBehavior = comboBoxSleepBehavior.Text;

      Settings.UsePowerSchedulerSettings = checkBoxUsePSSettings.Checked;
      Settings.ShutdownType = (RestartOptions)comboBoxShutDownType.SelectedValue;
      Settings.ShutdownForce = checkBoxShutDownForce.Checked;

      Settings.SleepTimeMaxium = (int)numericUpDownSleepTimeMax.Value;
      Settings.SleepTimeStep = (int)numericUpDownSleepTimeStep.Value;
      Settings.ActionTimeOutMs = (int)numericUpDownTimeOutB.Value;
      Settings.NotifyBeforeSleep = (int)numericUpDownNotifyBeforeSleep.Value;
      Settings.NotifyInterval = (int)numericUpDownNotifyInterval.Value;
      Settings.NotifyTimeOutMs = (int)numericUpDownTimeOutN.Value;
      Settings.Save();
    }

    #endregion

    #region Windows Forms events

    private void okButton_Click(object sender, EventArgs e)
    {
      SaveSettings();
      Close();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      Close();
    }


    private void comboBoxSleepBehavior_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetUpShutDownTypeControls();
    }

    private void checkBoxUsePSSettings_CheckedChanged(object sender, EventArgs e)
    {
      SetUpShutDownTypeControls();
    }

    private void numericUpDownNotifyBeforeSleep_ValueChanged(object sender, EventArgs e)
    {
      SetUpNotifyControls();
    }

    private void numericUpDownNotifyInterval_ValueChanged(object sender, EventArgs e)
    {
      SetUpNotifyControls();
    }

    #endregion

    private static List<ActionEntry> GenerateActionList()
    {
      var ret = new List<ActionEntry>();

      foreach (var variable in Enum.GetValues(typeof (Action.ActionType)))
        ret.Add(new ActionEntry((Action.ActionType)variable));

      ret.Sort();

      return ret;
    }

    private static List<ShutdownEntry> GenerateShutdownList()
    {
      var ret = new List<ShutdownEntry>();

      foreach (var variable in Enum.GetValues(typeof (RestartOptions)))
        ret.Add(new ShutdownEntry((RestartOptions)variable));

      ret.Sort();

      return ret;
    }

    private void SetUpShutDownTypeControls()
    {
      groupBox1.Enabled = comboBoxSleepBehavior.Text == "Shutdown";

      checkBoxUsePSSettings.Enabled = Settings.PowerSchedulerAvailable;

      if (checkBoxUsePSSettings.Enabled && checkBoxUsePSSettings.Checked)
      {
        comboBoxShutDownType.Enabled = false;
        checkBoxShutDownForce.Enabled = false;
      }
      else
      {
        comboBoxShutDownType.Enabled = true;
        checkBoxShutDownForce.Enabled = true;
      }
    }

    private void SetUpNotifyControls()
    {
      try
      {
        if (numericUpDownNotifyBeforeSleep.Value != 0)
        {
          if (numericUpDownNotifyInterval.Value > numericUpDownNotifyBeforeSleep.Value)
          {
            numericUpDownNotifyInterval.Value = numericUpDownNotifyBeforeSleep.Value;
          }

          label8.Enabled = true;
          numericUpDownNotifyInterval.Enabled = true;
          label9.Enabled = true;
          numericUpDownTimeOutN.Enabled = true;
        }
        else
        {
          numericUpDownNotifyInterval.Value = numericUpDownNotifyInterval.Minimum;

          label8.Enabled = false;
          numericUpDownNotifyInterval.Enabled = false;
          label9.Enabled = false;
          numericUpDownTimeOutN.Enabled = false;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex);
      }
    }
  }

  internal class ActionEntry : IComparable<ActionEntry>
  {
    public Action.ActionType ActionType { get; private set; }

    public string ActionName
    {
      get { return ActionType.ToString(); }
    }

    public int ActionID
    {
      get { return (int)ActionType; }
    }

    public ActionEntry(Action.ActionType actionType)
    {
      ActionType = actionType;
    }

    #region IComparable<ActionEntry> Member

    public int CompareTo(ActionEntry other)
    {
      return ActionName.CompareTo(other.ActionName);
    }

    #endregion
  }

  internal class ShutdownEntry : IComparable<ShutdownEntry>
  {
    public RestartOptions ShutDownType { get; private set; }

    public string ShutdownName
    {
      get { return ShutDownType.ToString(); }
    }

    public int ShutdownID
    {
      get { return (int)ShutDownType; }
    }

    public ShutdownEntry(RestartOptions restartOptions)
    {
      ShutDownType = restartOptions;
    }

    #region IComparable<ShutdownEntry> Member

    public int CompareTo(ShutdownEntry other)
    {
      return ShutdownName.CompareTo(other.ShutdownName);
    }

    #endregion
  }
}
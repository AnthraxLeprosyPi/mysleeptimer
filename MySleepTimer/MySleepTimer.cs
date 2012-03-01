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
using System.Timers;
using System.Windows.Forms;
using MediaPortal.Configuration;
using MediaPortal.Dialogs;
using MediaPortal.GUI.Library;
using MediaPortal.Util;
using Action = MediaPortal.GUI.Library.Action;
using Timer = System.Timers.Timer;

namespace MySleepTimer
{
  [PluginIcons("MySleepTimer.img.MySleepTimer_enabled.png", "MySleepTimer.img.MySleepTimer_disabled.png")]
  public class MySleepTimer : IPlugin, ISetupForm
  {
    private const int SHUTDOWN_CYCLE_MS = 60 * 1000;
    private const int SHUTDOWN_ANNOUNCE_MS = 3 * 1000;

    //timers
    private Timer _timerShutDown;
    private Timer _timerAction;
    private Timer _timerNotify;
    //MP
    private GUIDialogNotify _dialogSleepTimerNotify;

    //globals
    private int _sleepTimeCurrent = 0;
    private bool _timedOut = true;
    private bool _setByPlay = false;
    private bool _shutdowning = false;

    private void GUIWindowManager_OnNewAction(Action action)
    {
      try
      {
        if ((action.wID == Settings.ActionType) && (!_shutdowning)) //action and no shutdown in progress
        {
          _timerAction.Stop();
          _timerNotify.Stop();
          if (_timedOut && _timerShutDown.Enabled) //1st press
          {
            _timedOut = false;
            //action
            _timerAction.Start();
            ShowNotifyDialog(Settings.ActionTimeOutMs, string.Format("Time left: {0} min", _sleepTimeCurrent));
          }
          else //additional presses
          {
            _timerShutDown.Stop();
            SetTime();
            if (_sleepTimeCurrent > 0)
              _timerShutDown.Start();
            if ((_sleepTimeCurrent > 0) && (_sleepTimeCurrent <= Settings.NotifyBeforeSleep) &&
                ((Settings.NotifyBeforeSleep - _sleepTimeCurrent) % Settings.NotifyInterval == 0)) //notify
            {
              _timerNotify.Start();
              ShowNotifyDialog(Settings.NotifyTimeOutMs, null);
            }
            else //action
            {
              _timerAction.Start();
              ShowNotifyDialog(Settings.NotifyTimeOutMs, null);
            }
          }
          //base.OnAction(action);
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex);
      }
    }

    private void timerAction_Tick(object sender, EventArgs e)
    {
      try
      {
        _timedOut = true;
        _setByPlay = false; //reset play flag
        //will stop after tick (AutoReset = false)
      }
      catch (Exception ex)
      {
        Log.Error(ex);
      }
    }

    private void timerNotify_Tick(object sender, EventArgs e)
    {
      try
      {
        _timedOut = true;
        //will stop after tick (AutoReset = false)
      }
      catch (Exception ex)
      {
        Log.Error(ex);
      }
    }

    private void timerShutDown_Tick(object sender, EventArgs e)
    {
      try
      {
        if (_sleepTimeCurrent > 0)
        {
          _sleepTimeCurrent -= 1;
          if (_sleepTimeCurrent == 0) //shutdown
          {
            _shutdowning = true; //to block action
            _timerShutDown.Stop();
            _timerAction.Stop();
            _timerNotify.Stop();
            ShowNotifyDialog(SHUTDOWN_ANNOUNCE_MS, "Time's up - Have a good night !");
            //reset globals
            _sleepTimeCurrent = 0;
            _timedOut = true;
            _setByPlay = false;
            _shutdowning = false;
            switch (Settings.SleepBehavior)
            {
              case "Shutdown":
                WindowsController.ExitWindows(Settings.ShutdownType, Settings.ShutdownForce, null);
                break;
              case "Exit MediaPortal":
                Application.Exit();
                break;
              case "Show Basic Home":
                GUIWindowManager.ActivateWindow((int)GUIWindow.Window.WINDOW_HOME, true);
                break;
              default:
                WindowsController.ExitWindows(Settings.ShutdownType, Settings.ShutdownForce, null);
                break;
            }
          }
          else if ((_sleepTimeCurrent <= Settings.NotifyBeforeSleep) &&
                   ((Settings.NotifyBeforeSleep - _sleepTimeCurrent) % Settings.NotifyInterval == 0))
            //notify
          {
            _timerAction.Stop();
            _timerNotify.Stop();
            _timedOut = false; //simulate 1st press - with reset by notify timer
            _timerNotify.Start();
            ShowNotifyDialog(Settings.NotifyTimeOutMs, null);
          }
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex);
      }
    }

    private void SetTime()
    {
      try
      {
        //get remaining playtime (if any)
        int totalMinutes = 0;
        try
        {
          //TO DO - add additional test here - to detect if some video play is realy in progress
          string[] shortCurrentRemaining =
            GUIPropertyManager.GetProperty("#shortcurrentremaining").Split(new char[] {':'});
          totalMinutes = (int.Parse(shortCurrentRemaining[0]) * 60) + int.Parse(shortCurrentRemaining[1]);
        }
        catch {}

        if ((totalMinutes != 0) && (_sleepTimeCurrent == 0))
        {
          //play and additional press from "stopped"
          _sleepTimeCurrent = totalMinutes + 1;
          _setByPlay = true; //set play flag
        }
        else
        {
          //other additional presses
          if ((totalMinutes != 0) && (_setByPlay))
          {
            //play and 2nd additional press
            _sleepTimeCurrent = 0; //prepare for standard increment
          }
          _setByPlay = false; //reset play flag
          //standard increment
          _sleepTimeCurrent += Settings.SleepTimeStep;
          _sleepTimeCurrent = (_sleepTimeCurrent / Settings.SleepTimeStep) * Settings.SleepTimeStep; //normalize
          if (_sleepTimeCurrent > Settings.SleepTimeMaxium)
            _sleepTimeCurrent = 0; //overflowed; let timer be stopped
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex);
      }
    }

    private void ShowNotifyDialog(int timeOut, string notifyMessage)
    {
      try
      {
        timeOut /= 1000; //to seconds
        //construct message if empty
        if (notifyMessage == null)
        {
          if (_sleepTimeCurrent > 0) //running
          {
            if (_setByPlay) //play
              notifyMessage = string.Format("Sleep in: {0} min (remaining playtime)", _sleepTimeCurrent);
            else //standard
              notifyMessage = string.Format("Sleep in: {0} min", _sleepTimeCurrent);
          }
          else //stopped
            notifyMessage = "Sleep Timer stopped !";
        }

        //show
        _dialogSleepTimerNotify =
          (GUIDialogNotify)GUIWindowManager.GetWindow((int)GUIWindow.Window.WINDOW_DIALOG_NOTIFY);
        _dialogSleepTimerNotify.TimeOut = timeOut;
        _dialogSleepTimerNotify.SetImage(GUIGraphicsContext.Skin + @"\Media\MySleepTimer_enabled.png");
        _dialogSleepTimerNotify.SetHeading("MySleepTimer");
        _dialogSleepTimerNotify.SetText(notifyMessage);
        _dialogSleepTimerNotify.DoModal(GUIWindowManager.ActiveWindow);
      }
      catch (Exception ex)
      {
        Log.Error(ex);
      }
    }

    #region ISetupForm Members

    /// <summary>
    /// Gets the plugin name.
    /// </summary>
    /// <returns>The plugin name.</returns>
    public string PluginName()
    {
      return "MySleepTimer";
    }

    /// <summary>
    /// Gets the description of the plugin.
    /// </summary>
    /// <returns>The plugin description.</returns>
    public string Description()
    {
      return
        "Want MediaPortal to be your sleeping agent of choice? Well, here you go! (but be warned - might be highly addictive!)";
    }

    /// <summary>
    /// Gets the plugin author.
    /// </summary>
    /// <returns>The plugin author.</returns>
    public string Author()
    {
      return "Anthrax";
    }

    /// <summary>
    /// Shows the plugin configuration.
    /// </summary>
    public void ShowPlugin()
    {
      new MySleepTimerConfig().ShowDialog();
    }

    /// <summary>
    /// Determines whether this plugin can be enabled.
    /// </summary>
    /// <returns>
    /// <c>true</c> if this plugin can be enabled; otherwise, <c>false</c>.
    /// </returns>
    public bool CanEnable()
    {
      return true;
    }

    /// <summary>
    /// Gets the window id.
    /// </summary>
    /// <returns>The window id.</returns>
    public int GetWindowId()
    {
      // WindowID of windowplugin belonging to this setup
      // enter your own unique code
      return -1;
    }

    /// <summary>
    /// Defaults enabled.
    /// </summary>
    /// <returns>true if this plugin is enabled by default, otherwise false.</returns>
    public bool DefaultEnabled()
    {
      return true;
    }

    /// <summary>
    /// Determines whether this plugin has setup.
    /// </summary>
    /// <returns>
    /// <c>true</c> if this plugin has setup; otherwise, <c>false</c>.
    /// </returns>
    public bool HasSetup()
    {
      return true;
    }

    /// <summary>
    /// If the plugin should have it's own button on the main menu of Mediaportal then it
    /// should return true to this method, otherwise if it should not be on home
    /// it should return false
    /// </summary>
    /// <param name="strButtonText">text the button should have</param>
    /// <param name="strButtonImage">image for the button, or empty for default</param>
    /// <param name="strButtonImageFocus">image for the button, or empty for default</param>
    /// <param name="strPictureImage">subpicture for the button or empty for none</param>
    /// <returns>true : plugin needs it's own button on home
    /// false : plugin does not need it's own button on home</returns>
    public bool GetHome(out string strButtonText, out string strButtonImage,
                        out string strButtonImageFocus, out string strPictureImage)
    {
      strButtonText = PluginName();
      strButtonImage = String.Empty;
      strButtonImageFocus = String.Empty;
      strPictureImage = String.Empty;
      return false;
    }

    #endregion

    #region IPlugin Member

    /// <summary>
    /// This method will be called by mediaportal to start your process plugin
    /// </summary>
    public void Start()
    {
      Settings.Load();

      _timerShutDown = new Timer();
      _timerAction = new Timer();
      _timerNotify = new Timer();

      //inits
      _timerShutDown.Interval = SHUTDOWN_CYCLE_MS;
      _timerShutDown.Elapsed += new ElapsedEventHandler(timerShutDown_Tick);
      _timerAction.Interval = Settings.ActionTimeOutMs;
      _timerAction.AutoReset = false;
      _timerAction.Elapsed += new ElapsedEventHandler(timerAction_Tick);
      _timerNotify.Interval = Settings.NotifyTimeOutMs;
      _timerNotify.AutoReset = false;
      _timerNotify.Elapsed += new ElapsedEventHandler(timerNotify_Tick);

      GUIWindowManager.OnNewAction += new OnActionHandler(GUIWindowManager_OnNewAction);
    }

    /// <summary>
    /// This method will be called by mediaportal to stop your process plugin
    /// </summary>
    public void Stop()
    {
      GUIWindowManager.OnNewAction -= new OnActionHandler(GUIWindowManager_OnNewAction);
    }

    #endregion
  }
}
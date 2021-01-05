using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETAPM.Models;
namespace NotificationMaker
{
    public partial class MainForm : Form
    { 
        public MainForm()
        {
            InitializeComponent();
            tmrBeforOnDay.Interval = 300000;// 300000 for 5 min |  4320000 for 12 hours;
        }

        private void MainForm_Load(object sender, EventArgs e)
        { 
        }

        public void MakeNotification()
        {
            using (var db = new ApplicationDbContext())
            {


                var tasks = db.Tasks.Where(t => t.TaskStatusId == 1);

                foreach (var t in tasks)
                {
                    try
                    {
                        //1. notification before 1 day of starting tasks
                        if (t.StartDateTime.Date.AddDays(-1).Date == DateTime.Now.Date)
                        {
                            AppUser u = db.AppUsers.Find(t.AssignedToAppUserId);

                            string msg = string.Format("Hello {0}, there is a task '{1}' should be started tommorrow.", u.FirstName, t.Title);

                            using (var db1 = new ApplicationDbContext())
                            {
                                Notification notification = new Notification
                                {
                                    TypeId = 1,
                                    DataId = t.TaskId,
                                    IsRead = false,
                                    NotificationToAppUserId = u.AppUserId,
                                    Message = msg,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                };

                                db1.Notifications.Add(notification);
                                db1.SaveChanges();
                            }

                            EmailSender.SendEmail(u.EmailId, "Task starting reminder.", msg);
                            listBox1.Items.Add("Notification generated for " + u.EmailId);
                            continue;
                        }

                        int DurationInPercent = (t.RemainingDuration / t.Duration) * 100;

                        //2. notification after 50% duration consumed 
                        if ((DurationInPercent >= 50 && DurationInPercent <= 51) || (DurationInPercent >= 90 && DurationInPercent <= 91))
                        {
                            AppUser u = db.AppUsers.Find(t.AssignedToAppUserId);

                            string msg = string.Format("Hello {0}, You have utilised {1:0.00}% of the given time for task {2}", u.FirstName, DurationInPercent, t.Title);

                            using (var db1 = new ApplicationDbContext())
                            {
                                Notification notification = new Notification
                                {
                                    TypeId = 1,
                                    DataId = t.TaskId,
                                    IsRead = false,
                                    NotificationToAppUserId = u.AppUserId,
                                    Message = msg,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                };

                                db1.Notifications.Add(notification);
                                db1.SaveChanges();
                            }

                            EmailSender.SendEmail(u.EmailId, "Task duration reminder.", msg);
                            listBox1.Items.Add("Notification generated for " + u.EmailId);
                            continue;
                        }

                    }
                    catch (Exception ex)
                    {
                        listBox1.Items.Add(ex.Message);
                    }

                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tmrBeforOnDay_Tick(object sender, EventArgs e)
        {
            if (!bwBD.IsBusy)
            {
                bwBD.RunWorkerAsync();
            }
        }

        private void bwBD_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                var tasks = db.Tasks.Where(t => t.TaskStatusId == 1);
                foreach (var t in tasks)
                {
                    try
                    {
                        //1. notification before 1 day of starting tasks
                        if (t.StartDateTime.Date.AddDays(-1).Date == DateTime.Now.Date)
                        {
                            AppUser u = db.AppUsers.Find(t.AssignedToAppUserId);

                            string msg = string.Format("Hello {0}, there is a task '{1}' should be started tommorrow.", u.FirstName, t.Title);

                            using (var db1 = new ApplicationDbContext())
                            {
                                Notification notification = new Notification
                                {
                                    TypeId = 1,
                                    DataId = t.TaskId,
                                    IsRead = false,
                                    NotificationToAppUserId = u.AppUserId,
                                    Message = msg,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                };

                                db1.Notifications.Add(notification);
                                db1.SaveChanges();
                            }

                            EmailSender.SendEmail(u.EmailId, "Task starting reminder.", msg); 
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        bwBD.ReportProgress(0, ex.Message);
                    }

                }
            }
        }

        private void bwBD_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            listBox1.Items.Add(e.UserState);
        }

        private void bwBD_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBox1.Items.Add("Task starting remider before 1 day process  is completed.");
        }



        private void tmrDU_Tick(object sender, EventArgs e)
        {
            if (!bwDU.IsBusy)
            {
                bwDU.RunWorkerAsync();
            }
        }

        private void bwDU_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var db = new ApplicationDbContext())
            { 
                var tasks = db.Tasks.Where(t => t.TaskStatusId == 1);

                foreach (var t in tasks)
                {
                    try
                    { 
                        double DurationInPercent = (Convert.ToDouble(t.Duration - t.RemainingDuration) / Convert.ToDouble(t.Duration)) * 100;

                        //2. notification after 50% duration consumed 
                        if ((DurationInPercent >= 50 && DurationInPercent <= 51) || (DurationInPercent >= 90 && DurationInPercent <= 91))
                        {
                            AppUser u = db.AppUsers.Find(t.AssignedToAppUserId);

                            string msg = string.Format("Hello {0}, You have utilised {1:0.00}% of the given time for task {2}", u.FirstName, DurationInPercent, t.Title);

                            using (var db1 = new ApplicationDbContext())
                            {
                                Notification notification = new Notification
                                {
                                    TypeId = 1,
                                    DataId = t.TaskId,
                                    IsRead = false,
                                    NotificationToAppUserId = u.AppUserId,
                                    Message = msg,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                };

                                db1.Notifications.Add(notification);
                                db1.SaveChanges();
                            }

                            EmailSender.SendEmail(u.EmailId, "Task duration reminder.", msg); 
                            continue;
                        }

                    }
                    catch (Exception ex)
                    {
                        bwDU.ReportProgress(0, ex.Message);
                    }

                }
            }
        }

        private void bwDU_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            listBox1.Items.Add(e.UserState);
        }

        private void bwDU_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBox1.Items.Add(string.Format("Duration utilised remider process completed on {0}", DateTime.Now));
        }
    }
}
